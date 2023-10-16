using AppFerramentas.controller;
using AppFerramentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
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
                    if (result.Text != scanResultText.Text)
                    {
                        scanResultText.Text = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                        scanResultText.IsVisible = true;
                        scanResultText.TextColor = Color.Black;
                    }
                }

            });
        }



        async void btCadastrarFerramenta_Clicked(object sender, EventArgs e)
        {
            try
            {
                var codQR = new CodigoDeBarras
                {
                    dados = scanResultText.Text.ToString()
                };
                if (codQR.dados != "")
                {
                
                    if (Ferramentas.verificaRegistro(codQR.dados))
				    {
					    await DisplayAlert("Ferramenta já cadastrada!!", "Esse código já aparece nos registros das ferramentas", "OK");

                        scanResultText.TextColor = Color.Yellow;
				    }
				    else
				    {
                        var enviar = new PageFerramentasCadastro();

						scanResultText.Text = null;

						enviar.BindingContext = codQR;
                        await Navigation.PushAsync(enviar);

					}
				
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("OPA!", "Valor inválido no sensor", "OK");

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
            try
            {
                foreach (var i in ferramentas.ToArray())
                {

                    if (naoVerificadas.Count == 0)
                    {

                        DisplayAlert("Tudo verificado", "Aperte em finalizar para terminar as verificações", "OK");
                        break;

                    }

                    if (i.codigo.ToString() == scanResultText.Text.ToString())
                    {
                        foreach (var item in naoVerificadas)
                        {
                            if (item.codigo.ToString() == scanResultText.Text.ToString())
                            {
                                try
                                {
                                    Verificacao.Verifica(i.id_ferramenta.ToString());

                                    naoVerificadas.Remove(i);

                                    scanResultText.TextColor = Color.Green;
                                    return;
                                }
                                catch (Exception ex)
                                {
                                    DisplayAlert("Erro ao verificar", "Erro:" + ex.ToString(), "OK");

                                    scanResultText.Text = null;
                                    return;
                                }
                            }
                        }

                        DisplayAlert("Essa já foi", "Essa ferramenta já foi verificada!!", "OK");

                        scanResultText.TextColor = Color.Yellow;

                        return;
                    }

                }

                DisplayAlert("Codigo não cadastrado", "Esse codigo não foi encontrado em suas ferramentas!", "OK");

                scanResultText.TextColor = Color.Red;
            }
            catch (Exception ex)
            {

                DisplayAlert("Erro ao verificar", "Erro:" + ex.ToString(), "OK");

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
                string listaNVer = "";
                foreach (var item in naoVerificadas)
                {
                    listaNVer += "\n- " + item.nome_ferramenta.ToString();
                }
                DisplayAlert("Ops!", "As seguintes ferramentas não foram verificadas: " + listaNVer, "OK");
            }

            scanResultText.Text = null;
            scanResultText.IsVisible = false;

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