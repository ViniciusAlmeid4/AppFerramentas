using AppFerramentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.QrCode.Internal;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLeitor : ContentPage
    {
        public PageLeitor()
        {
            InitializeComponent();
        }

        /*
         function async {
             var dados = new Pessoa{
                nome_funcionario = nome.text
                ...
            }
            var enviar = new PageFuncionario();
            enviar.BindingContext = dados;
            await Navigation.PushAsync(enviar);
        }
         */

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() => {
                
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
            
            if (codQR != null)
            {

                var enviar = new PageFerramentasCadastro();

                enviar.BindingContext = codQR.dados;
                await Navigation.PushAsync(enviar);

            }

        }

        private void btVerificarFerramenta_Clicked(object sender, EventArgs e)
        {

        }

        async void btCadastrarMaleta_Clicked(object sender, EventArgs e)
        {
            var codQR = new CodigoDeBarras
            {
                dados = scanResultText.Text.ToString()
            };

            if (codQR != null)
            {

                var enviar = new PageCadastroFuncionario();

                enviar.BindingContext = codQR.dados;
                await Navigation.PushAsync(enviar);

            }
        }
    }
}