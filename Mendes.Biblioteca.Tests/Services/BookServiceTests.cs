using AutoMapper;
using Mendes.Biblioteca.Application.Mappings;
using Mendes.Biblioteca.Application.Services;
using Mendes.Biblioteca.Domain.Entities;
using Mendes.Biblioteca.Domain.Interfaces;
using Moq;

namespace Mendes.Biblioteca.Tests.Services {
    public class BookServiceTests {
        private readonly Mock<IBookRepository> _repoMock;
        private readonly IMapper _mapper;
        private readonly BookService _service;

        public BookServiceTests() {
            _repoMock = new Mock<IBookRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
            _service = new BookService(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsList() {
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Book>
            {
                new Book("Title1", "Author1", 2020),
                new Book("Title2", "Author2", 2021)
            });

            var result = await _service.GetAllBooksAsync();

            Assert.Equal(2, result.Count());
        }
    }
}