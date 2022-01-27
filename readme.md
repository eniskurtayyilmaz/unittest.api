# Unittest Api

This repository created for Appcent academy event. [Link](https://kommunity.com/appcent-tech-hub/events/unit-test-d6c32340)
We discussed unit test, mock object and benefit of unit test when refactor processing

![Event](https://media.kommunity.com/communities/appcent-tech-hub/events/unit-test-d6c32340/27731/kommunity.png?p=event-640)


## 1 - Before to Start

- Install .Net Core 5.0
- Make sure running SQL Server (Dockerized or Already installed)
- Setup your SQL Server environment 
  - Create Database "unittestapi"
  - Make sure correct ConnectionString in appsettings.json

#### Setup

You need to run SQL Server

If you already have Docker, use below command line to create container
```bash
docker run --name dev_mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

#### Create database (unittestapi)
```sql
create database unittestapi
go
 ```

#### ConnectionString _(appsettings.json)_
```json
{
  "ConnectionStrings": {
    "AppDbContext": "Server=localhost,1433;Database=unittestapi;User=sa;Password=yourStrong(!)Password;Trusted_Connection=False;TrustServerCertificate=True;"
  }
}
 ```

#### Launch on Browser _(launchSettings.json)_
Open below link and make sure that **Sql Server is "Healthy"**
```net
http://localhost:4000/health-check
```
```json
{"status":"Healthy","components":[{"key":"Sql Server","value":"Healthy"}]}
 ```


## 2 - What Were We Planned?
- Create test cases
- Mock our dependency injection objects
- Verify untouched objects or methods

## 3 - What Was Used in Our Project?
- Unittest.Api (webapi, .net core 5.0)
  - AspNetCore.HealthChecks.SqlServer
  - FluentMigrator
    - FluentMigrator.Runner
  - FluentValidation
    - FluentValidation.AspNetCore
  - Dapper
- Unittest.Tests (xunit, .net core 5.0)
  - AutoFixture
    - AutoFixture.AutoMoq
  - FluentAssertions
    - FluentMigrator.Runner
  - Moq

#### Buy me a coffee
You can [buy me a coffee](https://www.buymeacoffee.com/eniskurtay) if you want to say _thank you_:) 
