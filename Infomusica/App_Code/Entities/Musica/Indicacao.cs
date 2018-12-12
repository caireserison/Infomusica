using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Indicacao
/// </summary>
public class Indicacao
{
    public long IdMusica { get; set; }
    public long IdUsuario { get; set; }
    public String NomeUsuario { get; set; }
    public String NomeMusica { get; set; }
    public String NomeArtista { get; set; }
    public String URLFotoArtista { get; set; }
    public String NomeAlbum { get; set; }
    public String Embed { get; set; }
}