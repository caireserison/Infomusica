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
    public static void BuscarPorNome(String nome)
    {
        WebClient client = new WebClient();

        var json = client.DownloadString(String.Format("http://api.deezer.com/search/artist/autocomplete?q={0}", nome));

        JObject objeto = JObject.Parse(json);

        IList<JToken> results = objeto["data"].Children().ToList();

        IList<Artistas> artistas = new List<Artistas>();
        foreach (JToken result in results)
        {
            Artistas artista = result.ToObject<Artistas>();
            artistas.Add(artista);
        }

        //var x = JsonConvert.DeserializeObject<Data>(json);
    }
}