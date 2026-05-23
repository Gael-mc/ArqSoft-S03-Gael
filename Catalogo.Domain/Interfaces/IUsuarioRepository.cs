using System.Collections.Generic;
using Catalogo.Domain.Models;

namespace Catalogo.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAll();
        Usuario GetByEmail(string email);
        Usuario GetByNombreUsuario(string nombreUsuario);
        void Add(Usuario usuario);
    }
}