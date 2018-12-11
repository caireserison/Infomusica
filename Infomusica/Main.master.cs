using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{

    Login usuario = new Login();

    protected void Page_Load(object sender, EventArgs e)
    {
        VerificarSession();
    }

    private void VerificarSession()
    {
        usuario = (Login)Session["usuario"];

        if (usuario == null)
        {
            txNomeUsuario.Visible = false;
            lbLogoff.Visible = false;
        }
        else
        {
            txNomeUsuario.Text = "Olá " + usuario.nome;
            lbLogoff.Text = "Logoff";
        }
    }

    protected void lbLogoff_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Views/Login/LoginView.aspx");

    }
}
