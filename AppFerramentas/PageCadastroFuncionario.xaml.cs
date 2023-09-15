using AppFerramentas.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DisplayAlert("Cadastro", "Ferramenta cadastrada com sucesso!!", "Ok");
            Navigation.PopAsync();
        }
    }
}