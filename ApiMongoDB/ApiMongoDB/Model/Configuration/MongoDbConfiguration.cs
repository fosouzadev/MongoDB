namespace ApiMongoDB.Model.Configuration
{
    public class MongoDbConfiguration : IMongoDbConfiguration
    {
        public string Server { get; set; }
        public string Database { get; set; }
    }
}