using System.ComponentModel.DataAnnotations;

namespace Mendes.Biblioteca.Domain.Entities {
    public class Book {
        [Key]
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public Book(string title, string author, int year) {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Year = year;
        }

        public void Update(string title, string author, int year) {
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
