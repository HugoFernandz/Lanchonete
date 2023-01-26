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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["CriptoLogin"] != null)
            //{
            if (!Page.IsPostBack)
            {
                Util util = new Util();
                util.ListaDropdown(ddlBTipoUsuario, ((int)eTipoDrop.TipoUsuario));
                util.ListaDropdown(ddlCtipousuario, ((int)eTipoDrop.TipoUsuario));

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
            if (!string.IsNullOrEmpty(BuscarNome.Value) || ddlBTipoUsuario.SelectedIndex > 0)
            {
                Usuario user = new Usuario();
                user.pessoa = new Pessoa();
                user.pessoa.nome = BuscarNome.Value;
                user.pessoa.tipousuario = ddlBTipoUsuario.SelectedIndex;

                UsuarioBLL consulta = new UsuarioBLL();
                DataSet registro = consulta.Read(user);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewUsuarios.EditIndex = -1;
                GridViewUsuarios.DataSource = registro;
                GridViewUsuarios.DataBind();
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
                Usuario user = new Usuario();
                user.pessoa = new Pessoa();
                user.pessoa.nome = txtBuscaNome.Value;
                user.pessoa.tipousuario = 0;

                UsuarioBLL consulta = new UsuarioBLL();
                DataSet registro = consulta.Read(user);

                Limpa_Campos();
                msgCadastroSucesso.Visible = false;
                msgCadastroErro.Visible = false;
                divBuscar.Visible = false;
                divRegistros.Visible = true;
                divCadastro.Visible = false;

                GridViewUsuarios.EditIndex = -1;
                GridViewUsuarios.DataSource = registro;
                GridViewUsuarios.DataBind();
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
            txtsenha.Disabled = false;
            flexSwitchCheckDefault.Checked = true;
        }
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Usuario usuarios = new Usuario();
            usuarios.pessoa = new Pessoa();
            int status = 0;

            if (btncadastro.Text == "Cadastrar")
            {
                usuarios.login = txtlogin.Value;
                usuarios.senha = txtsenha.Value;
                usuarios.pessoa.nome = txtnome.Value;
                usuarios.pessoa.cpf = txtcpf.Value;
                usuarios.pessoa.contato = txtcontato.Value;
                usuarios.pessoa.email = txtemail.Value;
                usuarios.pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                usuarios.pessoa.status = flexSwitchCheckDefault.Checked;

                UsuarioBLL consulta = new UsuarioBLL();
                status = consulta.Create(usuarios);
            }
            else if (btncadastro.Text == "Alterar")
            {
                usuarios.idusuario = Convert.ToInt32(Session["IdUserAlterar"].ToString());
                usuarios.login = txtlogin.Value;
                usuarios.pessoa.nome = txtnome.Value;
                usuarios.pessoa.cpf = txtcpf.Value;
                usuarios.pessoa.contato = txtcontato.Value;
                usuarios.pessoa.email = txtemail.Value;
                usuarios.pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                usuarios.pessoa.status = flexSwitchCheckDefault.Checked;

                UsuarioBLL consulta = new UsuarioBLL();
                status = consulta.Update(usuarios);
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
            if (btncadastro.Text == "Alterar") btncadastro.Text = "Cadastrar";

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
                ddlBTipoUsuario.SelectedIndex = 0;
            }
            if (divCadastro.Visible)
            {
                txtlogin.Value = string.Empty;
                txtsenha.Value = string.Empty;
                txtnome.Value = string.Empty;
                txtcpf.Value = string.Empty;
                txtcontato.Value = string.Empty;
                txtemail.Value = string.Empty;
                flexSwitchCheckDefault.Checked = false;
                ddlCtipousuario.SelectedIndex = 0;
            }
            if (divRegistros.Visible)
            {
                txtBuscaNome.Value = string.Empty;
            }

            //txterro.InnerText = string.Empty;
            //txtsucesso.InnerText = string.Empty;

            if (Session["IdUserAlterar"] != null) Session["IdUserAlterar"] = null;
        }
        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Limpa_Campos();
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;

            Usuario user = new Usuario();
            user.idusuario = int.Parse(GridViewUsuarios.DataKeys[e.NewEditIndex].Value.ToString());

            UsuarioBLL consulta = new UsuarioBLL();
            user = consulta.Read_ID(user);

            txtlogin.Value = user.login;
            txtsenha.Disabled = true;
            txtnome.Value = user.pessoa.nome;
            txtcpf.Value = user.pessoa.cpf;
            txtcontato.Value = user.pessoa.contato;
            txtemail.Value = user.pessoa.email;
            ddlCtipousuario.SelectedIndex = user.pessoa.tipousuario;
            flexSwitchCheckDefault.Checked = true;

            btncadastro.Text = "Alterar";
            Session["IdUserAlterar"] = int.Parse(GridViewUsuarios.DataKeys[e.NewEditIndex].Value.ToString());
        }
        protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
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

                #region Tipo Usuario
                int TipoUsuario = Convert.ToInt32(((Label)e.Row.FindControl("lblTipoUsuario")).Text);
                eTipoUsuario _tipousuario = (eTipoUsuario)TipoUsuario;
                ((Label)e.Row.FindControl("lblTipoUsuario")).Text = _tipousuario.ToString();
                #endregion
            }
        }
    }
}