namespace MauiLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			l_nome.Text = $"Ol�, {usuario_logado}!";
		});


	}

    private async void btn_clicked(object sender, EventArgs e)
    {
		if (await DisplayAlert("Tem certeza?", "Sair do app?", "Sim", "N�o") == true)
		{
			SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new LoginPage();
        }
		
    }
}