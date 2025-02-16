using Hahn.Assesment.Application.Jobs;
using Hahn.Assesment.Application.Middleware;
using Hahn.Assesment.Appliction.Services.Hangfire;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Initialize Application Services
// Refer to Application Layer for more information
// <see cref="Hahn.Assesment.Application.Middleware.ServiceExtensions"/>
builder.Services.ConfigureApplication(builder.Configuration);

// Create Hangfire database.
var hangfireDb = new HangfireDb(builder.Configuration);
hangfireDb.CreateDatabase(builder.Configuration);

// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("Hangfire")));

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
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loadAlertJob = services.GetService<ILoadAlertJob>();
    loadAlertJob?.AddRecurringJob();
}

app.Run();
