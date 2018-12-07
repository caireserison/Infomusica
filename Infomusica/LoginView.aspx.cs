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
        AutenticarUsuario();

        if (login.id == 0)
        {
            // TODO: Mensagem de usuário inexistente ou inválido
            return;
        }
        
        
        //TODO: REDIRECT
    }

    private void AutenticarUsuario()
    {
        login.login = tbUsuario.Text.Trim();
        login.senha = tbSenha.Text.Trim();

        login = (Login)controle.AutenticarUsuario(login);
        Session["usuario"] = login;
    }
}