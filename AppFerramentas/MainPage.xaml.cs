using AppFerramentas.controller;
using System;
using Xamarin.Forms;

namespace AppFerramentas
{
    public partial class MainPage : ContentPage
    {
        // https://learn.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/controls/pages


        public MainPage()
        {
            InitializeComponent();

            var registroBanco = true;//Pessoas.VerificaBanco();

            if (registroBanco == false)
            {
                
                Navigation.PushAsync(new PageCadastroFuncionario());
                DisplayAlert("Sem funcionario cadastrado", "Não há nenhum registro de funcionario. Por favor, cadastre-se!!", "OK");

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

        private void btnListaVerificados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageVerificacao());
        }
    }
}
