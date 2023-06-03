using Common.Logging;
using Product.API.Extensions;
using Product.API.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information($"Start {builder.Environment.ApplicationName} up");
try
{
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Host.AddAppConfigurations();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddConfigurationSettings(builder.Configuration);

    var app = builder.Build();
    app.UseInfrastructure();

    // Tự động migrate database mỗi khi chạy project
    app.MigrateDatabase<ProductContext>((context, _) =>
    {
        ProductContextSeed.SeedProductAsync(context, Log.Logger).Wait();
    }).Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal)) throw;

    Log.Fatal(ex, $"Unhandled exception: {ex.Message}");
}
finally
{
    Log.Information($"Shutdown {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}
