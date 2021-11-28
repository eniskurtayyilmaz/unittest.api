#Unittest Api

This repository created for Appcent academy event. [Link](https://kommunity.com/appcent-tech-hub/events/unit-test-d6c32340)
We discussed unit test, mock object and benefit of unit test when refactor processing

![Event](https://media-exp1.licdn.com/dms/image/C4D22AQFXEsBLyfc29w/feedshare-shrink_1280/0/1637824007447?e=1640822400&v=beta&t=pM3VSo85nfmHMdRIYIGtxJSV4RnujkNljs0mHai1q1M)


## 1 - Before to Start

- Install .Net Core 5.0
- Make sure running SQL Server (Dockerized or Already installed)
- Setup your SQL Server environment (Database, ConnectionString)

#### Setup

You need to run SQL Server

If you already have Docker, use below command line to create container
```bash
docker run --name dev_mssql -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

#### ConnectionString _(appsetting.json)_
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