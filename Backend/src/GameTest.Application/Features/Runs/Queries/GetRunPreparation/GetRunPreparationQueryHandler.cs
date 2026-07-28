using GameTest.Application.Features.Runs.ReadModels;
using GameTest.Application.Interfaces;
using GameTest.Domain.Entities;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Queries.GetRunPreparation
{
    public class GetRunPreparationQueryHandler : IRequestHandler<GetRunPreparationQuery, RunPreparationReadModel>
    {
        private readonly IAppDbContext _context;

        public GetRunPreparationQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<RunPreparationReadModel> Handle(GetRunPreparationQuery query, CancellationToken ct)
        {
            var unit = await _context.PlayerUnits
                .AsNoTracking()
                .Where(pu => pu.Id == query.PlayerUnitId && pu.PlayerId == query.PlayerId)
                .Select(pu => new RunUnitReadModel
                {
                    PlayerUnitId = pu.Id,
                    UnitId = pu.UnitId,
                    Properties = pu.Properties.Select(p => new RunUnitPropertyReadModel
                    {
                        StatId = p.UnitProperty.StatId,
                        Level = p.Level,
                        Value = p.Value
                    }).ToList()
                })
                .FirstOrDefaultAsync(ct)
                ?? throw new NotFoundException($"PlayerUnit with ID {query.PlayerUnitId} not found");

            var items = await _context.PlayerItems
                .AsNoTracking()
                .Where(pi => pi.PlayerId == query.PlayerId)
                .Select(pi => new RunItemReadModel
                {
                    PlayerItemId = pi.Id,
                    ItemId = pi.ItemId,
                    Bonus = pi.Bonus,
                    Level = pi.Level,
                })
                .ToListAsync(ct);
                
            var weapons = await _context.PlayerWeapons
                .AsNoTracking()
                .Where(pw => pw.PlayerId == query.PlayerId)
                .Select(pw => new RunWeaponReadModel 
                {
                    PlayerWeaponId = pw.Id,
                    WeaponId = pw.WeaponId,
                    Properties = pw.Properties.Select(p => new RunWeaponPropertyReadModel
                    {
                        StatId = p.WeaponProperty.StatId,
                        Level = p.Level,
                        Value = p.Value
                    }).ToList()
                })
                .ToListAsync(ct);

            return new RunPreparationReadModel
            {
                PlayerId = query.PlayerId,
                Weapons = weapons,
                Items = items,
                Unit = unit
            };
        }
    }
}
