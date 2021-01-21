using Alura.GoogleMaps.Web.Geocoding;
using Alura.GoogleMaps.Web.Models;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Alura.GoogleMaps.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //coordenadas quaisquer para mostrar o mapa
            var coordenadas = new Coordenada("São Paulo", "-23.64340873969638", "-46.730219057147224");
            return View(coordenadas);
        }

        public async Task<JsonResult> Localizar(HomeViewModel model)
        {
            Debug.WriteLine(model);

            //Captura a posição atual e adiciona a lista de pontos
            Coordenada coordLocal = ObterCoordenadasDaLocalizacao(model.Endereco);
            var aeroportosProximos = new List<Coordenada>();
            aeroportosProximos.Add(coordLocal);

            //Captura a latitude e longitude locais
            double lat = Convert.ToDouble(coordLocal.Latitude);
            double lon = Convert.ToDouble(coordLocal.Longitude);

            //Testa o tipo de aeroporto que será usado na consulta
            string tipoAero = "";

            if (model.Tipo == TipoAeroporto.Internacionais)
            {
                tipoAero = "International";
            }
            if (model.Tipo == TipoAeroporto.Municipais)
            {
                tipoAero = "Municipal";
            }

            //Captura o valor da distancia
            int distancia = model.Distancia * 1000;

            //Conecta MongoDB    
            MongoDBConnect mongo = new MongoDBConnect();

            //Configura o ponto atual no mapa           
            var localizacaoAtual = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(lon, lat)
            );

            // filtro
            FilterDefinition<Airport> filter;

            if (string.IsNullOrEmpty(tipoAero))
                filter = Builders<Airport>.Filter.NearSphere(n => n.loc, localizacaoAtual, distancia);
            else
                filter = Builders<Airport>.Filter.NearSphere(n => n.loc, localizacaoAtual, distancia)
                       & Builders<Airport>.Filter.Eq(x => x.type, tipoAero);

            //Captura  a lista
            try
            {
                var airports = mongo.Airports.Find(filter).ToListAsync().Result;

                //Escreve os pontos
                var coordenadas = airports.Select(s => new Coordenada(
                    s.name,
                    s.loc.Coordinates.Latitude.ToString(),
                    s.loc.Coordinates.Longitude.ToString()
                ));
                aeroportosProximos.AddRange(coordenadas);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(aeroportosProximos);
        }

        private Coordenada ObterCoordenadasDaLocalizacao(string endereco)
        {
            //string url = $"http://maps.google.com/maps/api/geocode/json?address={endereco}";
            //Debug.WriteLine(url);

            //var coord = new Coordenada("Não Localizado", "-10", "-10");
            //var response = new WebClient().DownloadString(url);
            //var googleGeocode = JsonConvert.DeserializeObject<GoogleGeocodeResponse>(response);
            ////Debug.WriteLine(googleGeocode);

            //if (googleGeocode.status == "OK")
            //{
            //    coord.Nome = googleGeocode.results[0].formatted_address;
            //    coord.Latitude = googleGeocode.results[0].geometry.location.lat;
            //    coord.Longitude = googleGeocode.results[0].geometry.location.lng;
            //}
            var coord = new Coordenada("Coral Way", "25.756420", "-80.200965");

            return coord;
        }
    }
}