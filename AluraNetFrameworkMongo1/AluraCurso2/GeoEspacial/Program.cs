using GeoEspacial.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace GeoEspacial
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDB mongo = new MongoDB();

            var localizacaoAtual = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(-118.325258, 34.103212)
            );

            var airports = mongo.Airports.Find(
                Builders<Airport>.Filter.NearSphere(n => n.loc, localizacaoAtual, 100000) // ultimo parametro é metros do raio de busca
            ).ToListAsync().Result;

            foreach (var airport in airports)
                Console.WriteLine($"{airport.ToJson<Airport>()} \n");

            Console.ReadKey();
        }
    }
}