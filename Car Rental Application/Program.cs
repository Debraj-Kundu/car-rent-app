using Car_Rental_Application;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var startup = new Startup(builder.Configuration);
    var services = builder.Services;

    startup.ConfigureServices(services);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    var webHostEnvironment = app.Environment;
    startup.Configure(app, webHostEnvironment);

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}