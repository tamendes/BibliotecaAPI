
using Mendes.Biblioteca.Infrastructure.Data;
using Mendes.Biblioteca.Application.Mappings;
using Mendes.Biblioteca.Domain.Interfaces;
using Mendes.Biblioteca.Infrastructure.Repositories;
using Mendes.Biblioteca.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Mendes.Biblioteca.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // DbContext
            builder.Services.AddDbContext<BibliotecaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Dependências
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<BookService>();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title = "Biblioteca API",
                    Version = "v1"
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
