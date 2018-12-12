using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DeezerController
/// </summary>
public class DeezerController : IDeezer
{
    public Generico BuscarGenerico(string nome)
    {
        return RestController.BuscarGenerico(nome);
    }

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

    public Faixas BuscarFaixaPorId(long id)
    {
        return RestController.BuscarFaixaPorId(id);
    }

    public List<Faixas> BuscarFaixaPorTracklist(String tracklist)
    {
        return RestController.BuscarFaixaPorTracklist(tracklist);
    }

    public string BuscarEmbedFaixaPorId(string link)
    {
        return RestController.BuscarEmbedFaixaPorURL(link);
    }
}