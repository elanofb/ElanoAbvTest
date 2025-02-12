# ElanoAbvTest

## Visão Geral
Este repositório contém a implementação do backend do projeto ElanoAbvTest, utilizando .NET 8.0 e PostgreSQL. O projeto segue a arquitetura Clean Architecture e CQRS.

## Tecnologias Utilizadas

### Backend
- .NET 8.0
- C#
- MediatR (CQRS)
- Entity Framework Core
- AutoMapper
- FluentValidation
- Moq (Testes)
- xUnit (Testes Unitários)
- Rebus (Mensageria com RabbitMQ)
- Docker (Banco de dados PostgreSQL)
- Swagger (Documentação da API)

### Banco de Dados
- PostgreSQL via Docker
- MongoDB (futuro suporte para logs e eventos)

## Estrutura do Projeto
```
ElanoAbvTest/
│── src/
│   ├── Ambev.DeveloperEvaluation.Application/  # Camada de aplicação (CQRS, Handlers)
│   ├── Ambev.DeveloperEvaluation.Common/       # Utilitários e serviços compartilhados
│   ├── Ambev.DeveloperEvaluation.Domain/       # Entidades e regras de negócio
│   ├── Ambev.DeveloperEvaluation.IoC/          # Configuração de Inversão de Controle
│   ├── Ambev.DeveloperEvaluation.ORM/          # Camada de persistência
│   ├── Ambev.DeveloperEvaluation.WebApi/       # API e Controllers
│── tests/
│   ├── Ambev.DeveloperEvaluation.Unit/         # Testes unitários
│   ├── Ambev.DeveloperEvaluation.Integration/  # Testes de integração
│   ├── Ambev.DeveloperEvaluation.Functional/   # Testes funcionais
│── docker-compose.yml  # Configuração do Docker
│── README.md
```

## Configuração do Ambiente

### Clonando o Repositório
```bash
git clone https://github.com/elanofb/ElanoAbvTest.git
cd ElanoAbvTest
```

### Configurando o Banco de Dados (PostgreSQL via Docker)
```bash
docker-compose up -d
```
Isso iniciará um container PostgreSQL configurado no `docker-compose.yml`.

### Restaurando Dependências
```bash
dotnet restore
```

### Criando o Banco de Dados e Aplicando Migrations
```bash
dotnet ef database update
```

## Regras de Negócio Implementadas

### Usuários (Users)
- Criar, obter e deletar usuários
- Validações de email, senha e telefone

### Vendas (Sales)
- Criar, obter e deletar vendas
- Validação de quantidade e descontos

### Itens da Venda (SaleItems)
- Descontos automáticos baseados na quantidade:
  - 4+ unidades: 10% de desconto
  - 10 a 20 unidades: 20% de desconto
  - Máximo de 20 unidades por produto

## Execução da Aplicação

### Rodar a Aplicação
```bash
dotnet run --project src/Ambev.DeveloperEvaluation.WebApi
```

### Acessar a API via Swagger
```
http://localhost:5000/swagger
```

## Testes Unitários e de Integração

### Executar Testes Unitários
```bash
dotnet test tests/Ambev.DeveloperEvaluation.Unit
```

### Executar Testes de Integração
```bash
dotnet test tests/Ambev.DeveloperEvaluation.Integration
```

## Mensageria com Rebus (RabbitMQ)

### Configurar RabbitMQ no Docker
```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

### Registrar Rebus no Program.cs
```csharp
builder.Services.AddRebus(configure => configure
    .Transport(t => t.UseRabbitMq("amqp://guest:guest@localhost", "sales_queue"))
    .Logging(l => l.Console()));
```

### Iniciar Rebus na Aplicação
```csharp
using (var scope = app.Services.CreateScope())
{
    var bus = scope.ServiceProvider.UseRebus();
}
```

## Deploy e CI/CD

### Criar e Publicar a Imagem Docker
```bash
docker build -t takingambevelano-api .
docker run -p 5000:80 takingambevelano-api
```

### CI/CD com GitHub Actions (Exemplo `ci.yml`)
```yaml
name: .NET Build & Test
on: [push]
jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0'
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Test
        run: dotnet test --no-build --verbosity normal
```

## Conclusão
Este documento cobre todo o processo desde a instalação, configuração, execução, testes e deploy do projeto ElanoAbvTest. Se houver dúvidas, consulte os arquivos-fonte ou documentações adicionais.

Contato: elanofb@gmail.com 
