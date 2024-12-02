using Application.Service.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using MovieInformationApi.DTO;

namespace MovieInformationApi.Controllers
{
    [ApiController]
    [Route("rating")]
    public class RatingController : ControllerBase
    {
        private readonly IMovieRatingService _movieRatingService;
        public RatingController(IMovieRatingService movieRatingService)
        {
            _movieRatingService = movieRatingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var actor = await _movieRatingService.GetAsync(id);
                return new OkObjectResult(actor);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RatingDTO movieRating)
        {
            try
            {
                var actorModel = new MovieRating(Guid.NewGuid())
                {
                    MovieId = movieRating.MovieId,
                    Rating = movieRating.Rating
                };
                await _movieRatingService.AddAsync(actorModel);
                return new OkObjectResult("ok");

            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpGet("movie/{id}")]
        public async Task<IActionResult> GetByMovieId(Guid id)
        {
            try
            {
                var actor = await _movieRatingService.GetAsync(id);
                return new OkObjectResult(actor);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }
    }
}
