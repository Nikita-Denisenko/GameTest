using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Application.Features.Catalog.Queries.GetArenas
{
    public class GetArenasQueryHandler : IRequestHandler<GetArenasQuery, IReadOnlyCollection<ArenaReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetArenasQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<ArenaReadModel>> Handle(GetArenasQuery query, CancellationToken ct)
        {
            return await _context.Arenas
                .AsNoTracking()
                .Select(a => new ArenaReadModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    Width = a.Width,
                    Height = a.Height
                })
                .ToListAsync(ct);
        }
    }
}
