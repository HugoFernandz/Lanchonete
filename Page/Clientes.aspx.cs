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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CriptoLogin"] != null)
            {
                if (!Page.IsPostBack)
                {
                    divBuscar.Visible = true;
                }
            }
            else
            {
                Response.Redirect("https://localhost:44335/Login.aspx");
            }
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BuscarNome.Value))
            {
                Pessoa user = new Pessoa();
                user.nome = BuscarNome.Value;

                ClienteBLL consulta = new ClienteBLL();
                DataSet registro = consulta.Read(user);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewClientes.EditIndex = -1;
                GridViewClientes.DataSource = registro;
                GridViewClientes.DataBind();
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
                Pessoa user = new Pessoa();
                user.nome = txtBuscaNome.Value;

                ClienteBLL consulta = new ClienteBLL();
                DataSet registro = consulta.Read(user);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewClientes.EditIndex = -1;
                GridViewClientes.DataSource = registro;
                GridViewClientes.DataBind();
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
            Pessoa cliente = new Pessoa();
            int status = 0;

            if (btncadastro.Text == "Salvar")
            {
                cliente.nome = txtnome.Value;
                cliente.cpf = txtcpf.Value;
                cliente.contato = txtcontato.Value;
                cliente.email = txtemail.Value;
                cliente.status = flexSwitchCheckDefault.Checked;

                ClienteBLL consulta = new ClienteBLL();
                status = consulta.Create(cliente);
            }
            else if (btncadastro.Text == "Alterar")
            {
                cliente.idpessoa = Convert.ToInt32(Session["IdUserAlterar"].ToString());
                cliente.nome = txtnome.Value;
                cliente.cpf = txtcpf.Value;
                cliente.contato = txtcontato.Value;
                cliente.email = txtemail.Value;
                cliente.status = flexSwitchCheckDefault.Checked;

                ClienteBLL consulta = new ClienteBLL();
                status = consulta.Update(cliente);
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
                txterro.InnerText = "Erro ao salvar Cliente ! ";
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
            }
            if (divCadastro.Visible)
            {
                txtnome.Value = string.Empty;
                txtcpf.Value = string.Empty;
                txtcontato.Value = string.Empty;
                txtemail.Value = string.Empty;
                flexSwitchCheckDefault.Checked = false;
            }
            if (divRegistros.Visible)
            {
                txtBuscaNome.Value = string.Empty;
            }

            if (Session["IdUserAlterar"] != null) Session["IdUserAlterar"] = null;
        }
        protected void GridViewClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Limpa_Campos();
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;

            Pessoa user = new Pessoa();
            user.idpessoa = int.Parse(GridViewClientes.DataKeys[e.NewEditIndex].Value.ToString());

            ClienteBLL consulta = new ClienteBLL();
            user = consulta.Read_ID(user);

            txtnome.Value = user.nome;
            txtcpf.Value = user.cpf;
            txtcontato.Value = user.contato;
            txtemail.Value = user.email;
            flexSwitchCheckDefault.Checked = true;

            btncadastro.Text = "Alterar";
            Session["IdUserAlterar"] = int.Parse(GridViewClientes.DataKeys[e.NewEditIndex].Value.ToString());
        }
        protected void GridViewClientes_RowDataBound(object sender, GridViewRowEventArgs e)
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
            }
        }
    }
}