using MediatR;

namespace DisPacz.API.Features.Locations.Messages.Commands
{
    public class DeleteLocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
