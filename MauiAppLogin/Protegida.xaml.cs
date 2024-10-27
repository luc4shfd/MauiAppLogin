namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;
		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"Bem-Vindo (a) {usuario_logado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool comfirmacao = await DisplayAlert("Tem certeza?", "Sair do App?", "Sim", "Não");

		if (comfirmacao) 
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
		}
    }
}