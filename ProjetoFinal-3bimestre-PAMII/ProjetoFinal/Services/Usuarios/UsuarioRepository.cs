using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services.Usuarios
{
    public class UsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new();

        public IReadOnlyList<Usuario> Usuarios => _usuarios.AsReadOnly();

        public int AddUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
            return _usuarios.Count; // simula um ID
        }
    }
}
