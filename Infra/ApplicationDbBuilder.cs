using Infra.BuildConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class ApplicationDbBuilder
    {
        public static void ConfigureDbContext(this IServiceCollection services, string dbName)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase(dbName);
            });
        }
    }
}