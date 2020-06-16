using ApiMongoDB.Model;
using ApiMongoDB.Model.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApiMongoDB.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        private readonly string _collectionName = "Books";

        public BookRepository(IMongoDbConfiguration mongoDbConfiguration)
        {
            MongoClient mongoClient = new MongoClient(mongoDbConfiguration.Server);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoDbConfiguration.Database);

            _books = mongoDatabase.GetCollection<Book>(_collectionName);
        }

        public IEnumerable<Book> Get()
        {
            return _books.Find(book => true).ToEnumerable();
        }

        public Book Get(long id)
        {
            return _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(Book bookIn)
        {
            _books.ReplaceOne(book => book.Id == bookIn.Id, bookIn);
        }

        public void Remove(long id)
        {
            _books.DeleteOne(book => book.Id == id);
        }
    }
}