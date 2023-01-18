using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Pessoa
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string contato { get; set; }
        public string email { get; set; }
        public int tipousuario { get; set; }
        public bool status { get; set; }

    }
}