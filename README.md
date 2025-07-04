# MinimalAPIKickoff
A professional-ready template for building .NET Minimal API applications with a clean architecture approach. Includes built-in configuration for persistence, logging, unit testing, and CI/CD pipelines — so you can focus on business logic from day one.

## 🚀 Features

- ✅ **.NET 8 Minimal API** with:
  - Built-in **Swagger**
  - Custom error handling middleware using **Problem Details (RFC 7807)**
- 🗂️ **Clean Architecture** separation:
  - `Api`, `Domain`, `Application`, `Infrastructure`, and `Tests`
- 💾 **EF Core** with SQL Server:
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

MyApiTemplate/
├── .github/workflows/ci.yml # CI/CD pipeline
├── docker-compose.yml # Optional DB or services
├── Dockerfile # Container build
├── YourApp.Api/ # Minimal API entrypoint
│ ├── Program.cs
│ └── Endpoints/
├── YourApp.Domain/ # Domain models and rules
│ └── Entities/
├── YourApp.Application/ # Use cases and business logic
│ └── Services/
├── YourApp.Infrastructure/ # DB access, EF Core config
│ ├── Data/
│ └── Migrations/
├── YourApp.Tests/ # Unit + Integration tests
│ ├── Unit/
│ └── Integration/
└── README.md


## 🧱 Project Structure