using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DeezerController
/// </summary>
public class DeezerController : IDeezer
{
    public List<Artistas> BuscarArtistaPorNome(String nome)
    {
        return RestController.BuscarArtistaPorNome(nome);
    }

    public List<Albuns> BuscarAlbumPorId(long id)
    {
        return RestController.BuscarAlbumPorId(id);
    }

    public List<Faixas> BuscarFaixaAlbumPorId(long id)
    {
        return RestController.BuscarFaixaAlbumPorId(id);
    }

    public List<Faixas> BuscarFaixaPorId(long id)
    {
        return RestController.BuscarFaixaPorId(id);
    }

    public string BuscarEmbedFaixaPorId(string link)
    {
        return RestController.BuscarEmbedFaixaPorId(link);
    }
}