using MongoDB.Bson;
using MongoDB.Driver;
using projetoBlog.Models;
using projetoBlog.Models.Home;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace projetoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly AcessoMongoDB _mongo;

        public HomeController()
        {
            _mongo = new AcessoMongoDB();
        }

        public async Task<ActionResult> Index()
        {
            var publicacoesRecentes = await _mongo.Publications.Find(new BsonDocument())
                                                .SortByDescending(s => s.DataCriacao)
                                                .Limit(10).ToListAsync();

            var model = new IndexModel
            {
                PublicacoesRecentes = publicacoesRecentes
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NovaPublicacao()
        {
            return View(new NovaPublicacaoModel());
        }

        [HttpPost]
        public async Task<ActionResult> NovaPublicacao(NovaPublicacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Publicacao post = new Publicacao
            {
                Autor = User.Identity.Name,
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                Tags = model.Tags.Split(' ', ',', ';'),
                DataCriacao = DateTime.UtcNow,
                Comentarios = new List<Comentario>()
            };

            await _mongo.Publications.InsertOneAsync(post);

            return RedirectToAction("Publicacao", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Publicacao(string id)
        {
            var publicacao = await _mongo.Publications.Find(f => f.Id == id).FirstOrDefaultAsync();

            if (publicacao == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PublicacaoModel
            {
                Publicacao = publicacao,
                NovoComentario = new NovoComentarioModel
                {
                    PublicacaoId = id
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Publicacoes(string tag = null)
        {
            List<Publicacao> posts = null;

            if (string.IsNullOrEmpty(tag))
                posts = await _mongo.Publications.Find(new BsonDocument())
                                                 .SortByDescending(s => s.DataCriacao)
                                                 .Limit(10).ToListAsync();
            else
                posts = await _mongo.Publications.Find(Builders<Publicacao>.Filter.AnyEq(f => f.Tags, tag))
                                                 .SortByDescending(s => s.DataCriacao)
                                                 .Limit(10).ToListAsync();

            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
            }

            Comentario comentario = new Comentario
            {
                Autor = User.Identity.Name,
                Conteudo = model.Conteudo,
                DataCriacao = DateTime.UtcNow
            };

            await _mongo.Publications.UpdateOneAsync(
                Builders<Publicacao>.Filter.Eq(f => f.Id, model.PublicacaoId),
                Builders<Publicacao>.Update.Push(p => p.Comentarios, comentario)
            );

            return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }
    }
}