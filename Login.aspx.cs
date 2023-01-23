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

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.login = txtlogin.Value;
            user.senha = txtsenha.Value;

            //LoginBLL consulta = new LoginBLL(); 
            //DataSet registro = consulta.Read(user);

            //if (registro.Tables.Count > 0)
            //{
            
            Session["frmLogin"] = "testelogin";
            Response.Redirect("Default.aspx?t=10");

            //}
        }
    }
}