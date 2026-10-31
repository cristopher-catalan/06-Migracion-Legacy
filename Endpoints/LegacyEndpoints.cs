using Microsoft.EntityFrameworkCore;
using MigracionLegacy.Services;
using Preparation.Shared.Data;

namespace MigracionLegacy.Endpoints;

public static class LegacyEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/api/legacy-mgmt").RequireAuthorization();

        group.MapGet("/roadmap", (ICharacterizationEngine engine) =>
        {
            var roadmap = engine.GetRoadmap().Select(x => new
            {
                module = x.Module,
                status = x.Status,
                progress = x.Progress
            });
            return Results.Ok(roadmap);
        });

        group.MapGet("/recent-changes", async (AppDbContext db) =>
        {
            var changes = await db.MigrationChanges
                .OrderByDescending(x => x.At)
                .Take(50)
                .ToListAsync();
            return Results.Ok(changes);
        });
    }
}
