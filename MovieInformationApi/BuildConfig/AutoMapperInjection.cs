using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using MovieInformationApi.DTO;

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
                .ForMember(e => e.CreateDate, opt => opt.Ignore())
                .ForMember(e => e.UpdateDate, opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<Movie, MovieEntity>()
                .ForMember(e => e.CreateDate, opt => opt.Ignore())
                .ForMember(e => e.UpdateDate, opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<MovieRating, MovieRatingEntity>()
                .ForMember(e => e.CreateDate, opt => opt.Ignore())
                .ForMember(e => e.UpdateDate, opt => opt.Ignore())
                .ReverseMap();

                cfg.CreateMap<Actor, ActorDTO>()
                .ReverseMap();

                cfg.CreateMap<Movie, MovieDTO>()
                .ReverseMap();

                cfg.CreateMap<MovieRating, RatingDTO>()
                .ReverseMap();

            });

            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
