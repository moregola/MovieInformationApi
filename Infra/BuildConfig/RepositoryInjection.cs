using Microsoft.Extensions.DependencyInjection;

namespace Infra.BuildConfig
{
    public static class RepositoryInjection
    {
        //TODO: Dont forget to put the new repositories here

        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {

            return serviceCollection;
        }
    }
}
