using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Musica
/// </summary>
public class Musica : IMusica
{
    public int idUsuario { get; set; }
    public int idFaixa { get; set; }
    public System.DateTime dtInclusao { get; set; }
    public int idMusica { get; set; }
}