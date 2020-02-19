using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCorreios.Servicos.Modelo;
using AppCorreios.Servicos;

namespace AppCorreios
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object sender, EventArgs args)
        {


            //TODO - Validações
            
            
            //Logica do Programa.
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCep(cep);
                    if(end != null) { 
                    RESULTADO.Text = String.Format("Endereço: Cep: {0}" +
                        "\n Logradouro: {1}" +
                        "\n Complemento: {2}" +
                        "\n Bairro: {3}" +
                        "\n Localidade: {4}" +
                        "\n UF: {5}" +
                        "\n Unidade: {6}" +
                        "\n IBGE: {7}" +
                        "\n Gia: {8}", end.cep, end.logadouro, end.completo, end.bairro, end.localidade, end.uf, end.unidade, end.ibge, end.gia);
                    }
                    else
                    {
                        DisplayAlert("Error", "Endereço nao encontrado para o CEP: " + cep,"OK","CANCEL");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Error", e.Message, "OK", "Cancel");
                }
                
            }
            
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;
            if(cep.Length != 8)
            {
                DisplayAlert("Error", "CEP Invalid ! O CEP deve conter 8 caracteres", "OK", "Cancel");
                valid = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep,out NovoCEP))
            {
                DisplayAlert("Error", "CEP Invalid ! O CEP deve contenter apenas numeros (n°)", "OK", "Cancel");
                valid = false;
            }
            return valid;
        }
    }
}
