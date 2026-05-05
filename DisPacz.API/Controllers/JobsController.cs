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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] int id)
        {
            var result = await _mediator.Send(new GetJobByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJobCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] UpdateJobCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _mediator.Send(new DeleteJobCommand { Id = id });
            return NoContent();
        }

        [HttpPost("{jobId:int}/workers/{workerId:int}")]
        public async Task<IActionResult> AssignWorker([FromRoute(Name = "jobId")] int jobId, [FromRoute(Name = "workerId")] int workerId)
        {
            await _mediator.Send(new AssignWorkerToJobCommand
            {
                JobId = jobId,
                WorkerId = workerId
            });

            return NoContent();
        }

        [HttpDelete("{jobId:int}/workers/{workerId:int}")]
        public async Task<IActionResult> RemoveWorker([FromRoute(Name = "jobId")] int jobId, [FromRoute(Name = "workerId")] int workerId)
        {
            await _mediator.Send(new RemoveWorkerFromJobCommand
            {
                JobId = jobId,
                WorkerId = workerId
            });

            return NoContent();
        }

        [HttpPost("{jobId:int}/equipment/{equipmentId:int}")]
        public async Task<IActionResult> AssignEquipment([FromRoute(Name = "jobId")] int jobId, [FromRoute(Name = "equipmentId")] int equipmentId)
        {
            await _mediator.Send(new AssignEquipmentToJobCommand
            {
                JobId = jobId,
                EquipmentId = equipmentId
            });

            return NoContent();
        }

        [HttpDelete("{jobId:int}/equipment/{equipmentId:int}")]
        public async Task<IActionResult> RemoveEquipment([FromRoute(Name = "jobId")] int jobId, [FromRoute(Name = "equipmentId")] int equipmentId)
        {
            await _mediator.Send(new RemoveEquipmentFromJobCommand
            {
                JobId = jobId,
                EquipmentId = equipmentId
            });

            return NoContent();
        }
    }
}
