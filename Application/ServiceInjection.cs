
using Application.Service.Implementation;
using Application.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieRatingService, MovieRatingService>();
            serviceCollection.AddScoped<IMovieService, MovieService>();
            serviceCollection.AddScoped<IActorService, ActorService>();
            return serviceCollection;
        }
    }
}
