﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Models.db;

/// <summary>
/// Descrição resumida de Login
/// </summary>
public class LoginModel
{
    infomusicaEntities contextodb = new infomusicaEntities();

    public ILogin ObterUsuarioPorID(ILogin usuario)
    {
        var retorno = contextodb.TB_USUARIOS.FirstOrDefault(x => x.id == usuario.id);
        return AtribuirPropriedades(retorno);
    }
    
    public ILogin ObterUsuarioPorLogin(ILogin usuario)
    {
        var retorno = contextodb.TB_USUARIOS.FirstOrDefault(x => x.login == usuario.login);
        return AtribuirPropriedades(retorno);
    }

    public void IncluirUsuario(ILogin usuario)
    {
        contextodb.TB_USUARIOS.Add(new TB_USUARIOS() { login=usuario.login, nome=usuario.nome, senha=usuario.senha });
        contextodb.SaveChanges();
    }

    public ILogin AutenticarUsuario(ILogin usuario)
    {
        var retorno = contextodb.TB_USUARIOS.FirstOrDefault(x => x.login == usuario.login && x.senha == usuario.senha);
        return AtribuirPropriedades(retorno);
    }

    private static Login AtribuirPropriedades(TB_USUARIOS retorno)
    {
        return new Login()
        {
            id = retorno != null ? retorno.id : 0,
            login = retorno != null ? retorno.login : String.Empty,
            nome = retorno != null ? retorno.nome : String.Empty
        };
    }
}