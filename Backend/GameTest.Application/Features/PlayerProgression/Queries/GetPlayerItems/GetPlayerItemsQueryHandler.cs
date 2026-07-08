using GameTest.Application.Features.PlayerProgression.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.PlayerProgression.Queries.GetItems
{
    public class GetPlayerItemsQueryHandler : IRequestHandler<GetPlayerItemsQuery, IReadOnlyCollection<PlayerItemListReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetPlayerItemsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<PlayerItemListReadModel>> Handle(GetPlayerItemsQuery query, CancellationToken ct)
        {
            var items = _context.PlayerItems
                .AsNoTracking()
                .Where(pi => pi.PlayerId == query.PlayerId);

            if (query.Type != null)
                items = items.Where(pi => pi.Item.Type == query.Type);

            items = items.OrderBy(pi => pi.Item.Name);

            return await items
                .Skip((query.Page - 1) * query.Size)
                .Take(query.Size)
                .Select(pi => new PlayerItemListReadModel
                {
                    Id = pi.Id,
                    Name = pi.Item.Name,
                    Type = pi.Item.Type,
                })
                .ToListAsync(ct);
        }
    }
}
