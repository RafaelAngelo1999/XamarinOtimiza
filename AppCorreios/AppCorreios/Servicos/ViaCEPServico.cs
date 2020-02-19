using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using AppCorreios.Servicos.Modelo;
using Newtonsoft.Json;

namespace AppCorreios.Servicos
{
    public class ViaCEPServico
    {
        public static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCep (string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL,cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if(end.cep == null)
            {
                return null;
            }
            return end;
        }
    }
}