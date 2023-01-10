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
                    NomeDropDown.DataSource = Enum.GetNames(typeof(ePerfil));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    //NomeDropDown.SelectedIndex = 0;
                    break;
            }
        }
    }
}