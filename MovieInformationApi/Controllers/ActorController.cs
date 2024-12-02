using Application.Service.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using MovieInformationApi.DTO;

namespace MovieInformationApi.Controllers
{
    [ApiController]
    [Route("actor")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var actor = await _actorService.GetAsync(id);
                return new OkObjectResult(actor);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ActorDTO actor)
        {
            try
            {
                var actorModel = new Actor(Guid.NewGuid())
                {
                    Name = actor.Name,
                };
                await _actorService.AddAsync(actorModel);
                return new OkObjectResult("ok");

            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ActorDTO actor)
        {
            try
            {
             
                var actorModel = new Actor(id)
                {
                    Name = actor.Name,
                };

                await _actorService.UpdateAsync(actorModel);
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
                var actor = await _actorService.DeleteAsync(id);
                return new OkObjectResult(actor);
            }
            catch (Exception ex)
            {
                return BadRequest("Call the Api Admin");
            }
        }
    }
}
