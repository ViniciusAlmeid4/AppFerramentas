﻿using AppFerramentas.controller;
using AppFerramentas.Models;
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
	public partial class PageUpDelFerramentas : ContentPage
	{
		public Ferramenta ferra;
		public PageUpDelFerramentas()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			BindingContext = this.ferra;
		}

		private void btnAtualizar_Clicked(object sender, EventArgs e)
		{
			Ferramentas.AtualizarFerramenta(ferra);
			Navigation.PopAsync();
        }

		private void btnApagar_Clicked(object sender, EventArgs e)
		{
			if (ferra.id_ferramenta != 0)
			{
				Ferramentas.ExcluirFerramenta(ferra);
				Navigation.PopAsync();
			}
        }
    }
}