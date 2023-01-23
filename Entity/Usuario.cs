using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public class Usuario
    {
        public Pessoa pessoa { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        
    }
}