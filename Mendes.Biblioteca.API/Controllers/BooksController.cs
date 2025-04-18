using Mendes.Biblioteca.Application.Services;
using Mendes.Biblioteca.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.Biblioteca.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase {
        private readonly BookService _bookService;

        public BooksController(BookService bookService) {
            _bookService = bookService;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks() {
            try {
                var books = await _bookService.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(Guid id) {
            try {
                var book = await _bookService.GetBookByIdAsync(id);

                if (book == null) {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto createBookDto) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                var book = await _bookService.CreateBookAsync(createBookDto);

                // Retorna a URL do novo recurso criado
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, [FromBody] UpdateBookDto updateBookDto) {
            if (id != updateBookDto.Id) {
                return BadRequest("IDs não coincidem.");
            }

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                var bookUpdated = await _bookService.UpdateBookAsync(updateBookDto);

                if (bookUpdated == null) {
                    return NotFound();
                }

                return NoContent();  // 204 No Content: atualização bem-sucedida
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id) {
            try {
                var deleted = await _bookService.DeleteBookAsync(id);

                if (!deleted) {
                    return NotFound();
                }

                return NoContent();  // 204 No Content: recurso deletado com sucesso
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
