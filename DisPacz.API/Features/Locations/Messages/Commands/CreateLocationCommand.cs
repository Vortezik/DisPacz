using MediatR;

namespace DisPacz.API.Features.Locations.Messages.Commands
{
    public class CreateLocationCommand : IRequest<int>
    {
        public string Address { get; set; }
        public string City { get; set; }
    }
}
