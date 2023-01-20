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
    public partial class Usuarios : System.Web.UI.Page
    {
        //Session["frmUsuarios"] = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Util util = new Util();
                util.ListaDropdown(ddlBTipoUsuario, ((int)eTipoDrop.TipoUsuario));
                util.ListaDropdown(ddlCtipousuario, ((int)eTipoDrop.TipoUsuario));

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

            string nomeusuario = BuscarNome.Value;
            int indiceusuario = ddlBTipoUsuario.SelectedIndex;

            // buscar banco

            DataTable data = new DataTable();

            data.Columns.Add("IdUsuario");
            data.Columns.Add("Nome");
            data.Columns.Add("CPF");
            data.Columns.Add("Contato");
            data.Columns.Add("Email");
            data.Columns.Add("Login");
            data.Columns.Add("Senha");
            data.Columns.Add("Status");
            data.Columns.Add("Perfil");
            data.Rows.Add("1", "Joao", "10101010", "11987654321", "joao@hotmail.com", "login1", "senha1", "Ativo", "Administrador");
            data.Rows.Add("2", "Maria", "10101010", "11987654321", "maria@hotmail.com", "login2", "senha2", "Ativo", "Administrador");
            data.Rows.Add("3", "Antonio", "10101010", "11987654321", "antonio@hotmail.com", "login3", "senha3", "Ativo", "Colaborador");

            GridViewUsuarios.EditIndex = -1; // REMOVER CAMPOS EDITADOS
            GridViewUsuarios.DataSource = data;
            GridViewUsuarios.DataBind();

            Limpa_Campos();
        }
        protected void BuscaNome_Click(object sender, EventArgs e)
        {
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = true;
            divCadastro.Visible = false;

            string nomeusuario = txtBuscaNome.Value;

            // buscar banco

            DataTable data = new DataTable();
            data.Columns.Add("IdUsuario");
            data.Columns.Add("Nome");
            data.Columns.Add("CPF");
            data.Columns.Add("Contato");
            data.Columns.Add("Email");
            data.Columns.Add("Login");
            data.Columns.Add("Senha");
            data.Columns.Add("Status");
            data.Columns.Add("Perfil");
            data.Rows.Add("1", "Joao", "10101010", "11987654321", "joao@hotmail.com", "login1", "senha1", "Ativo", "Administrador");
            data.Rows.Add("2", "Maria", "10101010", "11987654321", "maria@hotmail.com", "login2", "senha2", "Ativo", "Administrador");
            data.Rows.Add("3", "Antonio", "10101010", "11987654321", "antonio@hotmail.com", "login3", "senha3", "Ativo", "Colaborador");

            data.Clear();

            GridViewUsuarios.DataSource = data;
            GridViewUsuarios.DataBind();

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
            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();

            if (btncadastro.Text == "Cadastrar")
            {
                usuarios.login = txtlogin.Value;
                usuarios.senha = txtsenha.Value;

                pessoa.nome = txtnome.Value;
                pessoa.cpf = txtcpf.Value;
                pessoa.contato = txtcontato.Value;
                pessoa.email = txtemail.Value;
                pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                pessoa.status = true;

                usuarios.pessoa = pessoa;
            }
            else if (btncadastro.Text == "Alterar")
            {
                usuarios.login = txtlogin.Value;
                usuarios.senha = txtsenha.Value;

                pessoa.nome = txtnome.Value;
                pessoa.cpf = txtcpf.Value;
                pessoa.contato = txtcontato.Value;
                pessoa.email = txtemail.Value;
                pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                pessoa.status = true;

                usuarios.pessoa = pessoa;
            }

            //msgCadastroSucesso.Visible = true;
            //txtsucesso.Visible = true;
            //txtsucesso.InnerText = "Usuario Cadastrado com sucesso !!!";
            //msgCadastroErro.Visible = false;

            //msgCadastroErro.Visible = true;
            //txterro.Visible = true;
            //txterro.InnerText = "Erro ao Cadastrar Usuário ! ";
            //msgCadastroSucesso.Visible = false;

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
        }
        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            msgCadastroSucesso.Visible = false;
            msgCadastroErro.Visible = false;
            divBuscar.Visible = false;
            divRegistros.Visible = false;
            divCadastro.Visible = true;

            //int iduser = int.Parse(GridViewUsuarios.DataKeys[e.NewEditIndex].Value.ToString());

            // buscar dados do usuario no banco

            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();

            usuarios.login = "joao123";
            usuarios.senha = "joaoteste";
            pessoa.nome = "Joao";
            pessoa.cpf = "10101010";
            pessoa.contato = "11987654321";
            pessoa.email = "joao@hotmail.com";
            pessoa.status = Convert.ToBoolean(Convert.ToInt32(1));
            pessoa.tipousuario = 1;
            usuarios.pessoa = pessoa;

            txtlogin.Value = usuarios.login;
            txtsenha.Disabled = true;
            txtnome.Value = usuarios.pessoa.nome;
            txtcpf.Value = usuarios.pessoa.cpf;
            txtcontato.Value = usuarios.pessoa.contato;
            txtemail.Value = usuarios.pessoa.email;
            ddlCtipousuario.SelectedIndex = usuarios.pessoa.tipousuario;
            flexSwitchCheckDefault.Checked = true;

            btncadastro.Text = "Alterar";
        }
    }
}