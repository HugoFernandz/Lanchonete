using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Servico
    {
        public int id { get; set; }
        public string nomeproduto { get; set; }
        public string valorproduto { get; set; }
        public string valortotal { get; set; }
        public string nomecliente { get; set; }
        public int quantidade { get; set; }
        public DateTime data { get; set; }
        public string Formapagamento { get; set; }
    }
}