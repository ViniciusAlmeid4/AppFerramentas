using AppFerramentas.controller;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastroFuncionario : ContentPage
    {
        public PageCadastroFuncionario()
        {
            InitializeComponent();
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Pessoas.InserirFuncionario(txtNomeFuncionario.Text, txtSetor.Text, txtGerente.Text, txtCargo.Text, txtCodigo.Text);
            DisplayAlert("Cadastro", "Funcionário cadastradado com sucesso!!", "Ok");
            Navigation.PopAsync();
        }
    }
}