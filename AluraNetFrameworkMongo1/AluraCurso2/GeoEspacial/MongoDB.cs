using GeoEspacial.Models;
using MongoDB.Driver;
using System;

namespace GeoEspacial
{
    class MongoDB
    {
        private string _connectionString = "INSERIR_CONNECTION_STRING";
        private string _databaseName = "geo";
        private bool _hasError = false;

        private IMongoDatabase _database;

        public MongoDB()
        {
            try
            {
                IMongoClient client = new MongoClient(_connectionString);
                _database = client.GetDatabase(_databaseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _hasError = true;
            }
        }

        public IMongoCollection<Airport> Airports
        {
            get { return _database.GetCollection<Airport>("airports"); }
        }
    }
}