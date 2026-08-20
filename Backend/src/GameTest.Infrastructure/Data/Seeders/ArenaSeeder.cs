using GameTest.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameTest.Infrastructure.Data.Seeders;

public class ArenaSeeder
{
    private readonly IAppDbContext _context;
    private readonly IArenaFactory _arenaFactory;

    public ArenaSeeder(
        IAppDbContext context,
        IArenaFactory arenaFactory)
    {
        _context = context;
        _arenaFactory = arenaFactory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _context.Arenas.AnyAsync(ct))
            return;

        var arenas = new[]
        {
            _arenaFactory.Create(
                "Forgotten Forest",
                "A dense forest filled with ancient trees and dangerous creatures.",
                100f,
                100f),

            _arenaFactory.Create(
                "Burning Wasteland",
                "A scorched wasteland surrounded by lava and volcanic rocks.",
                120f,
                120f),

            _arenaFactory.Create(
                "Frozen Valley",
                "A frozen valley covered in snow and surrounded by icy mountains.",
                150f,
                100f)
        };

        await _context.Arenas.AddRangeAsync(arenas, ct);
        await _context.SaveChangesAsync(ct);
    }
}
