using DisPacz.API.Features.Dispatches.Messages.DTOs;
using DisPacz.API.Features.Dispatches.Messages.Queries;
using DisPacz.API.Features.Dispatches.Providers;
using Mapster;
using MediatR;

namespace DisPacz.API.Features.Dispatches.Handlers.Queries
{
    public class GetDispatchByIdHandler : IRequestHandler<GetDispatchByIdQuery, DispatchDto>
    {
        private readonly IDispatchProvider _dispatchProvider;

        public GetDispatchByIdHandler(IDispatchProvider dispatchProvider)
        {
            _dispatchProvider = dispatchProvider;
        }

        public async Task<DispatchDto> Handle(GetDispatchByIdQuery request, CancellationToken cancellationToken)
        {
            var dispatch = await _dispatchProvider.GetDispatchByIdAsync(request.Id, true, cancellationToken);

            return dispatch.Adapt<DispatchDto>();
        }
    }
}
