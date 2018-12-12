using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginView : System.Web.UI.Page
{
    LoginController controle = new LoginController();
    Login login = new Login();

    protected void btLogin_Click(object sender, EventArgs e)
    {
        ObterCampos();
        AutenticarUsuario();

        if (login.id == 0)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "openModal()", true);
        else
            Response.Redirect("/Views/Musica/PesquisaView.aspx");
    }

    private void AutenticarUsuario()
    {
        login = (Login)controle.AutenticarUsuario(login);
        Session["usuario"] = login;
    }

    private void ObterCampos()
    {
        login.login = tbUsuario.Text.Trim();
        login.senha = tbSenha.Text.Trim();
    }
}