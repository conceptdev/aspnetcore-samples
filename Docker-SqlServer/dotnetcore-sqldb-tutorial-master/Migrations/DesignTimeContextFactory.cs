using System;
using System.IO;
using DotNetCoreSqlDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreSqlDb.Migrations
{
    // https://codingblast.com/entityframework-core-idesigntimedbcontextfactory/
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDatabaseContext>
    {
        public MyDatabaseContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<MyDatabaseContext>();

            var connectionString = configuration.GetConnectionString("MyDbConnection");

            builder.UseSqlServer(connectionString);

            return new MyDatabaseContext(builder.Options);
        }
    }
}
