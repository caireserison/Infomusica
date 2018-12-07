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

    public IMusica ObterMusica(IMusica musica)
    {
        return model.ObterMusica(musica);
    }

    public void IncluirMusica(IMusica musica)
    {
        model.IncluirMusica(musica);
    }
}