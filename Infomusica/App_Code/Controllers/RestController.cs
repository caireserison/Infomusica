using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

        String json = client.DownloadString(api);
        JObject objeto = JObject.Parse(json);
        IList<JToken> results = objeto["data"].Children().ToList();

        return results;
    }

    public static void BuscarArtistaPorNome(String nome)
    {
        IList<Artistas> artistas = new List<Artistas>();
        
        foreach (JToken result in ResponseJsonAPI(String.Format("http://api.deezer.com/search/artist/autocomplete?q={0}", nome)))
        {
            Artistas artista = result.ToObject<Artistas>();
            artistas.Add(artista);
        }
    }

    public static void BuscarAlbumPorId(long id)
    {
        IList<Albuns> albuns = new List<Albuns>();
        
        foreach (JToken result in ResponseJsonAPI(String.Format("https://api.deezer.com/artist/{0}/albums", id)))
        {
            Albuns album = result.ToObject<Albuns>();
            albuns.Add(album);
        }
    }

    public static void BuscarFaixaAlbumPorId(long id)
    {
        IList<Faixas> faixas = new List<Faixas>();

        foreach (JToken result in ResponseJsonAPI(String.Format("https://api.deezer.com/album/{0}/tracks", id)))
        {
            Faixas faixa = result.ToObject<Faixas>();
            faixas.Add(faixa);
        }
    }
}