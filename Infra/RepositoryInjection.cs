using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class RepositoryInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
            serviceCollection.AddScoped<IActorRepository, ActorRepository>();
            serviceCollection.AddScoped<IMovieRatingRepository, MovieRatingRepository>();
            return serviceCollection;
        }
    }
}
