using AppFerramentas.controller;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFerramentasCadastro : ContentPage
    {
        public PageFerramentasCadastro()
        {
            InitializeComponent();
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Ferramentas.InserirFerramenta(txtTipo.Text, txtNomeFerramenta.Text, txtCodigo.Text);
            DisplayAlert("Cadastro", "Ferramenta cadastrada com sucesso!!", "Ok");
            Navigation.PopAsync();
        }
    }
}