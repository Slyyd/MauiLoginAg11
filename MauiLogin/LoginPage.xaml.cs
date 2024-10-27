namespace MauiLogin;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{

			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "Kaue",
					Senha = "********" // Oito asteriscos para se tentarem usar minha senha eles ficarem confusos.
				},

				new DadosUsuario()
				{
					Usuario = "Monkey",
					Senha = "Chimpanzé"
				},

				new DadosUsuario()
				{
					Usuario = "Jazzghost",
					Senha = "Cabra safado"
				}

			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha) ))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
				App.Current.MainPage = new Protegida();
			}

			l_retorno.IsVisible = true;


		}
		catch (Exception ex) 
		{
			await DisplayAlert("Erro", ex.Message, "OK");
		}
    }
}