using Application.Service.Interface;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieInformationApi.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieInformationApi.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;   
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<CompleteMovieDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var movie = await _movieService.GetAsync(id);
                
                if (movie is null)
                {
                    return new NoContentResult();
                }
                
                var response = new SuccessResponseDTO<CompleteMovieDTO>
                {
                    Content = _mapper.Map<CompleteMovieDTO>(movie),
                    Message = "Movie found"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message});
            }
        }

        [HttpGet("all")]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<CompleteMovieDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var movies = await _movieService.GetAllAsync(10,0);

                if (movies is null)
                {
                    return new NoContentResult();
                }

                var response = new SuccessResponseDTO<IEnumerable<CompleteMovieDTO>>
                {
                    Content = movies.Select(movie => _mapper.Map<CompleteMovieDTO>(movie)).ToList(),
                    Message = "Movie found"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<CompleteMovieDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CompleteMovieDTO movie)
        {
            try
            {
                var movieModel = new Movie(Guid.NewGuid())
                {
                    Description = movie.Description,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    MovieRating = new MovieRating(Guid.NewGuid())
                    {
                        Rating = movie.MovieRating.Rating
                    },
                    Producer = movie.Producer,
                    Actors = movie.Actors.Select(actor => new Actor(Guid.NewGuid())
                    {
                        Name = actor.Name,
                        BirthDate = actor.BirthDate,
                        Age = actor.Age,
                        City = actor.City,
                        Country = actor.Country,
                        Nationality = actor.Nationality,
                        State = actor.State
                    }).ToList()
                };
                var movieResponse = await _movieService.AddAsync(movieModel);
                
                if(movieResponse is null) return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = "Movie not added" });
                
                var response = new SuccessResponseDTO<CompleteMovieDTO>
                {
                    Content = _mapper.Map<CompleteMovieDTO>(movie),
                    Message = "Success"
                };

                return new OkObjectResult(response);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<SuccessStatusDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CompleteMovieDTO movie)
        {
            try
            {
                var movieModel = _mapper.Map<Movie>(movie);
                var response = new SuccessResponseDTO<SuccessStatusDTO>
                {
                    Content = new SuccessStatusDTO
                    {
                        Status = await _movieService.UpdateAsync(movieModel)
                    },
                    Message = "Success"
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<SuccessStatusDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var response = new SuccessResponseDTO<SuccessStatusDTO>
                {
                    Content = new SuccessStatusDTO
                    { 
                        Status = await _movieService.DeleteAsync(id)
                    },
                    Message = "Success"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }
    }
}
