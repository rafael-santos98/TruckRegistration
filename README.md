Case: Truck Registration
=====================
As a user, I need a truck register, where I can:
- View registered trucks;
- The minimum truck properties must be:
     - Model (You can only accept FH and FM)
     - Year of Manufacture (Year must be current)
     - Model Year (Can be current or subsequent year)
- Update a truck's information;
- Delete a truck;
- Insert a new truck.

There may be several models of trucks.
-   The models allowed will be only (FH and FM)


## Technologies implemented:

- ASP.NET 3.1
 - ASP.NET WebApi Core
- Entity Framework Core 5.0 With Migrations
- .NET Core Native DI
- AutoMapper
- FluentValidator
- Swagger UI
- .NET DevPack

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- ***Please check if you have installed the same runtime version (SDK) described in global.json***
- The latest SDK and tools can be downloaded from https://dot.net/core.

Also you can run the Equinox Project in Visual Studio Code (Windows, Linux or MacOS).

To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

Além disso, você pode executar o Projeto no Visual Studio Code (Windows, Linux ou MacOS).

## Database:
O Projeto pode ser utilizado com **In Memory Database**.
- É necessário ajustar o arquivo **appsettings.Development** indicado o valor **true** para o campo **InMemoryDatabase**.

O Projeto pode ser utilizado com banco de dados **SQL Server**.
- É necessário ajustar o arquivo **appsettings.Development** indicado o valor **false** para o campo **InMemoryDatabase**.
- É necessário executar o arquivo **Create Table - Script.sql** para a implantação da estrutura no banco.

## References:
- The Equinox Project by [Eduardo Pires](https://www.eduardopires.net.br/2016/12/apresentando-o-equinox-project/).
- Começando com .NET Core, com Arquitetura em Camadas por [Alex Alves](https://alexalvess.medium.com/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686#:~:text=Antes%20de%20come%C3%A7ar%2C%20DDD%20n%C3%A3o,%C3%A9%20independente%20da%20tecnologia%20utilizada.).
- Entity Framework Core by [Microsoft](https://docs.microsoft.com/pt-br/ef/core/.).
-  Repository Pattern in ASP.NET Core – Ultimate Guide [Mukesh Murugan](https://docs.microsoft.com/pt-br/ef/core/.).
