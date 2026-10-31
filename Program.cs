using Preparation.Shared.Web;

var info = new ProjectInfo("legacy", "Laboratorio de modernización legacy", "LegacyLabDb", 5106, "Compara comportamiento sintético y registra decisiones de migración.");
var builder = WebApplication.CreateBuilder(args);
ProjectBootstrap.Configure(builder, info);
var app = builder.Build();
await ProjectBootstrap.InitializeAsync(app, info);
ProjectBootstrap.ConfigurePipeline(app, info);
app.MapControllers();
await app.RunAsync();
