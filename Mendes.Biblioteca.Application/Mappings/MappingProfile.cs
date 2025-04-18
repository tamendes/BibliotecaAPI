using AutoMapper;
using Mendes.Biblioteca.Application.DTOs;
using Mendes.Biblioteca.Domain.Entities;

namespace Mendes.Biblioteca.Application.Mappings {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
