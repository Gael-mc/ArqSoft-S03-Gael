using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// Usamos estrictamente el namespace de tu proyecto
using Catalogo.Application.Services;
using Catalogo.Domain.Interfaces;
using Catalogo.Domain.Models;

namespace Catalogo.Presentacion.Controllers
{
    public class AccountController : Controller
    {
        private readonly UsuarioService _service;

        public AccountController(UsuarioService service) => _service = service;

        // ── LOGIN ────────────────────────────────────────
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string? returnUrl = null)
        {
            var usuario = _service.Login(email, password);

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                ViewBag.ReturnUrl = returnUrl;
                return View();
            }

            // CORRECCIÓN: Agregamos "Claim" explícitamente
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,  usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true });

            return Redirect(returnUrl ?? "/");
        }

        // ── REGISTRO ─────────────────────────────────────
        public IActionResult Registro() => View();

        [HttpPost]
        public async Task<IActionResult> Registro(string nombreUsuario, string email, string password, string confirmar)
        {
            if (password != confirmar)
            {
                ViewBag.Error = "Las contraseñas no coinciden.";
                return View();
            }

            var (ok, error) = _service.Registrar(nombreUsuario, email, password);

            if (!ok)
            {
                ViewBag.Error = error;
                return View();
            }

            var usuario = _service.Login(email, password);
            if (usuario == null) return RedirectToAction("Login"); // Validación de seguridad extra

            // CORRECCIÓN: Agregamos "Claim" explícitamente
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,  usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true });

            return RedirectToAction("Index", "Home");
        }

        // ── LOGOUT ───────────────────────────────────────
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}