using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Pessoa
    {
        public string nome { get; set; }
        public long cpf { get; set; }
        public long contato { get; set; }
        public string email { get; set; }
    }
}