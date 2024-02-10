using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Model;
using BookStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookController> _logger;

        public BookController(
            IBookRepository bookRepository,
            ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookDetailsById(int id)
        {
            var book = await _bookRepository.GetBookDetailsById(id);
            if (book == null)
            {
                return NoContent();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
        {
            var id = await _bookRepository.CreateBook(model);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto model, int id)
        {
            var result = await _bookRepository.UpdateBook(id, model);
            if (!result)
            {
                return BadRequest("This book is not exist !!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook(int id)
        {
            var result = await _bookRepository.RemoveBook(id);
            if (!result)
            {
                return BadRequest("This book is not exist !!");
            }
            return Ok(result);
        }
    }
}
