using AppFerramentas.controller;
using AppFerramentas.Models;
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
            var item = e.SelectedItem as Verificados;
            DisplayAlert("", "Ferramenta: \n-" + item.nome_ferramenta + "\n\n Funcionario: \n-" + item.nome_funcionario + "\n\n Data: \n-" + item.data_verificacao, "Sair");
        }
    }
}