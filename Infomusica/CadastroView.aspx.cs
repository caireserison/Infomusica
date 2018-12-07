﻿using System;
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
        if (ValidarUsuarioExistente())
        {
            // TODO: Mensagem de usuário existente (ou validar senha e logar)
            return;
        }

        IncluirUsuario();
        // TODO: REDIRECT
    }

    private bool ValidarUsuarioExistente()
    {
        login.login = tbUsuario.Text;
        login.senha = tbSenha.Text;
        
        return controle.ObterUsuario(login).id > 0 ? true : false;
    }

    private void IncluirUsuario()
    {
        login.login = tbUsuario.Text;
        login.senha = tbSenha.Text;

        controle.IncluirUsuario(login);
        controle.ObterUsuario(login);
        Session["usuario"] = login;
    }
}