#Unittest Api

This repository created for Appcent academy event. [Link](https://kommunity.com/appcent-tech-hub/events/unit-test-d6c32340)
We discussed unit test, mock object and benefit of unit test when refactor processing 

## Before to Start

- Install .Net Core 5.0
- Make sure running SQL Server (Dockerized or Already installed)
- Setup your SQL Server environment (Database, ConnectionString)

#### Setup

You need to run SQL Server

If you already have Docker, use above command line to create container
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
