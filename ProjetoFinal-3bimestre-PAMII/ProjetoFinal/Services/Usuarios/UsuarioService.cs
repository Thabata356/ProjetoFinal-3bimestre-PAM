using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models;

namespace ProjetoFinal.Services.Usuarios
{
    public class UsuarioService : Request
    // URL SOMEE: workstation id=DB-CADASTRAR-USUARIO.mssql.somee.com;packet size=4096;user id=sa-cadastrar;pwd=*123456HAS*;data source=DB-CADASTRAR-USUARIO.mssql.somee.com;persist security info=False;initial catalog=DB-CADASTRAR-USUARIO;TrustServerCertificate=True
    {
        private readonly Request _request;
        private const string _apiUrlBase = "AAAAAAAAAA";
        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<int> PostCadastrarUsuarioAsync(Usuario u)
        {
            return await _request.PostReturnIntAsync(_apiUrlBase, u); /*string.Empty*/

        }
    }
}
