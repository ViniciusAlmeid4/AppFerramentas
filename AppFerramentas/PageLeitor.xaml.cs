using AppFerramentas.controller;
using AppFerramentas.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLeitor : ContentPage
    {
        public List<Ferramenta> ferramentas;
        public List<Pessoa> pessoa;

        public PageLeitor()
        {
            InitializeComponent();

            var registroBanco = true;//Pessoas.VerificaBanco();

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
            btCadastrarFerramenta.IsVisible = false;
            btVerificarFerramenta.IsVisible = false;

            slConFin.IsVisible = true;
            btConfirmar.IsVisible = true;
            btFinalizar.IsVisible = true;

            ferramentas = Ferramentas.ListarCodigo();
        }

        private void btConfirmar_Clicked(object sender, EventArgs e)
        {
            foreach (var i in ferramentas)
            {
                if (i.codigo.ToString() == scanResultText.Text.ToString())
                {
                    Verificacao.Verifica(i.id_ferramenta.ToString());
                }
            }
            
        }

        private void btFinalizar_Clicked(object sender, EventArgs e)
        {

        }
    }
}