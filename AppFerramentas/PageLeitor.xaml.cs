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

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() => {

                scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
            
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