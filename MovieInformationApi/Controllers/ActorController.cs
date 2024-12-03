using Application.Service.Interface;
using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MovieInformationApi.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieInformationApi.Controllers
{
    [ApiController]
    [Route("actor")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        public ActorController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200,"Response Success", typeof(SuccessResponseDTO<CompleteActorDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "Non Content",typeof(BadRequestResponseDTO))]
        
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var actor = await _actorService.GetAsync(id);
                if (actor is null)
                {
                    return new NoContentResult();
                }

                var response = new SuccessResponseDTO<CompleteActorDTO>
                {
                    Content = _mapper.Map<CompleteActorDTO>(actor),
                    Message = "Success"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }
        
        [HttpGet("all")]
        [SwaggerResponse(200, "Response Success", typeof(SuccessResponseDTO<CompleteActorDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "Non Content", typeof(BadRequestResponseDTO))]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var actors = await _actorService.GetAllAsync(10,1);
                if (actors is null)
                {
                    return new NoContentResult();
                }

                var response = new SuccessResponseDTO<IEnumerable<CompleteActorDTO>>
                {
                    Content = actors.Select(a => _mapper.Map<CompleteActorDTO>(a)),
                    Message = "Success"
                };
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new BadRequestResponseDTO { ErrorMessage = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerResponse(200,"Response Success", typeof(SuccessResponseDTO<CompleteActorDTO>))]
        [SwaggerResponse(204, "Non Content")]
        [SwaggerResponse(400, "BadRequest",typeof(BadRequestResponseDTO))]
        public async Task<IActionResult> Post([FromBody] CompleteActorDTO actor)
        {
            try
            {
                var actorModel = new Actor(Guid.NewGuid())
                { 
                    Age = actor.Age,
                    BirthDate = actor.BirthDate,
                    State = actor.State,
                    City = actor.City,
                    Country = actor.Country,
                    Movies = actor.Movies.Select(m => 
                        new Movie(Guid.NewGuid())
                        {
                            Description = m.Description,
                            Director = m.Director,
                            Genre = m.Genre,
                            MovieRating = new MovieRating(Guid.NewGuid()) { Rating = m.MovieRating.Rating},
                            Producer = m.Producer,
                            ReleaseDate = m.ReleaseDate,
                            Title = m.Title
                        }).ToList(),
                    Name = actor.Name,
                    Nationality = actor.Nationality
                };
                var actorResponse = await _actorService.AddAsync(actorModel);

                if (actorResponse == null) throw new Exception("Failed to add actor");
                
                var response = new SuccessResponseDTO<CompleteActorDTO>
                {
                    Content = _mapper.Map<CompleteActorDTO>(actorResponse),
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
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CompleteActorDTO actor)
        {
            try
            {
                var actorModel = _mapper.Map<Actor>(actor);

                var response = new SuccessResponseDTO<SuccessStatusDTO>
                {
                    Content = new SuccessStatusDTO 
                    { 
                        Status = await _actorService.UpdateAsync(actorModel) 
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
                        Status = await _actorService.DeleteAsync(id)
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
