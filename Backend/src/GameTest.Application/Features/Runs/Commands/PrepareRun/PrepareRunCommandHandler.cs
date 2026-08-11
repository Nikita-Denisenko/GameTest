using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Features.Runs.ReadModels;
using GameTest.Application.Interfaces;
using GameTest.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Runs.Commands.PrepareRun
{
    public class PrepareRunCommandHandler : IRequestHandler<PrepareRunCommand, RunPreparationReadModel>
    {
        private readonly IAppDbContext _context;

        public PrepareRunCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<RunPreparationReadModel> Handle(PrepareRunCommand command, CancellationToken ct)
        {
            var unit = await _context.PlayerUnits
                .AsNoTracking()
                .Where(pu => pu.Id == command.PlayerUnitId && pu.PlayerId == command.PlayerId)
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
                ?? throw new NotFoundException($"PlayerUnit with ID {command.PlayerUnitId} not found");

            var items = await _context.PlayerItems
                .AsNoTracking()
                .Where(pi => pi.PlayerId == command.PlayerId)
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
                .Where(pw => pw.PlayerId == command.PlayerId)
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

            RunCatReadModel? catReadModel = null;

            if (command.CatId != null)
            {
                var cat = await _context.Cats
                   .AsNoTracking()
                   .Include(c => c.Properties)
                   .Where(c => c.Id == command.CatId)
                   .FirstOrDefaultAsync(ct)
                   ?? throw new NotFoundException($"Cat with ID {command.CatId} was not found exception");

                var player = await _context.Players
                    .FirstOrDefaultAsync(p => p.Id == command.PlayerId, ct)
                    ?? throw new NotFoundException($"Player with ID {command.PlayerId} was not found.");

                player.SpendGold(cat.Price);

                catReadModel = new RunCatReadModel
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Properties = cat.Properties.Select(p => new RunCatPropertyReadModel
                    {
                        StatId = p.StatId,
                        Value = p.Value
                    }).ToList(),
                    Type = cat.Type
                };
            }

            return new RunPreparationReadModel
            {
                ArenaId = command.ArenaId,
                PlayerId = command.PlayerId,
                Weapons = weapons,
                Items = items,
                Unit = unit,
                Cat = catReadModel
            };
        }
    }
}