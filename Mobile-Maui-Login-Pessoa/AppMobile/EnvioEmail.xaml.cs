namespace AppMobile;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class EnvioEmail : ContentPage
{
	public EnvioEmail()
	{
		InitializeComponent();
	}
    private void btnLogin_Clicked(object sender, EventArgs args)
    {
        Task task = Navigation.PushModalAsync(new MainPage());
    }

}