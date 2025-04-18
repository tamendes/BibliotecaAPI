using Mendes.Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Biblioteca.Infrastructure.Data {
    public class BibliotecaDbContext : DbContext {
        public DbSet<Book> Books { get; set; }

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options) { }
    }
}
