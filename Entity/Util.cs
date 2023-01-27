using SistemaLoja01.Entity.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SistemaLoja01.Entity
{
    public class Util
    {
        public void ListaDropdown(DropDownList NomeDropDown, int TipoDropDown)
        {
            UsuarioBLL usuario = new UsuarioBLL();
            ClienteBLL cliente = new ClienteBLL();
            ProdutoBLL produto = new ProdutoBLL();

            switch (TipoDropDown)
            {
                case 1:
                    NomeDropDown.DataSource = Enum.GetNames(typeof(eTipoUsuario));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                case 2:
                    NomeDropDown.DataSource = Enum.GetNames(typeof(eTipoProduto));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                case 3:
                    NomeDropDown.DataValueField = "IdCliente";
                    NomeDropDown.DataTextField = "Nome";
                    NomeDropDown.DataSource = cliente.All();
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                case 4:
                    NomeDropDown.DataValueField = "IdProduto";
                    NomeDropDown.DataTextField = "Nome";
                    NomeDropDown.DataSource = produto.All();
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                case 5:
                    NomeDropDown.DataSource = Enum.GetNames(typeof(eFormaPagamento));
                    NomeDropDown.DataBind();
                    NomeDropDown.Items.Insert(0, " Selecione ");
                    break;
                    //case 5:
                    //    NomeDropDown.DataValueField = "IdUsuario";
                    //    NomeDropDown.DataTextField = "Nome";
                    //    NomeDropDown.DataSource = usuario.All();
                    //    NomeDropDown.DataBind();
                    //    NomeDropDown.Items.Insert(0, " Selecione ");
                    //    break;

            }
        }
    }
}