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
    public partial class Clientes : System.Web.UI.Page
    {
        //Session["frmClientes"] = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Util util = new Util();
                //util.ListaDropdown(ddlBTipoUsuario, ((int)eTipoDrop.TipoUsuario));
                //util.ListaDropdown(ddlCtipousuario, ((int)eTipoDrop.TipoUsuario));

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
            //int indiceusuario = ddlBTipoUsuario.SelectedIndex;

            // buscar banco

            DataTable data = new DataTable();

            data.Columns.Add("IdCliente");
            data.Columns.Add("Nome");
            data.Columns.Add("CPF");
            data.Columns.Add("Contato");
            data.Columns.Add("Email");
            data.Columns.Add("Status");
            data.Rows.Add("1", "Joao", "10101010", "11987654321", "joao@hotmail.com", "Ativo");
            data.Rows.Add("2", "Maria", "10101010", "11987654321", "maria@hotmail.com", "Ativo");
            data.Rows.Add("3", "Antonio", "10101010", "11987654321", "antonio@hotmail.com", "Ativo");

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
            data.Columns.Add("IdCliente");
            data.Columns.Add("Nome");
            data.Columns.Add("CPF");
            data.Columns.Add("Contato");
            data.Columns.Add("Email");
            data.Columns.Add("Status");
            data.Rows.Add("1", "Joao", "10101010", "11987654321", "joao@hotmail.com", "Ativo");
            data.Rows.Add("2", "Maria", "10101010", "11987654321", "maria@hotmail.com", "Ativo");
            data.Rows.Add("3", "Antonio", "10101010", "11987654321", "antonio@hotmail.com", "Ativo");

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
            Pessoa pessoa = new Pessoa();

            if (btncadastro.Text == "Salvar")
            {
                pessoa.nome = txtnome.Value;
                pessoa.cpf = txtcpf.Value;
                pessoa.contato = txtcontato.Value;
                pessoa.email = txtemail.Value;
                //pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                pessoa.status = true;
            }
            else if (btncadastro.Text == "Alterar")
            {
                pessoa.nome = txtnome.Value;
                pessoa.cpf = txtcpf.Value;
                pessoa.contato = txtcontato.Value;
                pessoa.email = txtemail.Value;
                //pessoa.tipousuario = ddlCtipousuario.SelectedIndex;
                pessoa.status = true;
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
                //ddlBTipoUsuario.SelectedIndex = 0;
            }
            if (divCadastro.Visible)
            {
                //txtlogin.Value = string.Empty;
                //txtsenha.Value = string.Empty;
                txtnome.Value = string.Empty;
                txtcpf.Value = string.Empty;
                txtcontato.Value = string.Empty;
                txtemail.Value = string.Empty;
                flexSwitchCheckDefault.Checked = false;
                //ddlCtipousuario.SelectedIndex = 0;
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

            Pessoa pessoa = new Pessoa();

            pessoa.nome = "Joao";
            pessoa.cpf = "10101010";
            pessoa.contato = "11987654321";
            pessoa.email = "joao@hotmail.com";
            pessoa.status = Convert.ToBoolean(Convert.ToInt32(1));

            txtnome.Value = pessoa.nome;
            txtcpf.Value = pessoa.cpf;
            txtcontato.Value = pessoa.contato;
            txtemail.Value = pessoa.email;
            flexSwitchCheckDefault.Checked = true;

            btncadastro.Text = "Alterar";
        }














        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        Util util = new Util();
        //        TableBusca.Visible = true;
        //        util.ListaDropdown(ddlTipoCadastro, ((int)eTipoDrop.TipoCadastro));
        //        util.ListaDropdown(ddlATipoCadastro, ((int)eTipoDrop.TipoCadastro));
        //        util.ListaDropdown(ddlBTipoCadastro, ((int)eTipoDrop.TipoCadastro));
        //        //Session["frmPessoas"] = 0;
        //    }
        //}
        //protected void Cadastro_Click(object sender, EventArgs e)
        //{
        //    Pessoa pessoa = new Pessoa();

        //    pessoa.nome = txtNome.Text;
        //    //pessoa.cpf = Convert.ToInt64(TxtCPF.Text);
        //    //pessoa.contato = Convert.ToInt64(txtContato.Text);
        //    pessoa.email = txtEmail.Text;
        //    //pessoa.tipocadastro = ddlTipoCadastro.SelectedIndex;
        //    pessoa.status = true;

        //    Limpa_Campos();
        //}
        //protected void Busca_Click(object sender, EventArgs e)
        //{
        //    GridViewPessoas.DataSource = null;

        //    Usuario usuarios = new Usuario();
        //    Pessoa pessoa = new Pessoa();
        //    // parametros
        //    pessoa.nome = txtBNome.Text;
        //    //pessoa.tipocadastro = ddlBTipoCadastro.SelectedIndex;

        //    // busca / popula
        //    DataTable data = new DataTable();

        //    data.Columns.Add("IdPessoa");
        //    data.Columns.Add("Nome");
        //    data.Columns.Add("cpf");
        //    data.Columns.Add("Contato");
        //    data.Columns.Add("Email");
        //    data.Columns.Add("TipoCadastro");
        //    data.Columns.Add("Status");

        //    data.Rows.Add("1", "Joao", "10101010", "11987654321", "joao@hotmail.com", "Cliente", "Ativo");
        //    data.Rows.Add("2", "Maria", "10101010", "11987654321", "maria@hotmail.com", "Colaborador", "Ativo");
        //    data.Rows.Add("3", "Antonio", "10101010", "11987654321", "antonio@hotmail.com", "Cliente", "Ativo");

        //    GridRegistros.Visible = true;
        //    GridViewPessoas.DataSource = data;
        //    GridViewPessoas.DataBind();
        //    Limpa_Campos();
        //}
        //protected void Alterar_Click(object sender, EventArgs e)
        //{
        //    Pessoa pessoa = new Pessoa();

        //    pessoa.nome = txtANome.Text;
        //    //pessoa.cpf = Convert.ToInt64(txtACPF.Text);
        //    //pessoa.contato = Convert.ToInt64(txtAContato.Text);
        //    pessoa.email = txtAEmail.Text;
        //    //pessoa.tipocadastro = ddlATipoCadastro.SelectedIndex;
        //    pessoa.status = Convert.ToBoolean(Convert.ToInt32(rblAStatus.SelectedValue));

        //    Limpa_Campos();
        //}
        //protected void NovoCadastro_Click(object sender, EventArgs e)
        //{
        //    Limpa_Campos();
        //    TableBusca.Visible = false;
        //    TableCadastro.Visible = true;
        //    TableAlterar.Visible = false;
        //    GridRegistros.Visible = false;
        //}
        //protected void VoltarBuscar_Click(object sender, EventArgs e)
        //{

        //    Limpa_Campos();
        //    TableBusca.Visible = true;
        //    TableCadastro.Visible = false;
        //    TableAlterar.Visible = false;
        //    GridRegistros.Visible = false;
        //}
        //protected void Limpa_Campos()
        //{
        //    if (TableCadastro.Visible)
        //    {
        //        txtNome.Text = string.Empty;
        //        TxtCPF.Text = string.Empty;
        //        txtContato.Text = string.Empty;
        //        txtEmail.Text = string.Empty;
        //        ddlTipoCadastro.SelectedIndex = -1;
        //    }

        //    if (TableBusca.Visible)
        //    {
        //        txtBNome.Text = string.Empty;
        //        ddlBTipoCadastro.SelectedIndex = 0;
        //    }
        //    if (TableAlterar.Visible)
        //    {
        //        txtANome.Text = string.Empty;
        //        txtACPF.Text = string.Empty;
        //        txtAContato.Text = string.Empty;
        //        txtAEmail.Text = string.Empty;
        //        ddlATipoCadastro.SelectedIndex = 0;
        //        rblAStatus.SelectedIndex = -1;
        //    }
        //}
        //protected void GridViewPessoas_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    int idproduto = int.Parse(GridViewPessoas.DataKeys[e.NewEditIndex].Value.ToString());

        //    TableBusca.Visible = false;
        //    TableCadastro.Visible = false;
        //    TableAlterar.Visible = true;
        //    GridViewPessoas.Visible = false;

        //    // buscar dados da pessoa no banco
        //    Pessoa pessoa = new Pessoa();

        //    pessoa.nome = "Joao";
        //    //pessoa.cpf = Convert.ToInt64("10101010");
        //    //pessoa.contato = Convert.ToInt64("11987654321");
        //    pessoa.email = "joao@hotmail.com";
        //    pessoa.status = Convert.ToBoolean(Convert.ToInt32(1));

        //    txtANome.Text = pessoa.nome;
        //    txtACPF.Text = pessoa.cpf.ToString();
        //    txtAContato.Text = pessoa.contato.ToString();
        //    txtAEmail.Text = pessoa.email;
        //    rblAStatus.SelectedIndex = Convert.ToInt32(pessoa.status);
        //}
    }
}