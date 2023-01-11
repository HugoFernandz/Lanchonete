using SistemaLoja01.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLoja01.Page
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Util util = new Util();
                util.ListaDropdown(ddlTipoProduto, ((int)eTipoDrop.TipoProduto));
                util.ListaDropdown(ddlBTipoProduto, ((int)eTipoDrop.TipoProduto));
                //Session["frmUsuarios"] = 0;

                DataTable data = new DataTable();

                data.Columns.Add("TipoProduto"); 
                data.Columns.Add("Nome");
                data.Columns.Add("Preco");
                data.Columns.Add("quantidade");
                data.Columns.Add("Status");

                data.Rows.Add("Bebidas","Itaipava Lata 360ml","3,00","11","Ativo");
                data.Rows.Add("Bebidas","Skol Lata 360ml","3,50","10","Ativo");
                data.Rows.Add("Lanches","X-Tudo","20,00","15","Ativo");

                //GridViewUsuarios.DataSource = Enum.GetNames(typeof(ePerfil));
                GridViewProdutos.DataSource = data;
                GridViewProdutos.DataBind();
            }
        }
        // grid de busca
        // editar
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.nome = txtNome.Text;
            produto.preco = Convert.ToDouble(TxtPreco.Text);
            produto.quantidade = Convert.ToInt32(txtQuantidade.Text);
            produto.tipoproduto = ddlTipoProduto.SelectedIndex;
            // cadastra como status 1
            produto.status = true;

            Limpa_Campos();
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.nome = txtBNome.Text;
            produto.tipoproduto = ddlBTipoProduto.SelectedIndex;

            Limpa_Campos();
        }

        protected void Limpa_Campos()
        {
            if (TableCadastro.Visible)
            {
                txtNome.Text = string.Empty;
                TxtPreco.Text = string.Empty;
                txtQuantidade.Text = string.Empty;
                ddlTipoProduto.SelectedIndex = 0;
            }

            if (TableBusca.Visible)
            {
                txtBNome.Text = string.Empty;
                ddlBTipoProduto.SelectedIndex = 0;
            }
        }
    }
}