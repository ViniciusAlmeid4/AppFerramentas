﻿using AppFerramentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppFerramentas.controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEdicaoPessoa : ContentPage
    {
        public Pessoa pessoa { get; set; }
        public PageEdicaoPessoa()
        {

            InitializeComponent();

        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            BindingContext = this.pessoa;

        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                Pessoas.AtualizaFuncionario(txtNomeFuncionario.Text, txtSetor.Text, txtGerente.Text, txtCargo.Text);
                DisplayAlert("Dados Atualizados", "Os dados foram alterados com sucesso!", "OK");

            }
            catch(Exception ex)
            {
                DisplayAlert("Erro", ex.ToString(), "OK");
            }
            Navigation.PopAsync();
        }
        
        async private void btnExcluir_Clicked(object sender, EventArgs e)
        {

            try
            {

                string result = await DisplayPromptAsync("Excluir funcionario", "O funcionário será excluido e o app será fechado, caso queira fazer o cadastro de algum funcionário basta abri-lo novamente!!  Caso queira, digite 'SIM':", "OK");
                if(result.ToUpper() == "SIM")
                {
                    Pessoas.ExcluirFuncionario();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", "Erro: " + ex.ToString(), "Ok");

            }
            
        }
    }
}