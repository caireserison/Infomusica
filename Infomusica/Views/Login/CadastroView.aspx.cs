using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastroView : System.Web.UI.Page
{
    LoginController controle = new LoginController();
    Login login = new Login();

    protected void btCadastrar_Click(object sender, EventArgs e)
    {
        ObterCampos();

        if (ValidarUsuarioExistente())
        {
            Response.Redirect("/Views/Login/LoginView.aspx");
            return;
        }

        IncluirUsuario();
        Response.Redirect("/Views/Musica/PesquisaView.aspx");
    }

    private bool ValidarUsuarioExistente()
    {
        return controle.ObterUsuarioPorLogin(login).id > 0 ? true : false;
    }

    private void IncluirUsuario()
    {
        controle.IncluirUsuario(login);
        login = (Login)controle.ObterUsuarioPorLogin(login);
        Session["usuario"] = login;
    }

    private void ObterCampos()
    {
        login.nome = tbNomeUsuario.Text;
        login.login = tbUsuario.Text;
        login.senha = tbSenha.Text;
    }
}