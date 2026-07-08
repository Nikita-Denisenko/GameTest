using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetUnits
{
    public class GetPlayerUnitsQueryHandler : IRequestHandler<GetPlayerUnitsQuery, IReadOnlyCollection<PlayerUnitListReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetPlayerUnitsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<PlayerUnitListReadModel>> Handle(GetPlayerUnitsQuery query, CancellationToken ct)
        {
            var units = _context.PlayerUnits
                .AsNoTracking()
                .Where(pu => pu.PlayerId == query.PlayerId);

            if (query.Type != null)
                units = units.Where(pu => pu.Unit.Type == query.Type);

            units = units.OrderBy(u => u.Unit.Name);

            return await units
                .Skip((query.Page - 1) * query.Size)
                .Take(query.Size)
                .Select(pu => new PlayerUnitListReadModel 
                { 
                    Id = pu.Id,
                    Name = pu.Unit.Name,
                    Type = pu.Unit.Type
                })
                .ToListAsync(ct);
        }
    }
}
