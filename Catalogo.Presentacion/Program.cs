// Tus carpetas
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces;
using Catalogo.Infrastructure.Repositories;
using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// ── Rutas de datos ────────────────────────────────────
var jsonItems = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");
var jsonUsuarios = Path.Combine(builder.Environment.ContentRootPath, "data", "usuarios.json");

// ── Servicios ─────────────────────────────────────────
builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonItems));
builder.Services.AddSingleton<IUsuarioRepository>(new JsonUsuarioRepository(jsonUsuarios));
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<UsuarioService>();

// ── Autenticación por cookie ──────────────────────────
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

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

app.UseAuthentication();   // ← Autenticación
app.UseAuthorization();    // ← Autorización

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();