using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Produto
    {
        public string nome { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public int tipoproduto { get; set; }
        public bool status { get; set; }
    }
}