using ProjetoFinal.ViewModels.Usuarios;

namespace ProjetoFinal.Views.Usuarios;

public partial class LoginView : ContentPage
{
	UsuarioViewModel UsuarioViewModel;
	public LoginView()
	{
		InitializeComponent();

		UsuarioViewModel = new UsuarioViewModel();
		BindingContext = UsuarioViewModel;
	}
}