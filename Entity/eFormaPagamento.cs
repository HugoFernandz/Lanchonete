using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLoja01.Entity
{
    public enum eFormaPagamento
    {
        Selecione = 0,
        A_Vista = 1,
        Credito = 2,
        Debito = 3,
        Pix = 4,
        Em_Aberto = 5
    }
}