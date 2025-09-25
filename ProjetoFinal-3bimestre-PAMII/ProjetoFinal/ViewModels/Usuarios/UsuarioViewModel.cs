using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models;
using ProjetoFinal.Services.Usuarios;
using System.Windows.Input;
using Microsoft.Maui.Controls; 

namespace ProjetoFinal.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService _uService;
        public ICommand CadastrarCommand { get; set; }//ICommandMapper da erro

        public UsuarioViewModel()
        {
            _uService = new UsuarioService();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            CadastrarCommand = new Command(async () => await CadastrarUsuario());//Da erro aqui
        }

        private string _rmUsuario;
        private string _emailUsuario;
        private string _nomeUsuario;
        private string _senhaUsuario;
        private string _telefoneUsuario;
        private string _cpfUsuario;
        private string _perfilUsuario;
        private string _tokenUsuario;

        public string RmUsuario
        {
            get => _rmUsuario;
            set
            {
                _rmUsuario = value;
                OnPropertyChanged();
                //ropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RmUsuario)));
            }
        }

        public string EmailUsuario
        {
            get => _emailUsuario;
            set
            {
                _emailUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmailUsuario)));
            }
        }

        public string NomeUsuario
        {
            get => _nomeUsuario;
            set
            {
                _nomeUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomeUsuario)));
            }
        }

        public string SenhaUsuario
        {
            get => _senhaUsuario;
            set
            {
                _senhaUsuario = value;
                OnPropertyChanged();
            }
        }

        public string TelefoneUsuario
        {
            get => _telefoneUsuario;
            set
            {
                _telefoneUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TelefoneUsuario)));
            }
        }

        public string CpfUsuario
        {
            get => _cpfUsuario;
            set
            {
                _cpfUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CpfUsuario)));
            }
        }

        public string PerfilUsuario
        {
            get => _perfilUsuario;
            set
            {
                _perfilUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CpfUsuario)));
            }
        }

        public string TokenUsuario
        {
            get => _tokenUsuario;
            set
            {
                _tokenUsuario = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CpfUsuario)));
            }
        }

        public async Task CadastrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.RmUsuario = _rmUsuario;
                u.NomeUsuario = _nomeUsuario;
                u.EmailUsuario = _emailUsuario;
                u.CpfUsuario = _cpfUsuario;
                u.SenhaUsuario = _senhaUsuario;
                u.TelefoneUsuario = _telefoneUsuario;
                u.PerfilUsuario = _perfilUsuario;
                u.TokenUsuario = _tokenUsuario;


                Usuario uCadastrado = await _uService.PostCadastrarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uCadastrado.TokenUsuario))
                {
                    string mensagem = $"Bem-vindo(a) {uCadastrado.NomeUsuario}.";

                    Preferences.Set("UsuarioRm", uCadastrado.RmUsuario);
                    Preferences.Set("UsuarioNome", uCadastrado.NomeUsuario);
                    Preferences.Set("UsuarioEmail", uCadastrado.EmailUsuario);
                    Preferences.Set("UsuarioUSenha", uCadastrado.SenhaUsuario);
                    Preferences.Set("UsuarioUTelefone", uCadastrado.TelefoneUsuario);
                    Preferences.Set("UsuarioCpf", uCadastrado.CpfUsuario);
                    Preferences.Set("UsuarioPerfil", uCadastrado.PerfilUsuario);
                    Preferences.Set("UsuarioToken", uCadastrado.TokenUsuario);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "OK");

                    Application.Current.MainPage = new MainPage();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos: (", "OK");
                }

            }
            catch (Exception ex) 
            { 
                await Application.Current.MainPage
                    .DisplayAlert("Inforação", ex.Message + "Detalhes" + ex.InnerException, "OK");
            }
        }
    }
}
