using AppFerramentas.controller;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppFerramentas.Models;

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
            if(e.SelectedItem != null)
            {
                novaPageUpDel(e.SelectedItem as Ferramenta);
            }
        }

        void novaPageUpDel(Ferramenta ferra)
        {
            PageUpDelFerramentas updel = new PageUpDelFerramentas();
            updel.ferra = ferra;
            Navigation.PushAsync(updel);
        }

        private void btnNovaFerra_Clicked(object sender, EventArgs e)
        {
            // Navigation.PopAsync();
            Navigation.PushAsync(new PageLeitor());
        }
    }
}