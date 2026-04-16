using DisPacz.API.Features.Clients.Messages.Commands;
using DisPacz.API.Features.Clients.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DisPacz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
    }
}
