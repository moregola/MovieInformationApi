using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.BuildConfig
{
    public static class AutoMapperInjection
    {
        public static void AddAutoMapperInjection(this IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                cfg.CreateMap<Actor, ActorEntity>()
                    .ReverseMap();
                
                cfg.CreateMap<Movie, MovieEntity>()
                    .ReverseMap();

                cfg.CreateMap<MovieRating, MovieEntity>()
                    .ReverseMap();
            });

            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
