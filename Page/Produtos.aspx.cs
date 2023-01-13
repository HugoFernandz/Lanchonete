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
                TableBusca.Visible = true;
                util.ListaDropdown(ddlTipoProduto, ((int)eTipoDrop.TipoProduto));
                util.ListaDropdown(ddlBTipoProduto, ((int)eTipoDrop.TipoProduto));
                util.ListaDropdown(ddlATipoProduto, ((int)eTipoDrop.TipoProduto));
                //Session["frmProdutos"] = 0;
            }
        }
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.nome = txtNome.Text;
            produto.preco = Convert.ToDouble(TxtPreco.Text);
            produto.quantidade = Convert.ToInt32(txtQuantidade.Text);
            produto.tipoproduto = ddlTipoProduto.SelectedIndex;
            produto.status = true;

            Limpa_Campos();
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            GridViewProdutos.DataSource = null;
            GridViewProdutos.DataBind();
            GridRegistros.Visible = true;

            Produto produto = new Produto();
            // parametros
            produto.nome = txtBNome.Text;
            produto.tipoproduto = ddlBTipoProduto.SelectedIndex;

            // busca / popula
            DataTable data = new DataTable();

            data.Columns.Add("IdProduto");
            data.Columns.Add("TipoProduto");
            data.Columns.Add("Nome");
            data.Columns.Add("Preco");
            data.Columns.Add("quantidade");
            data.Columns.Add("Status");

            data.Rows.Add("1", "Bebidas", "Itaipava Lata 360ml", "3,00", "11", "Ativo");
            data.Rows.Add("2", "Bebidas", "Skol Lata 360ml", "3,50", "10", "Ativo");
            data.Rows.Add("3", "Lanches", "X-Tudo", "20,00", "15", "Ativo");

            GridViewProdutos.DataSource = data;
            GridViewProdutos.DataBind();
            Limpa_Campos();
        }
        protected void Alterar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.nome = txtANome.Text;
            produto.preco = Convert.ToDouble(txtAPreco.Text);
            produto.quantidade = Convert.ToInt32(txtAQuantidade.Text);
            produto.tipoproduto = ddlATipoProduto.SelectedIndex;
            produto.status = Convert.ToBoolean(Convert.ToInt32(rblAStatus.SelectedValue));

            Limpa_Campos();
        }
        protected void NovoCadastro_Click(object sender, EventArgs e)
        {
            Limpa_Campos();
            TableBusca.Visible = false;
            TableCadastro.Visible = true;
            TableAlterar.Visible = false;
            GridRegistros.Visible = false;
        }
        protected void VoltarBuscar_Click(object sender, EventArgs e)
        {
            Limpa_Campos();
            TableBusca.Visible = true;
            TableCadastro.Visible = false;
            TableAlterar.Visible = false;
            GridRegistros.Visible = false;
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

            if (TableAlterar.Visible)
            {
                txtANome.Text = string.Empty;
                txtAPreco.Text = string.Empty;
                txtAQuantidade.Text = string.Empty;
                ddlATipoProduto.SelectedIndex = 0;
                rblAStatus.SelectedIndex = -1;
            }
        }
        protected void GridViewProdutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idproduto = int.Parse(GridViewProdutos.DataKeys[e.NewEditIndex].Value.ToString());

            TableBusca.Visible = false;
            TableCadastro.Visible = false;
            TableAlterar.Visible = true;
            GridRegistros.Visible = false;

            // buscar dados do produto no banco
            Produto produto = new Produto();

            produto.nome = "Itaipava Lata 360ml";
            produto.preco = 3.00;
            produto.quantidade = 10;
            produto.status = Convert.ToBoolean(Convert.ToInt32(1));
            produto.tipoproduto = 1;

            txtANome.Text = produto.nome;
            txtAPreco.Text = produto.preco.ToString();
            txtAQuantidade.Text = produto.quantidade.ToString();
            rblAStatus.SelectedIndex = Convert.ToInt32(produto.status);
            ddlATipoProduto.SelectedIndex = produto.tipoproduto;
        }
    }
}