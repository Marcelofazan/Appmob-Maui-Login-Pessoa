namespace AppMobile;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Confirmado : ContentPage
{
	public Confirmado()
	{
		InitializeComponent();
	}

    private void btnVoltar_Clicked(object sender, EventArgs args)
    {
        Task task = Navigation.PushModalAsync(new MainPage());
    }
}