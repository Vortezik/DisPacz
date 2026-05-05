using DisPacz.API.Features.Dispatches.Messages.DTOs;
using DisPacz.API.Features.Dispatches.Messages.Queries;
using DisPacz.API.Features.Dispatches.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Handlers.Queries
{
    public class GetAllDispatchesHandler : IRequestHandler<GetAllDispatchesQuery, List<DispatchDto>>
    {
        private readonly IDispatchProvider _dispatchProvider;

        public GetAllDispatchesHandler(IDispatchProvider dispatchProvider)
        {
            _dispatchProvider = dispatchProvider;
        }

        public async Task<List<DispatchDto>> Handle(GetAllDispatchesQuery request, CancellationToken cancellationToken)
        {
            var dispatches = await _dispatchProvider.GetAllDispatchesAsync(true, cancellationToken);

            return dispatches.Adapt<List<DispatchDto>>();
        }
    }
}
