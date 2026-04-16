using DisPacz.API.Features.Jobs.Messages.Commands;
using DisPacz.API.Features.Jobs.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisPacz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllJobsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
