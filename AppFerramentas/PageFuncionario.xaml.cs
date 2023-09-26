using AppFerramentas.controller;
using AppFerramentas.Models;
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

        private async void lsvMaleta_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarPessoa(e.SelectedItem as Pessoa);
        }

        void NavegarPessoa(Pessoa pessoa)
        {
            PageEdicaoPessoa pageEdicaoPessoa = new PageEdicaoPessoa();
            pageEdicaoPessoa.pessoa = pessoa;
            Navigation.PushAsync(pageEdicaoPessoa);
        }

    }
}