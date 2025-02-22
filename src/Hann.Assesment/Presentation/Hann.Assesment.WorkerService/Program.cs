using Hahn.Assesment.Hangfire;
using Hahn.Assesment.WorkerService.ServiceExtensions;
using Hangfire;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Initialize Application Services
// Refer to Application Layer for more information
// <see cref="Hahn.Assesment.Application.Middleware.ServiceExtensions"/>
builder.Services.ConfigureApplication(builder.Configuration);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHangfireDashboard();
app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();

app.MapControllers();
app.MapHangfireDashboard();

// Add hangfire recurring job to load alert data.
AddHangfireAlertRecurringJob();

app.Run();

void AddHangfireAlertRecurringJob()
{
    var loadAlertJob = app.Services.CreateScope().ServiceProvider.GetRequiredService<IJobScheduling>();
    loadAlertJob?.AddAlertRecurringJob();
}