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
    public partial class Servicos : System.Web.UI.Page
    {
        //Session["frmServicos"] = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

            string nomecliente = txtCliente.Value;
            //DateTime databusca = Convert.ToDateTime(txtData.Value);

            // buscar banco


            DataTable data = new DataTable();

            data.Columns.Add("IdServico");
            data.Columns.Add("IdCliente");
            data.Columns.Add("NomeCliente");
            data.Columns.Add("FormaPagamento");
            data.Columns.Add("Atendente");
            data.Columns.Add("IdProduto");
            data.Columns.Add("NomeProduto");
            data.Columns.Add("Quantidade");
            data.Columns.Add("Preco");
            data.Columns.Add("TotalProduto");

            data.Rows.Add("1", "1", "João", "Debito", "José", "1", "Itaipava Lata 360ml", "2", "3,00", "6,00");
            data.Rows.Add("2", "2", "Maria", "Credito", "José", "2", "Skol Lata 360ml", "2", "5,00", "10,00");
            data.Rows.Add("3", "3", "Paulo", "Pix", "José", "3", "X-Tudo", "2", "10,00", "20,00");


            GridViewServicos.EditIndex = -1; // REMOVER CAMPOS EDITADOS
            GridViewServicos.DataSource = data;
            GridViewServicos.DataBind();

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

            data.Columns.Add("IdServico");
            data.Columns.Add("IdCliente");
            data.Columns.Add("NomeCliente");
            data.Columns.Add("FormaPagamento");
            data.Columns.Add("Atendente");
            data.Columns.Add("IdProduto");
            data.Columns.Add("NomeProduto");
            data.Columns.Add("Quantidade");
            data.Columns.Add("Preco");
            data.Columns.Add("TotalProduto");

            data.Rows.Add("1", "1", "João", "Em aberto", "José", "1", "Itaipava Lata 360ml", "2", "3,00", "6,00");
            data.Rows.Add("2", "2", "Maria", "Em aberto", "José", "2", "Skol Lata 360ml", "2", "5,00", "10,00");
            data.Rows.Add("3", "3", "Paulo", "Em aberto", "José", "3", "X-Tudo", "2", "10,00", "20,00");

            data.Clear();

            GridViewServicos.DataSource = data;
            GridViewServicos.DataBind();

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
                //BuscarProduto.Value = string.Empty;
                //ddlBTipoProduto.SelectedIndex = 0;
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