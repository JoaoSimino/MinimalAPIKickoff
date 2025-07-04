# MinimalAPIKickoff
A professional-ready template for building .NET Minimal API applications with a clean architecture approach. Includes built-in configuration for persistence, logging, unit testing, and CI/CD pipelines — so you can focus on business logic from day one.

## 🚀 Features

- ✅ **.NET 8 Minimal API** with:
  - Built-in **Swagger**
  - Custom error handling middleware using **Problem Details (RFC 7807)**
- 🗂️ **Clean Architecture** separation:
  - `Api`, `Domain`, `Application`, `Infrastructure`, and `Tests`
- 💾 **EF Core** with SQL Server:
  - Package Microsoft.EntityFrameworkCore.SqlServer 
  - Sample `User` entity
  - Pre-configured `DbContext`
  - Connection string in `appsettings.Development.json`
- 📊 **Serilog**:
  - Logging configured with SQL Server sink
- 🧪 **xUnit testing**:
  - Unit and integration tests
  - SQLite InMemory provider
  - CI-integrated with `dotnet test`
- 🔧 **CI/CD with GitHub Actions**:
  - Build, restore, test, publish Docker image or artifacts

## 🧱 Project Structure

```plaintext
MyApiTemplate/
├── .github/workflows/ci.yml
├── docker-compose.yml
├── Dockerfile
├── YourApp.Api/ # Entrypoint da API (Minimal APIs)
│   ├── Program.cs # Configuração e bootstrap da aplicação
│   └── Endpoints/ # Definição dos endpoints da API
├── YourApp.Domain/ # Camada de domínio (entidades e regras de negócio)
│   └── Entities/ # Entidades principais do domínio
├── YourApp.Application/ # Casos de uso e lógica de aplicação
│   └── Services/ # Serviços que orquestram as regras de negócio
├── YourApp.Infrastructure/ # Infraestrutura de persistência e integrações
│   ├── Data/ # Contextos e interfaces de repositórios
│   └── Migrations/ # Arquivos de migração do EF Core
├── YourApp.Tests/ # Testes unitários e de integração
│   ├── Unit/ # Testes unitários
│   └── Integration/ # Testes de integração com o sistema real
└── README.md # Documentação do projeto
```


