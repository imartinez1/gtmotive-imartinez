using Microsoft.Extensions.Hosting;

namespace GtMotive.Estimate.Microservice.Host.Extensions
{
    /// <summary>
    /// HostingEnvironmentExtensions.
    /// </summary>
    internal static class HostingEnvironmentExtensions
    {
        public static bool IsTesting(this IHostEnvironment env)
        {
            return env.EnvironmentName == "Testing";
        }
    }
}
