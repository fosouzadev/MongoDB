using ApiMongoDB.Model;
using ApiMongoDB.Repository;
using System.Collections.Generic;

namespace ApiMongoDB.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> Get()
        {
            return _bookRepository.Get();
        }

        public Book Get(long id)
        {
            return _bookRepository.Get(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public void Update(Book bookIn)
        {
            _bookRepository.Update(bookIn);
        }

        public void Remove(long id)
        {
            _bookRepository.Remove(id);
        }
    }
}