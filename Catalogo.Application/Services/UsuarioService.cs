using System;
using System.Security.Cryptography;
using System.Text;
using Catalogo.Domain.Interfaces;
using Catalogo.Domain.Models;

namespace Catalogo.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo) => _repo = repo;

        private static string Hash(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }

        public (bool ok, string error) Registrar(string nombreUsuario, string email, string password)
        {
            if (_repo.GetByEmail(email) != null)
                return (false, "El correo ya está registrado.");

            if (_repo.GetByNombreUsuario(nombreUsuario) != null)
                return (false, "El nombre de usuario ya está en uso.");

            if (password.Length < 6)
                return (false, "La contraseña debe tener al menos 6 caracteres.");

            _repo.Add(new Usuario
            {
                NombreUsuario = nombreUsuario,
                Email = email,
                PasswordHash = Hash(password),
                FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy")
            });

            return (true, string.Empty);
        }

        public Usuario? Login(string email, string password)
        {
            var usuario = _repo.GetByEmail(email);
            if (usuario == null) return null;

            return usuario.PasswordHash == Hash(password) ? usuario : null;
        }
    }
}