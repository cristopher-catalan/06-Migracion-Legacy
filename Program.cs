using MigracionLegacy.Endpoints;
using MigracionLegacy.Services;
using MigracionLegacy.UI;
using Preparation.Shared.Web;

var info = new ProjectInfo("legacy", "Modernización legacy", "MigracionLegacyDb", 5106, "Analiza, caracteriza y registra decisiones de modernización técnica.");
var builder = WebApplication.CreateBuilder(args);

// Register characterization comparison engine service
builder.Services.AddSingleton<ICharacterizationEngine, CharacterizationEngine>();

ProjectBootstrap.Configure(builder, info);
var app = builder.Build();
await ProjectBootstrap.InitializeAsync(app, info);
ProjectBootstrap.ConfigurePipeline(app, info);

// Map Legacy enhanced endpoints and register modern UI layout
LegacyEndpoints.Map(app);
DashboardRenderer.RegisterCustomView(info.Key, LegacyLayout.Render);
app.MapControllers();

await app.RunAsync();
