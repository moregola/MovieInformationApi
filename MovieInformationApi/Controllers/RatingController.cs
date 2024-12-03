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
    [Route("rating")]
    public class RatingController : ControllerBase
    {
        private readonly IMovieRatingService _movieRatingService;
        private readonly IMapper _mapper;

        public RatingController(IMovieRatingService movieRatingService, IMapper mapper)
        {
            _movieRatingService = movieRatingService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<RatingDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var rating = await _movieRatingService.GetAsync(id);
                
                if (rating is null)
                {
                    return new NoContentResult();
                }

                var response  = new SuccessResponseDTO<RatingDTO>
                { 
                    Content = _mapper.Map<RatingDTO>(rating),
                    Message = "Success"
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
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<RatingDTO>))]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Post([FromBody] RatingDTO movieRating)
        {
            try
            {
                var rating = _mapper.Map<MovieRating>(movieRating);
                var ratingResponse = await _movieRatingService.AddAsync(rating);
                
                var response = new SuccessResponseDTO<RatingDTO>
                {
                    Content = _mapper.Map<RatingDTO>(ratingResponse),
                    Message = "Success"
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message});
            }
        }

        [HttpGet("movie/{id}")]
        [Authorize]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<RatingDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "BadRequest", typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> GetByMovieId([FromRoute]Guid id)
        {
            try
            {
                var rating = await _movieRatingService.GetByMovieId(id);

                if(rating is null)
                {
                    return new NoContentResult();
                }

                var response = new SuccessResponseDTO<RatingDTO>
                {
                    Content = _mapper.Map<RatingDTO>(rating),
                    Message = "Success"
                };

                return new OkObjectResult(rating);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message});
            }
        }
    }
}
