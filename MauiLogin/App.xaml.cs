
namespace MauiLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            string? usuario_logado = null;

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (usuario_logado != null)
                {
                    MainPage = new Protegida();
                }

            });
            

            MainPage = new LoginPage(); 
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Height = 700;
            window.Width = 400;

            return window;
        }



    }
}
