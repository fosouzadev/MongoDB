namespace ApiMongoDB.Model.Configuration
{
    public interface IMongoDbConfiguration
    {
        public string Server { get; set; }
        public string Database { get; set; }
    }
}