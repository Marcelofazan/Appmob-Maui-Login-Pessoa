using AppMobile.Models;
using AppMobile.Service;

namespace AppMobile;

public partial class Cadastrar : ContentPage
{
    public Cadastrar()
    {
        InitializeComponent();
    }

    private async void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        if (Valida())
        {
            Pessoa novoPessoa = new Pessoa
            {
                RazaoSocial = txtRazaoSocial.Text.Trim(),
                CnpjCpf = txtCnpjCpf.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Usuario = txtUsuario.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
            };

            try
            {
                await PessoaService.AddPessoaAsync(novoPessoa);

                var confirmado = new Confirmado();
                confirmado.BindingContext = novoPessoa;
                Task task = Navigation.PushModalAsync(confirmado);
                LimpaPessoa();

            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Erro", ex.Message, "OK");
            }
        }
        else
        {
            await DisplayAlertAsync("Erro", "Dados inválidos...", "OK");
        }
    }

    private void LimpaPessoa()
    {
        txtRazaoSocial.Text = "";
        txtCnpjCpf.Text = "";
        txtEmail.Text = "";
        txtTelefone.Text = "";
        txtUsuario.Text = "";
        txtSenha.Text = "";
    }

    private bool Valida()
    {
        if (string.IsNullOrEmpty(txtRazaoSocial.Text) &&
            string.IsNullOrEmpty(txtCnpjCpf.Text) &&
            string.IsNullOrEmpty(txtEmail.Text) &&
            string.IsNullOrEmpty(txtTelefone.Text) &&
            string.IsNullOrEmpty(txtUsuario.Text) &&
            string.IsNullOrEmpty(txtSenha.Text))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void btnVoltar_Clicked(object sender, EventArgs args)
    {
        Task task = Navigation.PushModalAsync(new MainPage());
    }
}