using AppFerramentas.controller;
using System;
using Xamarin.Forms;

namespace AppFerramentas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var registroBanco = Pessoas.VerificaBanco();

            if (registroBanco == false)
            {

                DisplayAlert("Sem funcionario cadastrado", "Não há nenhum registro de funcionario. Por favor, cadastre-se!!", "Ir para cadastro!");
                Navigation.PushAsync(new PageCadastroFuncionario());

            }

        }



        private void btnLeitor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLeitor());
        }

        private void btnListaFerramentas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageFerramentas());
        }

        private void btnMeusDados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageFuncionario());
        }
    }
}
