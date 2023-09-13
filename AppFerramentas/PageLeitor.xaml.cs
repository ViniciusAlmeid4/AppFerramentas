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

                /*
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
                
                */
            });
        }

        private void btCadastrarFerramenta_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new PageFerramentasCadastro());

        }

        private void btVerificarFerramenta_Clicked(object sender, EventArgs e)
        {

        }
    }
}