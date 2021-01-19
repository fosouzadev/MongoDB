using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AluraCurso1
{
    public class MongoDB
    {
        private string _connectionString = "mongodb://LearningUser:2VECYyiQ9NfRG49D@learningcluster0-shard-00-00.5xgx4.mongodb.net:27017,learningcluster0-shard-00-01.5xgx4.mongodb.net:27017,learningcluster0-shard-00-02.5xgx4.mongodb.net:27017/library?ssl=true&replicaSet=atlas-xtmsgr-shard-0&authSource=admin&retryWrites=true&w=majority";
        private string _databaseName = "library";
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

        public async Task InsertOneBookWithBson(Book book)
        {
            if (_hasError)
                return;

            BsonDocument bson = new BsonDocument
            {
                { nameof(book.Titulo), book.Titulo },
                { nameof(book.Autor), book.Autor }
            };

            bson.Add(nameof(book.Ano), book.Ano);
            bson.Add(nameof(book.Paginas), book.Paginas);

            var assuntos = new BsonArray();

            foreach (var item in book.Assunto)
                assuntos.Add(item);

            bson.Add(nameof(book.Assunto), assuntos);

            IMongoCollection<BsonDocument> collectionBooks = _database.GetCollection<BsonDocument>("books");
            await collectionBooks.InsertOneAsync(bson);
        }

        public async Task InsertOneBook(Book book)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.InsertOneAsync(book);
        }

        public async Task InsertManyBooks(Book[] books)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.InsertManyAsync(books);
        }

        public async Task<IEnumerable<Book>> FindAll()
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(new BsonDocument());
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindByAutor(string autor)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(new BsonDocument()
            {
                {  nameof(Book.Autor), autor }
            });
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindByAutorWithBuilders(string autor)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(Builders<Book>.Filter.Eq(x => x.Autor, autor));
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindYearGteWithBuilders(int year)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(Builders<Book>.Filter.Gte(x => x.Ano, year));
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindYearGteAndPagesGteWithBuilders(int year, int pages)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(
                Builders<Book>.Filter.Gte(x => x.Ano, year) &
                Builders<Book>.Filter.Gte(x => x.Paginas, pages)
            );
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindSubjectWithBuilders(string subject)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = await collectionBooks.FindAsync(Builders<Book>.Filter.AnyEq(x => x.Assunto, subject));
            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindAllSortByTitle()
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = collectionBooks.Find(new BsonDocument()).SortBy(s => s.Titulo);

            return await books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> FindAllLimit(int limit)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            var books = collectionBooks.Find(new BsonDocument()).Limit(limit);

            return await books.ToListAsync();
        }

        public async Task<Book> FindByTitle(string title)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            return await collectionBooks.Find(new BsonDocument() { { nameof(Book.Titulo), title } }).FirstOrDefaultAsync();
        }

        public async Task UpdateOne(BsonDocument filter, Book book)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.ReplaceOneAsync(filter, book);
        }

        public async Task UpdateYear(string title, int year)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.UpdateOneAsync(
                Builders<Book>.Filter.Eq(x => x.Titulo, title),
                Builders<Book>.Update.Set(x => x.Ano, year));
        }

        public async Task UpdateManyYearEq(int year)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.UpdateManyAsync(
                Builders<Book>.Filter.Eq(x => x.Ano, year),
                Builders<Book>.Update.Set(x => x.Ano, year + 5));
        }

        public async Task DeleteMany(BsonDocument filter)
        {
            IMongoCollection<Book> collectionBooks = _database.GetCollection<Book>("books");
            await collectionBooks.DeleteManyAsync(filter);
        }
    }
}