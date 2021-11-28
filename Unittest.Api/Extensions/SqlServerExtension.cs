using System;
using System.Linq;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.VisualBasic;
using Unittest.Api.Repositories;

namespace Unittest.Api.Extensions
{
    public static class SqlServerExtension
    {
        
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration,
            string applicationName)
        {
            var connectionString = configuration.GetConnectionString(DatabaseConnectionStringKey);
            if (string.IsNullOrEmpty(connectionString)) return;
            services.AddSingleton<IDatabaseConnectionFactory>(e =>
                new SqlConnectionFactory(connectionString));
            services.AddHealthChecks().AddSqlServer(
                connectionString,
                "SELECT 1;",
                "Sql Server",
                HealthStatus.Degraded,
                timeout: TimeSpan.FromSeconds(30),
                tags: new[] {"db", "sql", "sqlServer",});

            AddMigration(configuration, applicationName);
        }

        private static string DatabaseConnectionStringKey => "AppDbContext";

        private static void AddMigration(IConfiguration configuration, String appName)
        {
            var asm = Assembly.Load(appName);
            var classes = asm.GetTypes().Where(p =>
                p.Namespace == $"{appName}.Migrations"
            ).ToList();
            if (classes.Count == 0)
            {
                return;
            }

            var scopedService = new ServiceCollection().AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(
                        configuration.GetConnectionString(DatabaseConnectionStringKey))
                    .ScanIn(classes[0].Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

            var runner = scopedService.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}