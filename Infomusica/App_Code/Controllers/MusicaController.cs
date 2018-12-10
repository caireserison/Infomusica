using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de MusicaController
/// </summary>
public class MusicaController
{
    MusicaModel model = new MusicaModel();

    public IMusica ObterMusicaPorUsuario(IMusica musica)
    {
        return model.ObterMusicaPorUsuario(musica);
    }

    public IMusica ObterMusicaPorData(IMusica musica)
    {
        return model.ObterMusicaPorData(musica);
    }

    public IMusica ObterMusicaPorUsuarioData(IMusica musica)
    {
        return model.ObterMusicaPorUsuarioData(musica);
    }

    public void IncluirMusica(IMusica musica)
    {
        model.IncluirMusica(musica);
    }
}