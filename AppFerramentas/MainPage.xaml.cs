using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFerramentas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLeitor_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageLeitor());
        }

        private void btnListaFerramentas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageFerramentas());
        }
    }
}
