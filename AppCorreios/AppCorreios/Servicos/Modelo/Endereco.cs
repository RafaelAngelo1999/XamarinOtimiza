using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppCorreios.Servicos.Modelo
{
    public class Endereco
    {
        public string cep { get; set; }
        public string logadouro { get; set; }
        public string completo { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }


    }
}