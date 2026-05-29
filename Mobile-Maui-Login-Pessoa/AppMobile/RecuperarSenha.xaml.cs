using AppMobile.Models;
using AppMobile.Service;
using Plugin.Connectivity;

namespace AppMobile;

public partial class RecuperarSenha : ContentPage
{
    public RecuperarSenha()
	{
		InitializeComponent();
	}
    private async void btnLembrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    await DisplayAlertAsync("Erro", "Informe o Email", "OK");
                }

                var data = await PessoaService.GetPessoasAsync();

                var pessoa = data.Where(x => x.Email == txtEmail.Text).ToList();
                if (pessoa.Count > 0)
                {
                        var confirmado = new EnvioEmail();
                        Task task = Navigation.PushModalAsync(confirmado);
                    }
                else
                {
                    await DisplayAlertAsync("Erro", "Email incorreto", "OK");
                }
            }
            else
            {
                await DisplayAlertAsync("Erro", "Sem conexão com a Internet", "OK");
            }

            return;
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }
    private void btnVoltar_Clicked(object sender, EventArgs args)
    {
        Task task = Navigation.PushModalAsync(new MainPage());
    }
}