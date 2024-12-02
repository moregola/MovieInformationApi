using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.BuildConfig
{
    public static class ApplicationDbBuilder
    {
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseInMemoryDatabase("Movie Rating API"),
                ServiceLifetime.Transient
                );
        }
    }
}