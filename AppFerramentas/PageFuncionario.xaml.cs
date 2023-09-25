using AppFerramentas.controller;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFuncionario : ContentPage
    {
        public PageFuncionario()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvMaleta.ItemsSource = Pessoas.ListarFuncionario();

        }

        private void lsvMaleta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}