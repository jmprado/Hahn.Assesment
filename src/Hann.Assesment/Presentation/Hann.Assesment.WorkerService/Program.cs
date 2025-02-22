using Hahn.Assesment.Presentation.Config.AppExtensions;
using Hahn.Assesment.Presentation.Config.ServiceExtensions;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var hangfireConnString = builder.Configuration.GetConnectionString("Hangfire");
if (string.IsNullOrEmpty(hangfireConnString))
    throw new ArgumentException("Hangfire connection string not found in appsettings.json.");

builder.Services.AddHangfire((serviceProvider, config) =>
{
    config.UseSqlServerStorage(hangfireConnString);
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
});

builder.Services.AddHangfireServer();

builder.Services.RegisterSettings(builder.Configuration);
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAppServices(builder.Configuration);
builder.Services.AddJobSchedulingService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseGlobalExceptionHandler();
app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllers();
app.MapHangfireDashboard();

// Add hangfire recurring job to load alert data.
app.ScheduleJobs();

app.Run();
