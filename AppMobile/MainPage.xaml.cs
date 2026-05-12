using AppMobile.Models;
using AppMobile.Service;
using Plugin.Connectivity;

namespace AppMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void Logar()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSenha.Text))
                    {
                        await DisplayAlertAsync("Erro", "Informe o Email e a senha", "OK");
                    }

                    var data = await PessoaService.GetPessoasAsync();

                    var pessoa = data.Where(x => x.Email == txtEmail.Text && x.Senha == txtSenha.Text).ToList();
                    if (pessoa.Count > 0)
                    {
                        Task task = Navigation.PushModalAsync(new Menu());

                    }
                    else
                    {
                        await DisplayAlertAsync("Erro", "Email e Senha incorretos", "OK");
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

        private void btnLogin_Clicked(object sender, EventArgs args)
        {
            Logar();
        }

        private void btnEsqueci_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new RecuperarSenha());
        }
        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            Task task = Navigation.PushModalAsync(new Cadastrar());
        }

    }
}
