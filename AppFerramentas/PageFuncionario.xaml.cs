using AppFerramentas.controller;
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