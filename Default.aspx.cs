using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaLoja01
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CriptoLogin"] != null)
            {
                Session["CriptoLogin"] = "PAxakBVXAo8=";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}