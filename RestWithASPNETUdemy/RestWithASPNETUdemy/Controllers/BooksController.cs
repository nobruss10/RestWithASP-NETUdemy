using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Interfaces;
using System.Collections.Generic;
using Tapioca.HATEOAS;

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
        [ProducesResponseType(typeof(List<BookVO>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookVO), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            return Ok(_bookService.FindById(id));
        }

        // POST api/Book
        [HttpPost]
        [ProducesResponseType(typeof(BookVO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookService.Create(book));
        }

        // PUT api/Book/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BookVO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put(int id, [FromBody]BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookService.Update(book));
        }

        // DELETE api/Book/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}