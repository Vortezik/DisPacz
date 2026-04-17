using DisPacz.API.Features.Locations.Messages.Commands;
using DisPacz.API.Features.Locations.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisPacz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLocationsQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var result = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] UpdateLocationCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _mediator.Send(new DeleteLocationCommand { Id = id });
            return NoContent();
        }
    }
}
