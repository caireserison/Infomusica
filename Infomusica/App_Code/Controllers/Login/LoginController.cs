using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Processos necessários para login e cadastro de usuário
/// </summary>
public class LoginController
{
    LoginModel model = new LoginModel();

    /// <summary>
    /// Capturar usuário
    /// </summary>
    /// <param name="login">Objeto contendo o id do usuário</param>
    /// <returns>Retorna objeto com do usuário</returns>
    public ILogin ObterUsuarioPorID(ILogin login)
    {
        return model.ObterUsuarioPorID(login);
    }

    /// <summary>
    /// Capturar id do usuário
    /// </summary>
    /// <param name="login">Objeto contendo o login do usuário</param>
    /// <returns>Retorna objeto com o id do usuário</returns>
    public ILogin ObterUsuarioPorLogin(ILogin login)
    {
        return model.ObterUsuarioPorLogin(login);
    }
    
    /// <summary>
    /// Cadastrar usuário
    /// </summary>
    /// <param name="login">Objeto contendo todas as informações do usuário</param>
    public void IncluirUsuario(ILogin login)
    {
        model.IncluirUsuario(login);
    }

    /// <summary>
    /// Valida login do usuário, retorando seu id
    /// </summary>
    /// <param name="login">Objeto contendo usuário e senha</param>
    /// <returns>Caso login seja válido, retorna objeto com id do usuário</returns>
    public ILogin AutenticarUsuario(ILogin login)
    {
        return model.AutenticarUsuario(login);
    }
}