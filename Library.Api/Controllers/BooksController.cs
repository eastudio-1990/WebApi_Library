using Library.Application.Interfaces;
using Library.Core;
using Library.Core.DTO;
using Library.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // GET /api/books
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookService.GetByIdAsync(id);
                if (book == null)
                {
                    return NotFound("Book not found.");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST /api/books
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook([FromBody] CreateUpdateBookDto _book)
        {
            if (_book == null)
            {
                _logger.LogError(LoggerEnums.LogMessage.Warning.ToString() + " " + "Null Request");
                return BadRequest("Book cannot be null.");
            }

            var book = new Book
            {
                Title = _book.Title,
                Author = _book.Author,
                ISBN = _book.ISBN,
                PublishedDate = _book.PublishedDate,
            };

            try
            {
                await _bookService.AddAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + ex.Message);
                return NotFound(new { message = ex.Message });
            }
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] CreateUpdateBookDto _book)
        {
            if (_book == null || _book.Id != id)
            {
                _logger.LogError(LoggerEnums.LogMessage.Warning.ToString() + " " + "Book ID mismatch or Null Request");
                return BadRequest("Book ID mismatch or book is null.");
            }

            try
            {
                var existingBook = await _bookService.GetByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound("Book not found.");
                }

                var book = new Book
                {
                    Id = id,
                    Title = _book.Title,
                    Author = _book.Author,
                    ISBN = _book.ISBN,
                    PublishedDate = _book.PublishedDate,
                };

                await _bookService.UpdateAsync(book);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var existingBook = await _bookService.GetByIdAsync(id);
                if (existingBook == null)
                {
                    return NotFound("Book not found.");
                }

                await _bookService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(LoggerEnums.LogMessage.Error.ToString() + " " + ex.Message);
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
