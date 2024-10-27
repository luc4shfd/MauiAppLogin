namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
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
					usuario = "jose",
					senha = "123"
				},
				new DadosUsuario()
				{
					usuario = "maria",
					senha = "321"
				}

			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				usuario = txt_usuario.Text,
				senha = txt_senha.Text
			};

			// LINQ
			if(lista_usuarios.Any(i => (dados_digitados.usuario == i.usuario && dados_digitados.senha == i.senha)))
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.usuario);
				App.Current.MainPage = new Protegida();
			}
			else
			{
				throw new Exception("Usuário ou senha incorretos.");
			}


		}
		catch (Exception ex) 
		{
			await DisplayAlert("Ops",ex.Message,"Fechar");
		}



    }

}