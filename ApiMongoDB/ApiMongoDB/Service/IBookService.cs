using ApiMongoDB.Model;
using System.Collections.Generic;

namespace ApiMongoDB.Service
{
    public interface IBookService
    {
        public IEnumerable<Book> Get();
        public Book Get(long id);
        public Book Create(Book book);
        public void Update(Book bookIn);
        public void Remove(long id);
    }
}