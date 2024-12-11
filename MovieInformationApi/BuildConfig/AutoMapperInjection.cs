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
                .ForMember(e => e.Age, opt => opt.MapFrom<int>(e => e.CalculateAge()))
                .ReverseMap()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Movies, opt => opt.Ignore());

                cfg.CreateMap<Actor, CompleteActorDTO>()
                .ForMember(e => e.Age, opt => opt.MapFrom<int>(e => e.CalculateAge()))
                .ReverseMap();
                
                cfg.CreateMap<Movie, MovieDTO>()
                .ReverseMap()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Actors, opt => opt.Ignore());
                
                cfg.CreateMap<Movie, CompleteMovieDTO>()
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
