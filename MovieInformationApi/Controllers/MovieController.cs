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
        [Authorize]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<MovieDTO>))]
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
                
                var response = new SuccessResponseDTO<MovieDTO>
                {
                    Content = _mapper.Map<MovieDTO>(movie),
                    Message = "Movie found"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message});
            }
        }

        [HttpPost]
        [Authorize]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<MovieDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Post([FromBody] MovieDTO movie)
        {
            try
            {
                var movieModel = _mapper.Map<Movie>(movie);
                var movieResponse = await _movieService.AddAsync(movieModel);
                
                if(movieResponse is null) return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = "Movie not added" });
                
                var response = new SuccessResponseDTO<MovieDTO>
                {
                    Content = _mapper.Map<MovieDTO>(movie),
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
        [Authorize]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<SuccessStatusDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] MovieDTO movie)
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
        [Authorize]
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
