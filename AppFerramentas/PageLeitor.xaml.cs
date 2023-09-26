using AppFerramentas.controller;
using AppFerramentas.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLeitor : ContentPage
    {
        public PageLeitor()
        {
            InitializeComponent();

            var registroBanco = Pessoas.VerificaBanco();

            if (registroBanco == false)
            {

                DisplayAlert("Nenhum usuario encontrado","Cadastre um usuario antes de usar o leitor!!", "Ok");

                Navigation.PopAsync();
                Navigation.PushAsync(new PageCadastroFuncionario());
            }
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (result.Text != "")
                {
                    scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                    btCadastrarFerramenta.IsEnabled = true;
                    btCadastrarFerramenta.BackgroundColor = Color.Gray;
                }
                else
                {
                    btCadastrarFerramenta.IsEnabled = false;
                    btCadastrarFerramenta.BackgroundColor = Color.BlanchedAlmond;
                }

            });
        }



        async void btCadastrarFerramenta_Clicked(object sender, EventArgs e)
        {
            var codQR = new CodigoDeBarras
            {
                dados = scanResultText.Text.ToString()
            };

            if (codQR.dados != "")
            {

                var enviar = new PageFerramentasCadastro();

                enviar.BindingContext = codQR;
                await Navigation.PushAsync(enviar);

            }

        }

        private void btVerificarFerramenta_Clicked(object sender, EventArgs e)
        {

        }

    }
}