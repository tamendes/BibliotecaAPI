# 📚 Biblioteca API

API RESTful para gerenciamento de livros, desenvolvida com .NET 7 utilizando os princípios de Clean Architecture, Domain-Driven Design (DDD), SOLID, AutoMapper, Entity Framework Core, e Swagger.

---

## 🧠 Objetivo

Este projeto tem como objetivo demonstrar a criação de uma API robusta e escalável, seguindo boas práticas de arquitetura de software, visando facilitar manutenção, testes e expansão da aplicação.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 7.0
- Clean Architecture
- DDD (Domain-Driven Design)
- SOLID Principles
- Entity Framework Core
- AutoMapper
- Swagger (Swashbuckle)
- SQL Server
- xUnit + Moq (testes unitários)

---

## 📁 Estrutura do Projeto

```
src/
├── Mendes.Biblioteca.API               # Camada de Apresentação (Controllers, Program.cs, Swagger)
├── Mendes.Biblioteca.Application       # Camada de Aplicação (DTOs, Services, Mapeamentos)
├── Mendes.Biblioteca.Domain            # Camada de Domínio (Entidades, Interfaces)
├── Mendes.Biblioteca.Infrastructure    # Camada de Infraestrutura (EF Core, Repositórios)
└── tests/
    └── Mendes.Biblioteca.Tests         # Testes unitários com xUnit
```

---

## ⚙️ Como executar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/tamendes/BibliotecaAPI.git
cd BibliotecaAPI
```

### 2. Configure a string de conexão

No arquivo `appsettings.json` da API (`Mendes.Biblioteca.API/appsettings.json`):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=Biblioteca;User Id=sa;Password=XXXXXXXXXX;TrustServerCertificate=True;"
}
```

### 3. Crie o banco de dados via Entity Framework

Abra o terminal na pasta do projeto e execute:

```bash
dotnet ef database update --project Mendes.Biblioteca.Infrastructure --startup-project Mendes.Biblioteca.API
```

> Caso não tenha o CLI do EF instalado:
```bash
dotnet tool install --global dotnet-ef
```

### 4. Execute o projeto

```bash
dotnet run --project Mendes.Biblioteca.API
```

Acesse a documentação Swagger em:
```
https://localhost:{porta}/swagger
```

---

## 🔁 Endpoints disponíveis

| Verbo  | Rota            | Descrição                      |
|--------|------------------|-------------------------------|
| GET    | /api/books       | Retorna todos os livros       |
| GET    | /api/books/{id}  | Retorna um livro por ID       |
| POST   | /api/books       | Cria um novo livro            |
| PUT    | /api/books/{id}  | Atualiza um livro existente   |
| DELETE | /api/books/{id}  | Remove um livro por ID        |

> A API retorna status apropriados (200, 201, 204, 404, 500) e mensagens de erro detalhadas.

---

## 🧪 Testes

### Como executar os testes

```bash
dotnet test
```

- Testes implementados com **xUnit**
- Simulações de dependências com **Moq**
- Cobrem cenários da camada de aplicação (services)


---

## 🙋‍♂️ Autor

**Thiago Augusto Mendes**  
👨‍💻 [www.tamendes.com.br](https://www.tamendes.com.br)  
📧 thiago.mendes@tamendes.com.br  
📱 (11) 99180-1557  
🚀 [Thanos Sistemas](https://www.tamendes.com.br)