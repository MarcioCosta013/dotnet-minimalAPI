# Minimal API - Projeto de Gerenciamento de Veículos (Em andamento...)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)


Este projeto é uma aplicação **Minimal API** desenvolvida em .NET 9, com autenticação JWT, integração com MySQL e testes automatizados utilizando MSTest. O objetivo é fornecer uma API simples e eficiente para cadastro e gerenciamento de administradores e veículos.

---

## Sumário

- [Funcionalidades](#funcionalidades)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Tecnologias e Dependências](#tecnologias-e-dependências)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Como Rodar](#como-rodar)
- [Testes](#testes)
- [Endpoints Principais](#endpoints-principais)
- [Licença](#licença)

---

## Funcionalidades

- Cadastro, autenticação e listagem de administradores.
- Cadastro, atualização, listagem e remoção de veículos.
- Autenticação JWT com controle de acesso por perfil (Adm, Editor).
- Documentação automática via Swagger.
- Testes automatizados de unidade e integração.

---

## Estrutura de Pastas

```
minimal-api/
├── Api/
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── minimal-api.csproj
│   ├── Program.cs
│   ├── README.md
│   ├── Startup.cs
│   ├── Dominio/
│   │   ├── DTOs/
│   │   ├── Entidades/
│   │   ├── Enuns/
│   │   ├── Interfaces/
│   │   ├── ModelViews/
│   │   └── Servicos/
│   ├── Infraestrutura/
│   │   └── Db/
│   ├── Migrations/
│   ├── Properties/
│   └── bin/ e obj/
├── Test/
│   ├── appsettings.Test.json
│   ├── minimal_api.dump.sql
│   ├── MSTestSettings.cs
│   ├── test.csproj
│   ├── Domain/
│   │   ├── Entidades/
│   │   └── Servicos/
│   ├── Helpers/
│   ├── Mocks/
│   ├── Requests/
│   └── TestResults/
├── minimal-api.sln
└── README.md
```

---

## Tecnologias e Dependências

### Backend

- [.NET 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Entity Framework Core 9.0.0](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
- [Pomelo.EntityFrameworkCore.MySql 9.0.0](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql)
- [Microsoft.AspNetCore.Authentication.JwtBearer 9.0.0](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
- [Swashbuckle.AspNetCore 9.0.4](https://www.nuget.org/packages/Swashbuckle.AspNetCore)

### Testes

- [Microsoft.NET.Test.Sdk 17.12.0](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk)
- [MSTest 3.6.4](https://www.nuget.org/packages/MSTest)
- [Microsoft.AspNetCore.Mvc.Testing 9.0.9](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing)

---

## Instalação

1. **Clone o repositório:**

   ```sh
   git clone https://github.com/seu-usuario/minimal-api.git
   cd minimal-api
   

2. **Instale o .NET 9.0 SDK:**
Download .NET 9.0

3. **Restaure as dependências:**

    ```sh
    dotnet restore

4. **Configure o banco de dados MySQL:**
    - Crie um banco chamado minimal_api (produção) e minimal_apitest (testes).
    - Atualize usuário/senha em Api/appsettings.json e Test/appsettings.Test.json conforme necessário.

5. **Execute as migrações para criar as tabelas:**

    ```sh
    dotnet ef database update --project Api

## Configuração

- **Configuração de conexão:**

    Edite os arquivos appsettings.json e appsettings.Test.json para ajustar a string de conexão do MySQL.

- **Variáveis de ambiente:**

    O ambiente padrão é Development. Para rodar testes, o ambiente é Testing.

## Como Rodar

API

```sh
dotnet run --project Api

```

Acesse http://localhost:5038/swagger para visualizar a documentação interativa.

Testes

```sh
dotnet test Test
```

## Endpoints Principais

- ``POST /administradores/login ``- Autenticação de administrador
- ``GET /administradores`` - Listagem de administradores (requer token)
- ``POST /administradores ``- Cadastro de administrador (requer token)
- ``GET /administrador/{id}`` - Busca administrador por ID (requer token)
- ``POST /veiculos`` - Cadastro de veículo (requer token)
- ``GET /veiculos`` - Listagem de veículos (requer token)
- ``GET /veiculos/{id}`` - Busca veículo por ID (requer token)
- ``PUT /veiculos/{id}`` - Atualização de veículo (requer token)
- ``DELETE /veiculos/{id}`` - Remoção de veículo (requer token)

## Licença

Este projeto está sob a licença MIT.