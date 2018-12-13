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

    public IMusica ObterMusicaPorUsuario(IMusica musica)
    {
        var retorno = contextodb.TB_MUSICAS.FirstOrDefault(x => x.idUsuario == musica.idUsuario);
        return AtribuirPropriedadesMusica(retorno);
    }
    
    public List<Musica> ObterMusicaPorData(IMusica musica)
    {
        List<Musica> musicas = new List<Musica>();
        var retorno = contextodb.TB_MUSICAS.Where(x => x.dtInclusao == musica.dtInclusao).ToList<TB_MUSICAS>();

        foreach (var item in retorno)
            musicas.Add((Musica)AtribuirPropriedadesMusica(item));
        
        return musicas.OrderByDescending(x => x.idMusica).ToList<Musica>();
    }

    public IMusica ObterMusicaPorUsuarioData(IMusica musica)
    {
        var retorno = contextodb.TB_MUSICAS.FirstOrDefault(x => x.idUsuario == musica.idUsuario && x.dtInclusao == musica.dtInclusao);
        return AtribuirPropriedadesMusica(retorno);
    }

    public void IncluirMusica(IMusica musica)
    {
        contextodb.TB_MUSICAS.Add(new TB_MUSICAS() { idUsuario = musica.idUsuario, idFaixa = musica.idFaixa, dtInclusao = musica.dtInclusao });
        contextodb.SaveChanges();
    }
    
    public void RemoverMusicaPorUsuarioData(IMusica musica)
    {
        var deletar = contextodb.TB_MUSICAS.Where(x => x.idUsuario == musica.idUsuario && x.dtInclusao == musica.dtInclusao).FirstOrDefault();
        contextodb.TB_MUSICAS.Remove(deletar);
        contextodb.SaveChanges();
    }

    private static IMusica AtribuirPropriedadesMusica(TB_MUSICAS retorno)
    {
        return new Musica()
        {
            idMusica = retorno != null ? retorno.idMusica : 0,
            idUsuario = retorno != null ? retorno.idUsuario : 0,
            idFaixa = retorno != null ? retorno.idFaixa : 0,
            dtInclusao = retorno != null ? retorno.dtInclusao : System.DateTime.MinValue
        };
    }
}