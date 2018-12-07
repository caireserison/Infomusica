using Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MusicaModel
/// </summary>
public class MusicaModel
{
    infomusicaEntities contextodb = new infomusicaEntities();

    public IMusica ObterMusica(IMusica musica)
    {
        var retorno = contextodb.TB_MUSICAS.FirstOrDefault(x => x.idUsuario == musica.idUsuario);
        musica.idUsuario = retorno != null ? retorno.idUsuario : 0;
        musica.idFaixa = retorno != null ? retorno.idFaixa : 0;
        musica.dtInclusao = retorno != null ? retorno.dtInclusao : System.DateTime.MinValue;
        return musica;
    }

    public void IncluirMusica(IMusica musica)
    {
        contextodb.TB_MUSICAS.Add(new TB_MUSICAS() { idUsuario = musica.idUsuario, idFaixa = musica.idFaixa, dtInclusao = musica.dtInclusao });
        contextodb.SaveChanges();
    }
}