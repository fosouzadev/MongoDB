using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AluraCurso1
{
    public class Book
    {
        public Book()
        {
            Assunto = new string[0];
        }

        public Book(string titulo, string autor, int ano, int paginas, string assuntos)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Paginas = paginas;

            if (!string.IsNullOrEmpty(assuntos))
                Assunto = assuntos.Split(',');
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public string[] Assunto { get; set; }
    }
}