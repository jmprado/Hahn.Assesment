using Hahn.Assesment.WebAPI.ServiceExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// optional: remove default logging providers
builder.Logging.ClearProviders();

// Register Serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)   //read config from appsettings
    .CreateLogger();

builder.Logging.AddSerilog(logger);

// Refer to Core/Application/Middleware/ServiceExtensions.cs for adding/modify services
builder.Services.ConfigureApplication(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();

// Global exception handling
app.UseGlobalExceptionHandler();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
