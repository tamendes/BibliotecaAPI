using Mendes.Biblioteca.Domain.Entities;
using Mendes.Biblioteca.Domain.Interfaces;
using Mendes.Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Biblioteca.Infrastructure.Repositories {
    public class BookRepository : IBookRepository {
        private readonly BibliotecaDbContext _context;

        public BookRepository(BibliotecaDbContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public async Task<Book> GetByIdAsync(Guid id) => await _context.Books.FindAsync(id);

        public async Task AddAsync(Book book) {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book) {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id) {
            var book = await _context.Books.FindAsync(id);
            if (book != null) {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
