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
                //Session["frmStatus"] = 0;
            }
        }

        protected void Cadastro_Click(object sender, EventArgs e)
        {
            Pessoa PessoaUsuarios = new Pessoa();

            //PessoaUsuarios.Pessoa.
            string nome = txtNome.Text;
            string cpf = TxtCPF.Text;
            string contato = txtContato.Text;
            string email = txtEmail.Text;
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            int status = Convert.ToInt32(rblStatus.SelectedValue);

            int perfil = 0;
            if (ddlPerfil.SelectedIndex == 0) perfil = 0;
            else perfil = (int)Enum.Parse(typeof(ePerfil), ddlPerfil.SelectedValue);

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