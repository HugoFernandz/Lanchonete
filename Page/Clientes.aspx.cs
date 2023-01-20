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

            GridViewClientes.EditIndex = -1; // REMOVER CAMPOS EDITADOS
            GridViewClientes.DataSource = data;
            GridViewClientes.DataBind();

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

            GridViewClientes.DataSource = data;
            GridViewClientes.DataBind();

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
                pessoa.status = true;
            }
            else if (btncadastro.Text == "Alterar")
            {
                pessoa.nome = txtnome.Value;
                pessoa.cpf = txtcpf.Value;
                pessoa.contato = txtcontato.Value;
                pessoa.email = txtemail.Value;
                pessoa.status = true;
            }

            //msgCadastroSucesso.Visible = true;
            //txtsucesso.Visible = true;
            //txtsucesso.InnerText = "Cliente Cadastrado com sucesso !!!";
            //msgCadastroErro.Visible = false;

            //msgCadastroErro.Visible = true;
            //txterro.Visible = true;
            //txterro.InnerText = "Erro ao Cadastrar Cliente ! ";
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
        }
        protected void GridViewClientes_RowEditing(object sender, GridViewEditEventArgs e)
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
    }
}