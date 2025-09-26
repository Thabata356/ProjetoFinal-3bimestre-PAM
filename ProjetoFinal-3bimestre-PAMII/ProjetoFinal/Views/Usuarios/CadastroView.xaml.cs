using ProjetoFinal.ViewModels.Usuarios;

namespace ProjetoFinal.Views.Usuarios;

public partial class CadastroView : ContentPage
{
	public CadastroView()
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel();
    }
}