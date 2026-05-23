using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Catalogo.Domain.Interfaces;
using Catalogo.Domain.Models;

namespace Catalogo.Infrastructure.Repositories
{
    public class JsonUsuarioRepository : IUsuarioRepository
    {
        private readonly string _path;
        private readonly JsonSerializerOptions _opts = new JsonSerializerOptions { WriteIndented = true };

        public JsonUsuarioRepository(string path) => _path = path;

        public List<Usuario> GetAll()
        {
            if (!File.Exists(_path)) return new List<Usuario>();
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Usuario>>(json, _opts) ?? new List<Usuario>();
        }

        public Usuario GetByEmail(string email) =>
            GetAll().FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))!;

        public Usuario GetByNombreUsuario(string nombreUsuario) =>
            GetAll().FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase))!;

        public void Add(Usuario usuario)
        {
            var lista = GetAll();
            usuario.Id = lista.Count > 0 ? lista.Max(u => u.Id) + 1 : 1;
            lista.Add(usuario);
            File.WriteAllText(_path, JsonSerializer.Serialize(lista, _opts));
        }
    }
}