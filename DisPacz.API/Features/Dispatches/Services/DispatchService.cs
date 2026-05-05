using DisPacz.API.Models;
using DisPacz.API.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DisPacz.API.Features.Dispatches.Services
{
    public class DispatchService : IDispatchService
    {
        private readonly ApplicationDbContext _context;

        public DispatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateDispatch(Dispatch dispatch, CancellationToken cancellationToken)
        {
            _context.Dispatches.Add(dispatch);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateDispatch(int id, Dispatch dispatch, CancellationToken cancellationToken)
        {
            var existing = await _context.Dispatches.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            existing.AssignedAt = dispatch.AssignedAt;
            existing.JobId = dispatch.JobId;
            existing.WorkerId = dispatch.WorkerId;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteDispatch(int id, CancellationToken cancellationToken)
        {
            var dispatch = await _context.Dispatches.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

            if (dispatch == null)
            {
                throw new KeyNotFoundException();
            }
                
            _context.Dispatches.Remove(dispatch);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
