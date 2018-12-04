using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de DeezerController
/// </summary>
public class DeezerController
{
    public List<Artistas> BuscarArtistaPorNome(String nome)
    {
        List<Artistas> artistas = new List<Artistas>();

        RestController.BuscarArtistaPorNome("Guns");

        return artistas;
    }
}