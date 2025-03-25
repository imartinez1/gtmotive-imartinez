using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.Infrastructure
{
    /// <summary>
    /// SqlServerContainerFixture.
    /// </summary>
    public class SqlServerContainerFixture : IAsyncLifetime
    {
        private readonly MsSqlContainer _container;

        public SqlServerContainerFixture()
        {
            _container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-CU13-ubuntu-20.04")
            .Build();
        }

        public string ConnectionString { get; private set; }

        public async Task InitializeAsync()
        {
            await _container.StartAsync();
            ConnectionString = _container.GetConnectionString();

            using var context = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
            await context.Database.MigrateAsync();
        }

        public async Task DisposeAsync()
        {
            await _container.StopAsync();
        }
    }
}
