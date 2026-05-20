using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var jsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");

builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonPath));
builder.Services.AddScoped<ItemService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();