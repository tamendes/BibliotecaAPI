using Mendes.Biblioteca.Application.DTOs;
using Mendes.Biblioteca.Domain.Entities;
using Mendes.Biblioteca.Domain.Interfaces;
using AutoMapper;

namespace Mendes.Biblioteca.Application.Services {
    public class BookService {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // Get all books
        public async Task<IEnumerable<BookDto>> GetAllBooksAsync() {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        // Get book by ID
        public async Task<BookDto> GetBookByIdAsync(Guid id) {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null) return null;

            return _mapper.Map<BookDto>(book);
        }

        // Create a new book
        public async Task<BookDto> CreateBookAsync(CreateBookDto createBookDto) {
            var book = new Book(createBookDto.Title, createBookDto.Author, createBookDto.Year);
            await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(book);
        }

        // Update an existing book
        public async Task<BookDto> UpdateBookAsync(UpdateBookDto updateBookDto) {
            var book = await _bookRepository.GetByIdAsync(updateBookDto.Id);

            if (book == null) return null;
            
            book.Update(updateBookDto.Title, updateBookDto.Author, updateBookDto.Year);
            await _bookRepository.UpdateAsync(book);
            return _mapper.Map<BookDto>(book);
        }

        // Delete a book
        public async Task<bool> DeleteBookAsync(Guid id) {
            var book = await _bookRepository.GetByIdAsync(id);

            if (book == null) return false;

            await _bookRepository.DeleteAsync(book.Id);
            return true;
        }
    }
}
