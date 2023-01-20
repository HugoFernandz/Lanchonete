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
        //Session["frmProdutos"] = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Util util = new Util();
                util.ListaDropdown(ddlBTipoProduto, ((int)eTipoDrop.TipoProduto));
                util.ListaDropdown(ddlCTipoProduto, ((int)eTipoDrop.TipoProduto));

                divBuscar.Visible = true;
            }
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = true;
            divCadastro.Visible = false;

            string nomeusuario = BuscarProduto.Value;
            int indiceusuario = ddlBTipoProduto.SelectedIndex;

            // buscar banco


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


            GridViewProdutos.EditIndex = -1; // REMOVER CAMPOS EDITADOS
            GridViewProdutos.DataSource = data;
            GridViewProdutos.DataBind();

            Limpa_Campos();
        }
        protected void BuscaNome_Click(object sender, EventArgs e)
        {
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = true;
            divCadastro.Visible = false;

            string nomeproduto = txtBuscaNome.Value;

            // buscar banco

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

            data.Clear();

            GridViewProdutos.DataSource = data;
            GridViewProdutos.DataBind();

            Limpa_Campos();
        }
        protected void NovoCadastro_Click(object sender, EventArgs e)
        {

            Limpa_Campos();

            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;
            flexSwitchCheckDefault.Checked = true;
        }
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            if (btncadastro.Text == "Salvar")
            {
                produto.nome = txtnome.Value;
                produto.preco = Convert.ToDouble(txtpreco.Value);
                produto.quantidade = Convert.ToInt32(txtquantidade.Value);
                produto.tipoproduto = ddlCTipoProduto.SelectedIndex;
                produto.status = flexSwitchCheckDefault.Checked;
            }
            else if (btncadastro.Text == "Alterar")
            {
                produto.nome = txtnome.Value;
                produto.preco = Convert.ToDouble(txtpreco.Value);
                produto.quantidade = Convert.ToInt32(txtquantidade.Value);
                produto.tipoproduto = ddlCTipoProduto.SelectedIndex;
                produto.status = flexSwitchCheckDefault.Checked;
            }

            //msgCadastroSucesso.Visible = true;
            //txtsucesso.Visible = true;
            //txtsucesso.InnerText = "Produto Cadastrado com sucesso !!!";
            //msgCadastroErro.Visible = false;

            //msgCadastroErro.Visible = true;
            //txterro.Visible = true;
            //txterro.InnerText = "Erro ao Cadastrar Produto ! ";
            //msgCadastroSucesso.Visible = false;

            Limpa_Campos();
        }
        protected void VoltarBuscar_Click(object sender, EventArgs e)
        {
            if (btncadastro.Text == "Alterar") btncadastro.Text = "Salvar";

            Limpa_Campos();

            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = true;
            divRegistros.Visible = false;
            divCadastro.Visible = false;
        }
        protected void Limpa_Campos()
        {
            if (divBuscar.Visible)
            {
                BuscarProduto.Value = string.Empty;
                ddlBTipoProduto.SelectedIndex = 0;
            }
            if (divCadastro.Visible)
            {
                txtnome.Value = string.Empty;
                txtpreco.Value = string.Empty;
                txtquantidade.Value = string.Empty;
                ddlCTipoProduto.SelectedIndex = 0;
                flexSwitchCheckDefault.Checked = false;
            }
            if (divRegistros.Visible)
            {
                txtBuscaNome.Value = string.Empty;
            }
        }
        protected void GridViewProdutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;

            //int iduser = int.Parse(GridViewUsuarios.DataKeys[e.NewEditIndex].Value.ToString());

            // buscar dados do usuario no banco

            Produto produto = new Produto();

            produto.nome = "Itaipava Lata 360ml";
            produto.preco = 3.00;
            produto.quantidade = 10;
            produto.status = Convert.ToBoolean(Convert.ToInt32(1));
            produto.tipoproduto = 1;

            txtnome.Value = produto.nome;
            txtpreco.Value = produto.preco.ToString();
            txtquantidade.Value = produto.quantidade.ToString();
            ddlCTipoProduto.SelectedIndex = produto.tipoproduto;
            flexSwitchCheckDefault.Checked = produto.status;

            btncadastro.Text = "Alterar";
        }
    }
}