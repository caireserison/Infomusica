using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Models.db;

/// <summary>
/// Descrição resumida de Login
/// </summary>
public class Login
{
    infomusicaEntities contextodb = new infomusicaEntities();

    public int ObterLogin(String capturado)
    {
        var retorno = contextodb.TB_USUARIOS.FirstOrDefault(x => x.login == capturado);
        return retorno != null ? retorno.id : -1;
    }

    public void IncluirLogin(ILogin capturado)
    {
        contextodb.TB_USUARIOS.Add(new TB_USUARIOS() { login=capturado.login, nome=capturado.nome, senha=capturado.senha });
        contextodb.SaveChanges();
    }
}