using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MusicaController
/// </summary>
public class MusicaController
{
    MusicaModel modelMusica = new MusicaModel();
    LoginModel modelUsuario = new LoginModel();
    DeezerController deezer = new DeezerController();

    public IMusica ObterMusicaPorUsuario(IMusica musica)
    {
        return modelMusica.ObterMusicaPorUsuario(musica);
    }

    public List<Indicacao> ObterMusicaPorData(IMusica musica)
    {
        List<Indicacao> indicacoes = new List<Indicacao>();
        List<Musica> musicas = modelMusica.ObterMusicaPorData(musica);

        foreach (var item in musicas)
        {
            var faixa = deezer.BuscarFaixaPorId(item.idFaixa);

            indicacoes.Add(
                new Indicacao() {
                    NomeUsuario = modelUsuario.ObterUsuario(new Login() { id = item.idUsuario }).nome,
                    NomeMusica = faixa[0].Title,
                    NomeArtista = faixa[0].Artist.Name,
                    URLFotoArtista = faixa[0].Artist.Picture_medium,
                    NomeAlbum = "",
                    Embed = faixa[0].Embed
                }
            );
        }
        
        return indicacoes;
    }

    public IMusica ObterMusicaPorUsuarioData(IMusica musica)
    {
        return modelMusica.ObterMusicaPorUsuarioData(musica);
    }

    public void IncluirMusica(IMusica musica)
    {
        modelMusica.IncluirMusica(musica);
    }
}