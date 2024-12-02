using Application.Service.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using MovieInformationApi.DTO;

namespace MovieInformationApi.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var movie = await _movieService.GetAsync(id);
                return new OkObjectResult(movie);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieDTO movie)
        {
            try
            {
                var movieModel = new Movie(Guid.NewGuid())
                {
                    Name = movie.Name,
                };
                await _movieService.AddAsync(movieModel);
                return new OkObjectResult("ok");

            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] MovieDTO movie)
        {
            try
            {
                var movieModel = new Movie(id)
                {
                    Name = movie.Name,
                };

                await _movieService.UpdateAsync(movieModel);
                return new OkObjectResult("ok");
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var movie = await _movieService.DeleteAsync(id);
                return new OkObjectResult(movie);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }
    }
}
