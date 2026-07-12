using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IReadOnlyCollection<ItemReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetItemsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ItemReadModel>> Handle(GetItemsQuery query, CancellationToken ct)
        {
            return await _context.Items
                .AsNoTracking()
                .Select(item => new ItemReadModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Type = item.Type,
                    MaxLevel = item.Effect.Levels.Max(l => l.Level),
                    Effect = new ItemEffectReadModel
                    {
                        Name = item.Effect.Name,
                        Description = item.Effect.Description,
                        Type = item.Effect.Type,
                        Levels = item.Effect.Levels
                            .Select(level => new LevelProgressionReadModel
                            {
                                Level = level.Level,
                                Value = level.Value,
                                Price = level.Price
                            })
                            .ToList()
                    }
                })
                .ToListAsync(ct);
        }
    }
}
