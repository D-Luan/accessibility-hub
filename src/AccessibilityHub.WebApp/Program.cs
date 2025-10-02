using Microsoft.EntityFrameworkCore;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Extensions;
using AccessibilityHub.WebApp.Services;
using AccessibilityHub.Entities.Models;
using static AccessibilityHub.WebApp.Services.IDisabilityService;
using static AccessibilityHub.WebApp.Services.IResourceService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDisabilityService, DisabilityService>();
builder.Services.AddScoped<IResourceService, ResourceService>();

builder.Services.ConfigurePersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
