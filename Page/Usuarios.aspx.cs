﻿using SistemaLoja01.Entity;
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
            if (!Page.IsPostBack)
            {
                Util util = new Util();

                TableBusca.Visible = true;
                util.ListaDropdown(ddlBTipoUsuario, ((int)eTipoDrop.TipoUsuario));
                util.ListaDropdown(ddlTipoUsuario, ((int)eTipoDrop.TipoUsuario));
                util.ListaDropdown(ddlATipoUsuario, ((int)eTipoDrop.TipoUsuario));

                //Session["frmUsuarios"] = 0;
            }
        }
        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();

            pessoa.nome = txtNome.Text;
            pessoa.cpf = Convert.ToInt64(TxtCPF.Text);
            pessoa.contato = Convert.ToInt64(txtContato.Text);
            pessoa.email = txtEmail.Text;
            //pessoa.status = Convert.ToBoolean(Convert.ToInt32(rblStatus.SelectedValue));

            usuarios.pessoa = pessoa;
            usuarios.login = txtLogin.Text;
            usuarios.senha = txtSenha.Text;
            usuarios.tipousuario = ddlTipoUsuario.SelectedIndex;

            Limpa_Campos();
        }
        protected void Busca_Click(object sender, EventArgs e)
        {
            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();
            // parametros
            pessoa.nome = txtBNome.Text;
            usuarios.pessoa = pessoa;
            usuarios.tipousuario = ddlBTipoUsuario.SelectedIndex;

            // busca / popula
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

            data.Rows.Add("1","Joao", "10101010", "11987654321", "joao@hotmail.com", "login1", "senha1", "Ativo", "Administrador");
            data.Rows.Add("2","Maria", "10101010", "11987654321", "maria@hotmail.com", "login2", "senha2", "Ativo", "Administrador");
            data.Rows.Add("3","Antonio", "10101010", "11987654321", "antonio@hotmail.com", "login3", "senha3", "Ativo", "Colaborador");

            GridRegistros.Visible = true;
            GridViewUsuarios.DataSource = data;
            GridViewUsuarios.DataBind();

            Limpa_Campos();
        }
        protected void Alterar_Click(object sender, EventArgs e)
        {
            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();

            pessoa.nome = txtANome.Text;
            pessoa.cpf = Convert.ToInt64(txtACPF.Text);
            pessoa.contato = Convert.ToInt64(txtAContato.Text);
            pessoa.email = txtAEmail.Text;
            pessoa.status = Convert.ToBoolean(Convert.ToInt32(rblAStatus.SelectedValue));

            usuarios.pessoa = pessoa;
            usuarios.tipousuario = ddlATipoUsuario.SelectedIndex;

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
                TxtCPF.Text = string.Empty;
                txtContato.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;

                ddlTipoUsuario.SelectedIndex = 0;
            }

            if (TableBusca.Visible)
            {
                txtBNome.Text = string.Empty;
                ddlBTipoUsuario.SelectedIndex = 0;
            }

            if (TableAlterar.Visible)
            {
                txtANome.Text = string.Empty;
                txtACPF.Text = string.Empty;
                txtAContato.Text = string.Empty;
                txtAEmail.Text = string.Empty;

                ddlTipoUsuario.SelectedIndex = 0;
                rblAStatus.SelectedIndex = -1;
            }
        }
        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int iduser = int.Parse(GridViewUsuarios.DataKeys[e.NewEditIndex].Value.ToString());

            // buscar dados do usuario no banco

            Usuario usuarios = new Usuario();
            Pessoa pessoa = new Pessoa();

            pessoa.nome = "Joao";
            pessoa.cpf = Convert.ToInt64("10101010");
            pessoa.contato = Convert.ToInt64("11987654321");
            pessoa.email = "joao@hotmail.com";
            pessoa.status = Convert.ToBoolean(Convert.ToInt32(1));
            usuarios.pessoa = pessoa;
            usuarios.tipousuario = 1;

            TableBusca.Visible = false;
            TableCadastro.Visible = false;
            TableAlterar.Visible = true;
            GridRegistros.Visible = false;

            txtANome.Text = pessoa.nome;
            txtACPF.Text = pessoa.cpf.ToString();
            txtAContato.Text = pessoa.contato.ToString();
            txtAEmail.Text = pessoa.email;
            rblAStatus.SelectedIndex = Convert.ToInt32(pessoa.status);
            ddlATipoUsuario.SelectedIndex = usuarios.tipousuario;
        }
    }
}