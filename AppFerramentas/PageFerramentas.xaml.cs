using AppFerramentas.controller;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFerramentas : ContentPage
    {
        public PageFerramentas()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvFerramentas.ItemsSource = Ferramentas.ListarFerramentas();
        }

        private void lsvFerramentas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void btnNovaFerra_Clicked(object sender, EventArgs e)
        {
            // Navigation.PopAsync();
            Navigation.PushAsync(new PageLeitor());
        }
    }
}