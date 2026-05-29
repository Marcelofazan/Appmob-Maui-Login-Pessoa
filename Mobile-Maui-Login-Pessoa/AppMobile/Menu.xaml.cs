namespace AppMobile;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private void btnLogout_Clicked(object sender, EventArgs args)
    {
        Task task = Navigation.PushModalAsync(new MainPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

}