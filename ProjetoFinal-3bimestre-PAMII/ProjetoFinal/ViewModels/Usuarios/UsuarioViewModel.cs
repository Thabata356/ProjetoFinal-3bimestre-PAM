using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoFinal.Models;
using ProjetoFinal.Services.Usuarios;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ProjetoFinal.Models.Enuns;

namespace ProjetoFinal.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand CadastrarCommand { get; set; }

        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            CadastrarCommand = new Command(async () => await CadastrarUsuario());
            Task.Run(async () => await ObterTipoPerfil());

            //InicializarCommands();
        }

        /*public void InicializarCommands()
        {
            CadastrarCommand = new Command(async () => await CadastrarUsuario());
        }*/

        private string _rmUsuario;
        private string _emailUsuario;
        private string _nomeUsuario;
        private string _senhaUsuario;
        private string _telefoneUsuario;
        private string _cpfUsuario;
        //private TipoPerfil _tipoPerfil;

        public string RmUsuario
        {
            get => _rmUsuario;
            set
            {
                _rmUsuario = value;
                OnPropertyChanged(nameof(RmUsuario));
                //ropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RmUsuario)));
            }
        }

        public string EmailUsuario
        {
            get => _emailUsuario;
            set
            {
                _emailUsuario = value;
                OnPropertyChanged(nameof(EmailUsuario));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmailUsuario)));
            }
        }

        public string NomeUsuario
        {
            get => _nomeUsuario;
            set
            {
                _nomeUsuario = value;
                OnPropertyChanged(nameof(NomeUsuario));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomeUsuario)));
            }
        }

        public string SenhaUsuario
        {
            get => _senhaUsuario;
            set
            {
                _senhaUsuario = value;
                OnPropertyChanged(nameof(SenhaUsuario));
            }
        }

        public string TelefoneUsuario
        {
            get => _telefoneUsuario;
            set
            {
                _telefoneUsuario = value;
                OnPropertyChanged(nameof(TelefoneUsuario));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TelefoneUsuario)));
            }
        }

        public string CpfUsuario
        {
            get => _cpfUsuario;
            set
            {
                _cpfUsuario = value;
                OnPropertyChanged(nameof(CpfUsuario));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CpfUsuario)));
            }
        }

        private ObservableCollection<TipoPerfil> listaTiposPerfil;
        public ObservableCollection<TipoPerfil> ListaTiposPerfil
        {
            get { return listaTiposPerfil; }
            set
            {
                if (value != null)
                {
                    listaTiposPerfil = value;
                    OnPropertyChanged(nameof(ListaTiposPerfil));
                }
            }
        }

        public async Task ObterTipoPerfil()
        {
            try
            {
                ListaTiposPerfil = new ObservableCollection<TipoPerfil>();
                ListaTiposPerfil.Add(new TipoPerfil() { Id = 1, NomeTipoPerfil = "Gestor Geral" });
                ListaTiposPerfil.Add(new TipoPerfil() { Id = 2, NomeTipoPerfil = "Gestor Departamento" });
                ListaTiposPerfil.Add(new TipoPerfil() { Id = 3, NomeTipoPerfil = "Funcionario" });
                OnPropertyChanged(nameof(ListaTiposPerfil));

            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private TipoPerfil tipoPerfilSelecionado;
        public TipoPerfil TipoPerfilSelecionado
        {
            get { return tipoPerfilSelecionado; } 
            set
            {
                if (value != null)
                {
                    tipoPerfilSelecionado = value;
                    OnPropertyChanged(nameof(TipoPerfilSelecionado));
                }
            }
        }

        public async Task CadastrarUsuario()
        {
            try
            {

                Usuario usuario = new Usuario()
                {
                    RmUsuario = this._rmUsuario,
                    NomeUsuario = this._nomeUsuario,
                    EmailUsuario = this._emailUsuario,
                    CpfUsuario = this._cpfUsuario,
                    SenhaUsuario = this._senhaUsuario,
                    TelefoneUsuario = this._telefoneUsuario,
                    TipoPerfil = (TipoPerfilEnum)tipoPerfilSelecionado.Id
                };


                //await uService.PostCadastrarUsuarioAsync(usuario);
                await uService.PostCadastrarUsuario(usuario);

                await Application.Current.MainPage.DisplayAlert("Usuário cadastrado!", $"Nome: {usuario.NomeUsuario}\nCPF: {usuario.CpfUsuario}\nEmail: {usuario.EmailUsuario}", "OK");


                /*await Application.Current.MainPage
                       .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");*/

                await Shell.Current.GoToAsync("//LoginView");
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}
