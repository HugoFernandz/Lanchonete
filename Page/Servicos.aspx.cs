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
    public partial class Servicos : System.Web.UI.Page
    {
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

            Servico servico = new Servico();
            servico.nomecliente = BuscarNome.Value;

            if (string.IsNullOrEmpty(BuscarNome.Value))
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Obrigatório parametro para consulta !";
            }
            else
            {
                ServicoBLL service = new ServicoBLL();
                DataSet dt = service.Read(servico);

                GridViewServicos.EditIndex = -1; // REMOVER CAMPOS EDITADOS
                GridViewServicos.DataSource = dt;
                GridViewServicos.DataBind();

                Limpa_Campos();
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

            Util util = new Util();
            util.ListaDropdown(ddlTipoCliente, ((int)eTipoDrop.Cliente));
            util.ListaDropdown(ddlCTipoProduto, ((int)eTipoDrop.Produto));
            util.ListaDropdown(ddlTipoPagamento, ((int)eTipoDrop.Pagamento));
        }
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Util util = new Util();
            Produto prod = new Produto();
            ProdutoBLL produto = new ProdutoBLL();

            rowfinaliza.Visible = true;


            prod.nome = ddlCTipoProduto.SelectedItem.ToString();
            DataSet dtproduto = produto.Read(prod);
            int qtdd = Convert.ToInt32(txtQuantidade.Value);
            double precoproduto = Convert.ToDouble(dtproduto.Tables[0].Rows[0]["Preco"].ToString());
            double totalproduto = precoproduto * qtdd;
            string nomecliente = ddlTipoCliente.SelectedItem.ToString();

            txtunidade.Value = "R$ " + precoproduto;
            txttotal.Value = "R$ " + totalproduto;
        }
        protected void VoltarBuscar_Click(object sender, EventArgs e)
        {
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
            }
            if (divCadastro.Visible)
            {
                ddlTipoCliente.SelectedIndex = 0;
                ddlTipoPagamento.SelectedIndex = 0;
                ddlCTipoProduto.SelectedIndex = 0;
                txtunidade.Value = string.Empty;
                txttotal.Value = string.Empty;
                txtQuantidade.Value = string.Empty;
            }
        }
        protected void btnfinalizar_Click(object sender, EventArgs e)
        {
            ServicoBLL cadastro = new ServicoBLL();
            ProdutoBLL produto = new ProdutoBLL();
            Servico servico = new Servico();
            Produto product = new Produto();

            servico.nomecliente = ddlTipoCliente.SelectedItem.ToString();
            servico.nomeproduto = ddlCTipoProduto.SelectedItem.ToString();
            servico.valorproduto = txtunidade.Value;
            servico.valortotal = txttotal.Value;
            servico.quantidade = Convert.ToInt32(txtQuantidade.Value);
            servico.Formapagamento = ddlTipoPagamento.SelectedItem.ToString();

            rowfinaliza.Visible = false;
            int retorno = cadastro.Create(servico);
            if(retorno == 1)
            {
                product.nome = ddlCTipoProduto.SelectedItem.ToString();
                product.quantidade = Convert.ToInt32(txtQuantidade.Value);
                int atualizaestoque = produto.DarBaixa(product);
                if (atualizaestoque == 1)
                {
                    msgCadastroSucesso.Visible = true;
                    txtsucesso.Visible = true;
                    txtsucesso.InnerText = "Cadastrado com sucesso";
                }
                else
                {
                    msgCadastroErro.Visible = true;
                    txterro.Visible = true;
                    txterro.InnerText = "Servico cadastrado, mas ocorreu um erro ao atualizar estoque ! ";
                }
                Limpa_Campos();
            }
            else
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Erro ao cadastar Serviço ! ";
            }
        }
    }
}