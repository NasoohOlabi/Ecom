using DB.IRepos;
using DB.Models;
using DB.Repos;
using DB.UOW;
using Ecom.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddDbContext<EComContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IArchiveService, ArchiveService>();
builder.Services.AddSingleton<IRatingBuffer, RatingBuffer>();
builder.Services.AddSingleton<ISingletonRnd, SingletonRnd>();   
builder.Services.AddTransient<ITransientRnd, TransientRnd>();
builder.Services.AddScoped<IScopedRnd, ScopedRnd>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(name: "admin_route",
                                     areaName: "admin",
                                     pattern: "Admin/{controller}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
