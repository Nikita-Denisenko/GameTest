using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetCats
{
    public class GetCatsQueryHandler : IRequestHandler<GetCatsQuery, IReadOnlyCollection<CatReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetCatsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<CatReadModel>> Handle(GetCatsQuery query, CancellationToken ct)
        {
            return await _context.Cats
                .AsNoTracking()
                .Select(c => new CatReadModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Properties = c.Properties.Select(p => new CatPropertyReadModel
                    {
                        StatId = p.StatId,
                        StatName = p.Stat.Name,
                        Value = p.Value,
                    }).ToList(),
                    Type = c.Type,
                    Price = c.Price,
                })
                .ToListAsync(ct);
        }
    }
}
