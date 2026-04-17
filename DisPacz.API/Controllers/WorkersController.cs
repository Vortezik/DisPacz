using DisPacz.API.Features.Workers.Messages.Commands;
using DisPacz.API.Features.Workers.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisPacz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllWorkersQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var result = await _mediator.Send(new GetWorkerByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkerCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] UpdateWorkerCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _mediator.Send(new DeleteWorkerCommand { Id = id });
            return NoContent();
        }
    }
}
