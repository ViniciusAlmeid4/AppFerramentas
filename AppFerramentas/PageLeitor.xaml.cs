using AppFerramentas.controller;
using AppFerramentas.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFerramentas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLeitor : ContentPage
    {

        public PageLeitor()
        {
            InitializeComponent();

            var registroBanco = true;//Pessoas.VerificaBanco();

            if (registroBanco == false)
            {

                DisplayAlert("Nenhum usuario encontrado","Cadastre um usuario antes de usar o leitor!!", "Ok");

                Navigation.PopAsync();
                Navigation.PushAsync(new PageCadastroFuncionario());
            }
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (result.Text != "")
                {
                    scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                    btCadastrarFerramenta.IsEnabled = true;
                    btCadastrarFerramenta.BackgroundColor = Color.Gray;
                }
                else
                {
                    btCadastrarFerramenta.IsEnabled = false;
                    btCadastrarFerramenta.BackgroundColor = Color.BlanchedAlmond;
                }

            });
        }



        async void btCadastrarFerramenta_Clicked(object sender, EventArgs e)
        {
            var codQR = new CodigoDeBarras
            {
                dados = scanResultText.Text.ToString()
            };

            if (codQR.dados != "")
            {

                var enviar = new PageFerramentasCadastro();

                enviar.BindingContext = codQR;
                await Navigation.PushAsync(enviar);

            }

        }


		public List<Ferramenta> ferramentas;
        public List<Ferramenta> naoVerificadas;


		private void btVerificarFerramenta_Clicked(object sender, EventArgs e)
        {
            btCadastrarFerramenta.IsVisible = false;
            btVerificarFerramenta.IsVisible = false;

            slConFin.IsVisible = true;
            btConfirmar.IsVisible = true;
            btFinalizar.IsVisible = true;

            ferramentas = Ferramentas.ListarFerramentas();
            naoVerificadas = ferramentas;


        }

        private void btConfirmar_Clicked(object sender, EventArgs e)
        {

            foreach (var i in ferramentas.ToArray())
            {

                if (naoVerificadas == null)
                {

                    DisplayAlert("Tudo verificado","Aperte em finalizar para terminar as verificações","OK");
                    break;

                }

                if (i.codigo.ToString() == scanResultText.Text.ToString())
                {

                    Verificacao.Verifica(i.id_ferramenta.ToString());

                    try
                    {
                        
                        naoVerificadas.Remove(i);

                        scanResultText.Text = "";

                    }
                    catch (Exception ex)
                    {

                        DisplayAlert("Erro ao verificar", "Erro:" + ex.ToString(), "OK");

                    }
					
				}

            }

        }

        private void btFinalizar_Clicked(object sender, EventArgs e)
        {

            if (naoVerificadas.Count == 0)
            {
                DisplayAlert("Tudo Certo!!", "Todas as ferramentas foram verificadas!!", "OK");
            }
            else
            {
                string listaFerra = "", listaNVer = "";
                foreach(var i in ferramentas)
                {
                    listaFerra += "- " + i.nome_ferramenta.ToString();
                }
                foreach (var item in naoVerificadas)
                {
                    listaNVer += "- " + item.nome_ferramenta.ToString();
                }
                DisplayAlert("Ops!", "Da sua lista de ferramentas: " + listaFerra + "\n As seguintes não foram verificadas: " + listaNVer, "OK");
            }

            btCadastrarFerramenta.IsVisible = true;
            btVerificarFerramenta.IsVisible = true;

            slConFin.IsVisible = false;
            btConfirmar.IsVisible = false;
            btFinalizar.IsVisible = false;

            ferramentas = null;
            naoVerificadas = null;
        }
    }
}