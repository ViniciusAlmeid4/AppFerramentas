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
            bool verificado = verificaCampos();

            if (verificado == true)
            {
                Pessoas.InserirFuncionario(txtNomeFuncionario.Text, txtSetor.Text, txtGerente.Text, txtCargo.Text);
                DisplayAlert("Cadastro", "Funcionário cadastradado com sucesso!!", "Ok");
                Navigation.PopAsync();
            }
            
        }

        private bool verificaCampos()
        {
            if (txtNomeFuncionario.Text == "")
            {
                DisplayAlert("Valor inválido", "Nome de funcionario não inserido!!", "OK");
                return false;
            }
            else if(txtSetor.Text == ""){
                DisplayAlert("Valor inválido", "Setor não inserido!!", "OK");
                return false;
            }
            else if (txtGerente.Text == "")
            {
                DisplayAlert("Valor inválido", "Nome do gerente não inserido!!", "OK");
                return false;
            }
            else if (txtCargo.Text == "")
            {
                DisplayAlert("Valor inválido", "Cargo não inserido!!", "OK");
                return false;
            }
            return true;
        }
	}
}