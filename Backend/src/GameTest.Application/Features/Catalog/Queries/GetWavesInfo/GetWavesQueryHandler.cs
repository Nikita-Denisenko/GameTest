using GameTest.Application.Features.Catalog.ReadModels;
using GameTest.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace GameTest.Application.Features.Catalog.Queries.GetWavesInfo
{
    public class GetWavesQueryHandler : IRequestHandler<GetWavesQuery, IReadOnlyCollection<WaveReadModel>>
    {
        private readonly IAppDbContext _context;

        public GetWavesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<WaveReadModel>> Handle(GetWavesQuery query, CancellationToken ct)
        {
            return await _context.Waves
            .AsNoTracking()
            .Select(w => new WaveReadModel
            {
                Id = w.Id,
                Number = w.Number,
                StartSecond = w.StartSecond,
                EndSecond = w.EndSecond,

                Enemies = w.Enemies
                    .Select(e => new WaveEnemyReadModel
                    {
                        EnemyId = e.EnemyId,
                        SpawnInterval = e.SpawnInterval,
                        QuantityRange = new EnemyQuantityRangeReadModel
                        {
                            Min = e.QuantityRange.Min,
                            Max = e.QuantityRange.Max
                        }
                    })
                    .ToList()
            })
            .ToListAsync(ct);
        }
    }
}
