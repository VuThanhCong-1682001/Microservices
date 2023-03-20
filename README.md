## AspnetCore Microservices:
A large numerous developers have heard about microservices and how it is the next big thing. In any case, for some developers I have coporate with, microservices is simply one more popular expression like DevOps. I have been dealing with various tasks involving microservices for somewhat more than a year now and here, I might want to discuss the hypothesis and the thoughts behind the idea. I built this course to help developers narrow down your challenges with my reality experiences.

## Prepare environment

* Install dotnet core version in file `global.json`
* IDE: Visual Studio 2022+, Rider, Visual Studio Code
* Docker Desktop

* EF Core tools reference (.NET CLI):
```Powershell
dotnet tool install --global dotnet-ef
```
---
## Warning:

Some docker images are not compatible with Apple Chip (M1, M2). You should replace them with appropriate images. Suggestion images below:
@@ -31,13 +36,19 @@ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remo
```

## Application URLs - LOCAL Environment (Docker Container):
- Identity API: http://localhost:6001
- Product API: http://localhost:6002/api/products
- Customer API: http://localhost:6003/api/customers
- Basket API: http://localhost:6004/api/baskets
- Order API: http://localhost:6005/api/v1/orders
- Inventory API: http://localhost:6006/api/inventory
- Inventory GRPC: http://localhost:6007
- Scheduled Job API: http://localhost:6008
- Ocelot Api Gateway: http://localhost:6020
- Webstatus Health Check: http://localhost:6010

## Docker Application URLs - LOCAL Environment (Docker Container):
- Portainer: http://localhost:9000 - username: admin ; pass: admin1234
- Portainer: http://localhost:9000 - username: admin ; pass: "{your-password}"
- Kibana: http://localhost:5601 - username: elastic ; pass: admin
- RabbitMQ: http://localhost:15672 - username: guest ; pass: guest

@@ -46,10 +57,16 @@ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remo
- Run Compound to start multi projects
---
## Application URLs - DEVELOPMENT Environment:
- Identity API: http://localhost:5001
- Product API: http://localhost:5002/api/products
- Customer API: http://localhost:5003/api/customers
- Basket API: http://localhost:5004/api/baskets
- Order API: http://localhost:5005/api/v1/orders
- Inventory API: http://localhost:5006/api/inventory
- Inventory GRPC: http://localhost:5007
- Scheduled Job API: http://localhost:5008
- Ocelot Api Gateway: http://localhost:5020
- Webstatus Health Check: http://localhost:5010
---
## Application URLs - PRODUCTION Environment:

@@ -60,8 +77,28 @@ docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d --remo

- https://dotnet.microsoft.com/download/dotnet/6.0
- https://visualstudio.microsoft.com/
- https://www.jetbrains.com/rider/
- Install dotnet tool install --global dotnet-ef

## References URLS
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-6.0&tabs=visual-studio
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio
- https://docs.microsoft.com/en-us/aspnet/core/grpc/troubleshoot?view=aspnetcore-6.0
- https://github.com/ThreeMammals/Ocelot
- https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/httpclient-message-handlers
- https://github.com/dotnet-architecture/eShopOnContainers

## Docker Commands: (cd into folder contain file `docker-compose.yml`, `docker-compose.override.yml`)

@@ -82,6 +119,6 @@ docker-compose down
- dotnet build
- Migration commands for Ordering API:
  - cd into Ordering folder
  - dotnet ef migrations add "SampleMigration" -p Ordering.Infrastructure --startup-project Ordering.API --output-dir Persistence/Migrations
  - dotnet ef migrations add "SampleMigration" -p Ordering.Infrastructure --startup-project Ordering.API -o Persistence/Migrations
  - dotnet ef migrations remove -p Ordering.Infrastructure --startup-project Ordering.API
  - dotnet ef database update -p Ordering.Infrastructure --startup-project Ordering.API
