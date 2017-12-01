# Docker SQL Server instance on macOS

0. Install Visual Studio for Mac (with ASP.NET Core 2.0)
1. Install Docker
2. Install SQL Server for Linux on Docker
3. Run ASP.NET Core with local SQL back-end!
4. Install SQL Operations Studio for Mac
5. Edit and query data with SOS

![Web app](Screenshots/web-app-sml.png)

![SQL Ops Studio](Screenshots/sql-ops-studio-sml.png)

## Guides

* [ASP.NET Core on Visual Studio for Mac](https://docs.microsoft.com/en-us/visualstudio/mac/asp-net-core)
* [Build a .NET Core and SQL Database web app in Azure App Service on Linux](https://docs.microsoft.com/en-us/azure/app-service/containers/tutorial-dotnetcore-sqldb-app)
* [Getting Started with EF Core on ASP.NET Core with a New database](https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db)
* [Quickstart: Connect and query SQL Server using SQL Operations Studio (preview)](https://docs.microsoft.com/en-us/sql/sql-operations-studio/quickstart-sql-server)
* [Download and install Microsoft SQL Operations Studio (preview)](https://docs.microsoft.com/en-us/sql/sql-operations-studio/download)

### bash

#### Setting up Docker

```bash
sudo docker pull microsoft/mssql-server-linux:2017-latest

sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<YourStrong!Passw0rd>' \
   -p 1401:1433 --name sql1 \
   -d microsoft/mssql-server-linux:2017-latest

sudo docker ps -a
```


### Connection String

For both ASP.NET and SQL Operations Studio (warning: using `sa` is not recommended):

```
Server=localhost,1401;Initial Catalog=master;User ID=sa;Password=<YourStrong!Passw0rd>;Persist Security Info=False;
```

Note the port matches what was configured in Docker 1401 on our local machine 
maps to 1433 (the common SQL Server port) in the Docker container. You'll need to 
enter the Connection String in the ASP.NET Core 

#### Setting up the Entity Framework database

Make sure you have opened the solution in Visual Studio for Mac and ensured
the NuGet packages are all up-to-date, the Connection String is correct, and
the solution builds successfully.

Run this command in the .NET Core project directory to configure the database.

```bash
dotnet ef database update
```

You'll probably need to close the solution in Visual Studio for Mac, or
there might be file access errors on the assemblies in the project.

Once the database has been configured, you can run the web site from
Visual Studio for Mac.

#### SQL Operations Studio

You can use the **server:localhost,1401** and login details to access 
the SQL Server instance to interact with the database via T-SQL.


## Tools

* [Visual Studio for Mac](https://www.visualstudio.com/vs/)
* [Docker for Mac](https://www.docker.com/docker-mac) [docs](https://docs.docker.com/docker-for-mac/)
* [Run the SQL Server 2017 container image with Docker](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker)
* [SQL Operations Studio](https://docs.microsoft.com/en-us/sql/sql-operations-studio/what-is)


## Tips

* [Migrating from ASP.NET Core 1.x to ASP.NET Core 2.0](https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/)
* [EntityFramework Core – Add an implementation of IDesignTimeDbContextFactory](https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/)


## Related

* [Visual Studio for Mac hands-on labs](https://github.com/Microsoft/vs4mac-labs)


## Web API & Swagger

The code has been updated to expose database functions via REST:

* [Add Web API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api-mac)
* [Add Swagger](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio-mac)

![Web app](Screenshots/swagger-sml.png)