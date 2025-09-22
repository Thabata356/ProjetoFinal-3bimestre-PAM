using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models;
using ProjetoFinal.Services.Usuarios;

namespace ProjetoFinal.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService _uService;
        public ICommandMapper CadastrarCommand { get; set; }

        public UsuarioViewModel()
        { 
            _uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            CadastrarCommand = new Command(async () => await CadastrarUsuario());
        }

        public async Task CadastrarUsuario()
        {
            try
            {
                UsuarioService u = new Usuario();

                Usuario uCadastrado = await _uService.PostCadastrarUsuarioAsync(u);

                if (uCadastrado.RmUsuario /*Continar*/)
                {
                    //Continar método.
                }

            }
        }
    }
}
