using SistemaLoja01.Entity;
using SistemaLoja01.Entity.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLoja01
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CriptoLogin"] != null)
            {
                Session["CriptoLogin"] = null;
            }
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.login = txtlogin.Value;
            user.senha = txtsenha.Value;

            UsuarioBLL consulta = new UsuarioBLL();
            DataSet registro = consulta.ReadLogin(user);

            if (registro.Tables[0].Rows.Count > 0)
            {
                msgCadastroErro.Visible = false;
                txterro.Visible = false;

                Session["CriptoLogin"] = "PAxakBVXAo8="; // Criptografia para Validar log-in
                Response.Redirect("Default.aspx");
            }
            else
            {
                msgCadastroErro.Visible = true;
                txterro.Visible = true;
                txterro.InnerText = "Login Incorreto ! ";
            }
        }
    }
}