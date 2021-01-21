using MongoDB.Driver;
using System;


namespace Alura.GoogleMaps.Web.Models
{
    public class MongoDBConnect
    {
        private string _connectionString = "mongodb://LearningUser:2VECYyiQ9NfRG49D@learningcluster0-shard-00-00.5xgx4.mongodb.net:27017,learningcluster0-shard-00-01.5xgx4.mongodb.net:27017,learningcluster0-shard-00-02.5xgx4.mongodb.net:27017/geo?ssl=true&replicaSet=atlas-xtmsgr-shard-0&authSource=admin&retryWrites=true&w=majority";
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