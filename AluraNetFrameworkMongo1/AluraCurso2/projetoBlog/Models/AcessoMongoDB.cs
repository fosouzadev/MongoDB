using MongoDB.Driver;
using System;

namespace projetoBlog.Models
{
    public class AcessoMongoDB
    {
        private string _connectionString = "INSERIR_CONNECTION_STRING";
        private string _databaseName = "blogNet";
        private string _collectionUsers = "users";
        private string _collectionPublications = "publications";

        private IMongoClient _client;
        private IMongoDatabase _database;

        public AcessoMongoDB()
        {
            try
            {
                _client = new MongoClient(_connectionString);
                _database = _client.GetDatabase(_databaseName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IMongoCollection<Usuario> Users
        {
            get { return _database.GetCollection<Usuario>(_collectionUsers); }
        }

        public IMongoCollection<Publicacao> Publications
        {
            get { return _database.GetCollection<Publicacao>(_collectionPublications); }
        }
    }
}