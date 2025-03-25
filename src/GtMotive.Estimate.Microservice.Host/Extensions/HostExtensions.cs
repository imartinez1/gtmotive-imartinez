using System;
using System.Linq;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GtMotive.Estimate.Microservice.Host.Extensions
{
    /// <summary>
    /// HostExtensions.
    /// </summary>
    internal static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
            where TContext : ApplicationDbContext
        {
            ArgumentNullException.ThrowIfNull(host);

            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            return host;
        }
    }
}
