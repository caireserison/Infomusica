using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de IDeezer
/// </summary>
public interface IDeezer
{
    List<Artistas> BuscarArtistaPorNome(String nome);
    List<Albuns> BuscarAlbumPorId(long id);
    List<Faixas> BuscarFaixaAlbumPorId(long id);
    List<Faixas> BuscarFaixaPorId(long id);
    String BuscarEmbedFaixaPorId(String link);
}