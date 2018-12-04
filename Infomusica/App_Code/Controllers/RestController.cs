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

    public static void BuscarArtistaPorNome(String nome)
    {
        IList<Artistas> artistas = new List<Artistas>();

        var uri = ConfigurationManager.AppSettings["DeezerArtista"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, nome)))
        {
            Artistas artista = result.ToObject<Artistas>();
            artistas.Add(artista);
        }
    }

    public static void BuscarAlbumPorId(long id)
    {
        IList<Albuns> albuns = new List<Albuns>();

        var uri = ConfigurationManager.AppSettings["DeezerAlbum"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Albuns album = result.ToObject<Albuns>();
            albuns.Add(album);
        }
    }

    public static void BuscarFaixaAlbumPorId(long id)
    {
        IList<Faixas> faixas = new List<Faixas>();

        var uri = ConfigurationManager.AppSettings["DeezerFaixaAlbum"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }
    }

    public static void BuscarFaixaPorId(long id)
    {
        IList<Faixas> faixas = new List<Faixas>();

        var uri = ConfigurationManager.AppSettings["DeezerFaixa"].ToString();
        foreach (JToken result in ResponseJsonAPI(String.Format(uri, id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }
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