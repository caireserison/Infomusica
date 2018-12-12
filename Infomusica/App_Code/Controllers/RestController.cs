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
    private static WebClient client = new WebClient();
    private static IList<JToken> results;
    
    public static List<Artistas> BuscarArtistaPorNome(String nome)
    {
        var artistas = new List<Artistas>();
        var uri = ConfigurationManager.AppSettings["DeezerArtista"].ToString();
        foreach (JToken result in ResponseJsonGenericoAPI(String.Format(uri, nome)))
            artistas.Add(result.ToObject<Artistas>());

        return artistas;
    }

    public static List<Albuns> BuscarAlbumPorId(long id)
    {
        var albuns = new List<Albuns>();
        var uri = ConfigurationManager.AppSettings["DeezerAlbum"].ToString();
        foreach (JToken result in ResponseJsonGenericoAPI(String.Format(uri, id)))
            albuns.Add(result.ToObject<Albuns>());

        return albuns;
    }

    public static List<Faixas> BuscarFaixasAlbumPorId(long id)
    {
        var faixas = new List<Faixas>();

        var uri = ConfigurationManager.AppSettings["DeezerFaixaAlbum"].ToString();
        foreach (JToken result in ResponseJsonGenericoAPI(String.Format(uri, id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }

        return faixas;
    }

    public static Faixas BuscarFaixaPorId(long id)
    {
        var faixa = new Faixas();
        var uri = ConfigurationManager.AppSettings["DeezerFaixa"].ToString();
        String json = client.DownloadString(String.Format(uri, id));
        var resultado = JObject.Parse(json);
        faixa = JObject.Parse(resultado.ToString()).ToObject<Faixas>();
        faixa.Embed = BuscarEmbedFaixaPorURL(faixa.Link);
        
        return faixa;
    }

    public static List<Faixas> BuscarFaixaPorTracklist(String tracklist)
    {
        var faixas = new List<Faixas>();
        
        foreach (JToken result in ResponseJsonGenericoAPI(tracklist))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixa.Embed = BuscarEmbedFaixaPorURL(faixa.Link);
            faixas.Add(faixa);
        }

        return faixas;
    }

    public static String BuscarEmbedFaixaPorURL(String link)
    {
        WebClient client = new WebClient();
        IList<JToken> results;

        var uri = ConfigurationManager.AppSettings["DeezerEmbedFaixa"].ToString();

        String json = client.DownloadString(String.Format(uri, link));
        JObject objeto = JObject.Parse(json);
        results = objeto.Children().ToList();
        String embed = ((JValue)((JProperty)results[7]).Value).Value.ToString();
        embed = ConfiguracaoTamanhoEmbed(embed);

        return embed;
    }

    public static Generico BuscarGenerico(String nome)
    {
        Generico generico = new Generico();
        var uri = ConfigurationManager.AppSettings["DeezerBuscaGenerica"].ToString();
        foreach (JToken result in ResponseJsonTracksAPI(String.Format(uri, nome)))
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

    private static string ConfiguracaoTamanhoEmbed(string embed)
    {
        embed = embed.Replace("width=700", "width=600");
        embed = embed.Replace("width='700'", "width='600'");
        embed = embed.Replace("height=240", "height=90");
        embed = embed.Replace("height='240'", "height='90'");
        return embed;
    }

    private static IList<JToken> ResponseJsonGenericoAPI(String api)
    {
        String json = client.DownloadString(api);
        JObject objeto = JObject.Parse(json);
        if (objeto["data"] != null)
            results = objeto["data"].Children().ToList();
        else
            results = objeto.Children().ToList();

        return results;
    }

    private static IList<JToken> ResponseJsonTracksAPI(String api)
    {
        String json = client.DownloadString(api);
        JObject objeto = JObject.Parse(json);

        results = objeto["tracks"]["data"].Children().ToList();

        return results;
    }
}

enum TypeDeezer
{
    artist,
    album,
    track
}