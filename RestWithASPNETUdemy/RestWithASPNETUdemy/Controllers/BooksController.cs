using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Interfaces;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/V{version:apiVersion}")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/Book
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_bookService.FindById(id));
        }

        // POST api/Book
        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookService.Create(book));
        }

        // PUT api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookService.Update(book));
        }

        // DELETE api/Book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}