using SistemaLoja01.Entity;
using System;
using System.Collections.Generic;
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
                util.ListaDropdown(ddlPerfil, ((int)eTipoDrop.Perfil));
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

            usuarios.pessoa = pessoa;
            usuarios.login = txtLogin.Text;
            usuarios.senha = txtSenha.Text;
            usuarios.status = Convert.ToBoolean(Convert.ToInt32(rblStatus.SelectedValue));
            usuarios.perfil = ddlPerfil.SelectedIndex;

            Limpa_Campos();
        }

        protected void Limpa_Campos()
        {
            if (TableCadastro.Visible)
            {
                txtNome.Text = string.Empty;
                TxtCPF.Text = string.Empty;
                txtContato.Text = string.Empty;
                txtLogin.Text = string.Empty;
                txtSenha.Text = string.Empty;

                rblStatus.SelectedIndex = -1;
                ddlPerfil.SelectedIndex = 0;
            }
        }
    }
}