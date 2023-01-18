using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaLoja01.Entity
{
    public class Util
    {
        public void ListaDropdown(DropDownList NomeDropDown, int TipoDropDown)
        {
            switch (TipoDropDown)
            {
                case 1:
                    NomeDropDown.DataSource = Enum.GetNames(typeof(eTipoUsuario));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                //case 2:
                //    NomeDropDown.DataSource = Enum.GetNames(typeof(eTipoCadastro));
                //    NomeDropDown.DataBind();
                //    NomeDropDown.Items.Insert(0, " Selecione ");
                //    break;
                case 3:
                    NomeDropDown.DataSource = Enum.GetNames(typeof(eTipoProduto));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
            }
        }
    }
}