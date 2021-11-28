// using System.Threading.Tasks;
// using DotNet.Testcontainers.Containers.Builders;
// using DotNet.Testcontainers.Containers.Configurations.Databases;
// using DotNet.Testcontainers.Containers.Modules.Databases;
// using DotNet.Testcontainers.Containers.WaitStrategies;
// using FluentMigrator.Runner;
// using Microsoft.Extensions.DependencyInjection;
// using Unittest.Api.Migrations;
// using Unittest.Api.Repositories;
// using Xunit;
//
// namespace Unittest.Tests.Repositories
// {
//     [CollectionDefinition("DatabaseTestsCollection")]
//     public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
//     {
//     }
//     
//     public class DatabaseFixture : IAsyncLifetime
//     {
//         public IDatabaseConnectionFactory Factory { get; private set; }
//         private MsSqlTestcontainer _msSqlTestContainer;
//
//         public async Task InitializeAsync()
//         {
//             var containerBuilder = new TestcontainersBuilder<MsSqlTestcontainer>()
//                 .WithDatabase(new MsSqlTestcontainerConfiguration
//                 {
//                     Password = "yourStrong(!)Password"
//                 })
//                 .WithPortBinding(1435)
//                 .WithExposedPort(1435)
//                 .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1435));
//             _msSqlTestContainer = containerBuilder.Build();
//             await _msSqlTestContainer.StartAsync();
//             var serviceProvider = new ServiceCollection()
//                 .AddFluentMigratorCore()
//                 .ConfigureRunner(rb => rb
//                     .AddSqlServer()
//                     .WithGlobalConnectionString(
//                         _msSqlTestContainer.ConnectionString)
//                     .ScanIn(typeof(AddCustomerTable).Assembly).For.Migrations())
//                 .AddLogging(lb => lb.AddFluentMigratorConsole())
//                 .BuildServiceProvider(false);
//             var scope = serviceProvider.CreateScope();
//             var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
//             runner.MigrateUp();
//             Factory = new SqlConnectionFactory(_msSqlTestContainer.ConnectionString);
//         }
//
//         public async Task DisposeAsync()
//         {
//             await _msSqlTestContainer.StopAsync();
//         }
//     }
// }