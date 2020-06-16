using ApiMongoDB.Model;
using ApiMongoDB.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(_bookService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            return Created("/", _bookService.Create(book));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book bookIn)
        {
            _bookService.Update(bookIn);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(long id)
        {
            _bookService.Remove(id);
            return Ok();
        }
    }
}