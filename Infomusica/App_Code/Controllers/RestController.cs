using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Descrição resumida de RestController
/// </summary>
public static class RestController
{
    private static IList<JToken> ResponseJsonAPI(String api)
    {
        WebClient client = new WebClient();
        IList<JToken> results;

        String json = client.DownloadString(api);
        JObject objeto = JObject.Parse(json);
        if (objeto["data"] != null)
            results = objeto["data"].Children().ToList();
        else
            results = objeto.Children().ToList();

        return results;
    }

    private static IList<JToken> ResponseJsonGenericoAPI(String api)
    {
        WebClient client = new WebClient();
        IList<JToken> results;

        String json = client.DownloadString(api);
        JObject objeto = JObject.Parse(json);

        results = objeto["tracks"]["data"].Children().ToList();

        return results;
    }

    public static Generico BuscarGenerico(String nome)
    {
        Generico generico = new Generico();
        var uri = ConfigurationManager.AppSettings["DeezerBuscaGenerica"].ToString();
        foreach (JToken result in ResponseJsonGenericoAPI(String.Format(uri, nome)))
        {
            String tipo = result["type"].ToString();

            switch ((TypeDeezer)Enum.Parse(typeof(TypeDeezer), tipo))
            {
                case TypeDeezer.artist:
                    generico.Artistas.Add(result.ToObject<Artistas>());
                    break;
                case TypeDeezer.album:
                    generico.Albuns.Add(result.ToObject<Albuns>());
                    break;
                case TypeDeezer.track:
                    generico.Faixas.Add(result.ToObject<Faixas>());
                    break;
                default:
                    break;
            }
        }

        return generico;
    }

    public static List<Artistas> BuscarArtistaPorNome(String nome)
    {
        var artistas = new List<Artistas>();

        var uri = ConfigurationManager.AppSettings["DeezerArtista"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, nome)))
        {
            Artistas artista = result.ToObject<Artistas>();
            artistas.Add(artista);
        }

        return artistas;
    }

    public static List<Albuns> BuscarAlbumPorId(long id)
    {
        var albuns = new List<Albuns>();

        var uri = ConfigurationManager.AppSettings["DeezerAlbum"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Albuns album = result.ToObject<Albuns>();
            albuns.Add(album);
        }

        return albuns;
    }

    public static List<Faixas> BuscarFaixaAlbumPorId(long id)
    {
        var faixas = new List<Faixas>();

        var uri = ConfigurationManager.AppSettings["DeezerFaixaAlbum"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }

        return faixas;
    }

    public static List<Faixas> BuscarFaixaPorId(long id)
    {
        var faixas = new List<Faixas>();

        var uri = ConfigurationManager.AppSettings["DeezerFaixa"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }

        return faixas;
    }

    public static List<Faixas> BuscarFaixaPorTracklist(String tracklist)
    {
        var faixas = new List<Faixas>();
        
        foreach (JToken result in ResponseJsonAPI(tracklist))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }

        return faixas;
    }

    public static String BuscarEmbedFaixaPorId(String link)
    {
        WebClient client = new WebClient();
        IList<JToken> results;

        var uri = ConfigurationManager.AppSettings["DeezerEmbedFaixa"].ToString();
        
        String json = client.DownloadString(String.Format(uri, link));
        JObject objeto = JObject.Parse(json);
        results = objeto.Children().ToList();
        String embed = results[0]["html"].ToString();

        return embed;
    }
}

enum TypeDeezer
{
    artist,
    album,
    track
}