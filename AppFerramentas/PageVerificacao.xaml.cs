using AppFerramentas.controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageVerificacao : ContentPage
    {
        public PageVerificacao()
        {
            InitializeComponent();
            lsvVerificados.ItemsSource = Verificacao.ListarVerificacao();
        }

        private void lsvVerificados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new PageLeitor());
        }
    }
}