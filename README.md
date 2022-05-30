Case: Rota de Viagem
=====================
Escolha a rota de viagem mais barata independente da quantidade de conexões.
Para isso precisamos inserir as rotas.

## Funcionalidades: CRUD de cadastro de ROTAS ##
* Deverá construir um endpoint de CRUD as rotas disponíveis:
```
Origem: GRU, Destino: BRC, Valor: 10
Origem: BRC, Destino: SCL, Valor: 5
Origem: GRU, Destino: CDG, Valor: 75
Origem: GRU, Destino: SCL, Valor: 20
Origem: GRU, Destino: ORL, Valor: 56
Origem: ORL, Destino: CDG, Valor: 5
Origem: SCL, Destino: ORL, Valor: 20
```

## Explicando ## 
Uma viajem de **GRU** para **CDG** existem as seguintes rotas:

1. GRU - BRC - SCL - ORL - CDG ao custo de $40
2. GRU - ORL - CDG ao custo de $61
3. GRU - CDG ao custo de $75
4. GRU - SCL - ORL - CDG ao custo de $45

O melhor preço é da rota **1**, apesar de mais conexões, seu valor final é menor.
O resultado da consulta deve ser: **GRU - BRC - SCL - ORL - CDG ao custo de $40**.

Sendo assim, o endpoint de consulta deverá efetuar o calculo de melhor rota.

## Tecnologias implementadas:

- ASP.NET 3.1
 - ASP.NET WebApi Core
- Entity Framework Core 5.0
- .NET Core Native DI
- AutoMapper
- FluentValidator
- Swagger UI
- .NET DevPack
- In Memory Database
- SQL Server DataBase

## Arquitetura:

- SOLID
- Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Validations
- Repository Pattern

## Como utilizar:
O Projeto é um projeto de código aberto escrito em .NET Core.
- É necessário a versão mais recente do  Visual Studio 2022 e .NET Core SDK.
- A ultima versão do .NET Core SDK está localizada em https://dot.net/core.

Além disso, você pode executar o Projeto no Visual Studio Code (Windows, Linux ou MacOS).

## Banco de Dados:
O Projeto pode ser utilizado com **In Memory Database**.
- É necessário ajustar o arquivo **appsettings.Development** indicado o valor **true** para o campo **InMemoryDatabase**.

O Projeto pode ser utilizado com banco de dados **SQL Server**.
- É necessário ajustar o arquivo **appsettings.Development** indicado o valor **false** para o campo **InMemoryDatabase**.
- É necessário executar o arquivo **Create Table - Script.sql** para a implantação da estrutura no banco.

## Referências:
- The Equinox Project by [Eduardo Pires](https://www.eduardopires.net.br/2016/12/apresentando-o-equinox-project/).
- Começando com .NET Core, com Arquitetura em Camadas por [Alex Alves](https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686#:~:text=Antes%20de%20come%C3%A7ar%2C%20DDD%20n%C3%A3o,%C3%A9%20independente%20da%20tecnologia%20utilizada.).
- Entity Framework Core by [Microsoft](https://docs.microsoft.com/pt-br/ef/core/.).
-  Repository Pattern in ASP.NET Core – Ultimate Guide [Mukesh Murugan](https://docs.microsoft.com/pt-br/ef/core/.).
