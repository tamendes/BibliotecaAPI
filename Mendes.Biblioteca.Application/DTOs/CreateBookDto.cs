﻿namespace Mendes.Biblioteca.Application.DTOs {
    public class CreateBookDto {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
