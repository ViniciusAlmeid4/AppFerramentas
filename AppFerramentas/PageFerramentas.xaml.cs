using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppFerramentas.controller;
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
            
        }

        private void btnNovaFerra_Clicked(object sender, EventArgs e)
        {
            // Navigation.PopAsync();
            Navigation.PushAsync(new PageLeitor());
        }
    }
}