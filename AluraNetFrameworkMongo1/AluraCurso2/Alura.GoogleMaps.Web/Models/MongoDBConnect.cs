using MongoDB.Driver;
using System;


namespace Alura.GoogleMaps.Web.Models
{
    public class MongoDBConnect
    {
        private string _connectionString = "CONNECTION_STRING";
        private string _databaseName = "geo";

        private IMongoDatabase _database;

        public MongoDBConnect()
        {
            try
            {
                IMongoClient client = new MongoClient(_connectionString);
                _database = client.GetDatabase(_databaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoCollection<Airport> Airports
        {
            get { return _database.GetCollection<Airport>("airports"); }
        }
    }
}