using SistemaLoja01.Entity;
using SistemaLoja01.Entity.BLL;
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
            //if (Session["CriptoLogin"] != null)
            //{
            if (!Page.IsPostBack)
            {
                Util util = new Util();
                util.ListaDropdown(ddlBTipoProduto, ((int)eTipoDrop.TipoProduto));
                util.ListaDropdown(ddlCTipoProduto, ((int)eTipoDrop.TipoProduto));

                divBuscar.Visible = true;
            }
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BuscarNome.Value) || ddlBTipoProduto.SelectedIndex > 0)
            {
                Produto prod = new Produto();
                prod.nome = BuscarNome.Value;
                prod.tipoproduto = ddlBTipoProduto.SelectedIndex;

                ProdutoBLL consulta = new ProdutoBLL();
                DataSet registro = consulta.Read(prod);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewProdutos.EditIndex = -1;
                GridViewProdutos.DataSource = registro;
                GridViewProdutos.DataBind();
            }
            else
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Obrigatório parametro para consulta !";
            }
        }
        protected void BuscaNome_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscaNome.Value))
            {
                Produto prod = new Produto();
                prod.nome = txtBuscaNome.Value;
                prod.tipoproduto = 0;

                ProdutoBLL consulta = new ProdutoBLL();
                DataSet registro = consulta.Read(prod);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewProdutos.EditIndex = -1;
                GridViewProdutos.DataSource = registro;
                GridViewProdutos.DataBind();
            }
            else
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Obrigatório parametro para consulta !";
            }
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
            int status = 0;
            Produto produto = new Produto();

            if (btncadastro.Text == "Salvar")
            {
                produto.nome = txtnome.Value;
                produto.preco = Convert.ToDouble(txtpreco.Value);
                produto.quantidade = Convert.ToInt32(txtquantidade.Value);
                produto.tipoproduto = ddlCTipoProduto.SelectedIndex;
                produto.status = flexSwitchCheckDefault.Checked;

                ProdutoBLL consulta = new ProdutoBLL();
                status = consulta.Create(produto);

            }
            else if (btncadastro.Text == "Alterar")
            {
                produto.idproduto = Convert.ToInt32(Session["IdUserAlterar"]);
                produto.nome = txtnome.Value;
                produto.preco = Convert.ToDouble(txtpreco.Value);
                produto.quantidade = Convert.ToInt32(txtquantidade.Value);
                produto.tipoproduto = ddlCTipoProduto.SelectedIndex;
                produto.status = flexSwitchCheckDefault.Checked;

                ProdutoBLL consulta = new ProdutoBLL();
                status = consulta.Update(produto);
            }

            if (status == 1)
            {
                msgCadastroSucesso.Visible = true;
                txtsucesso.Visible = true;
                txtsucesso.InnerText = "Salvo com sucesso ! ";
                msgCadastroErro.Visible = false;
            }
            else
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Erro ao salvar Usuário ! ";
                msgCadastroSucesso.Visible = false;
            }

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
                BuscarNome.Value = string.Empty;
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

            if (Session["IdUserAlterar"] != null) Session["IdUserAlterar"] = null;
        }
        protected void GridViewProdutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Limpa_Campos();
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;

            Produto produt = new Produto();
            produt.idproduto = int.Parse(GridViewProdutos.DataKeys[e.NewEditIndex].Value.ToString());

            ProdutoBLL consulta = new ProdutoBLL();
            produt = consulta.Read_ID(produt);

            txtnome.Value = produt.nome;
            txtpreco.Value = produt.preco.ToString();
            txtquantidade.Value = produt.quantidade.ToString();
            ddlCTipoProduto.SelectedIndex = produt.tipoproduto;
            flexSwitchCheckDefault.Checked = produt.status;

            btncadastro.Text = "Alterar";
            Session["IdUserAlterar"] = int.Parse(GridViewProdutos.DataKeys[e.NewEditIndex].Value.ToString());
        }
        protected void GridViewProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region Imagem Status
                bool status = Convert.ToBoolean(((Label)e.Row.FindControl("lblStatus")).Text);
                if (status)
                {
                    ((Image)e.Row.FindControl("imgStatus")).ImageUrl = "~/Images/desbloqueado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgStatus")).ImageUrl = "~/Images/bloqueado.png";
                }
                #endregion

                #region Tipo Produto
                int TipoProduto = Convert.ToInt32(((Label)e.Row.FindControl("lblTipoProduto")).Text);
                eTipoProduto _tipoproduto = (eTipoProduto)TipoProduto;
                ((Label)e.Row.FindControl("lblTipoProduto")).Text = _tipoproduto.ToString();
                #endregion
            }
        }
    }
}