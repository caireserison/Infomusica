using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de IMusica
/// </summary>
public interface IMusica
{
    int idUsuario { get; set; }
    int idFaixa { get; set; }
    System.DateTime dtInclusao { get; set; }
    int idMusica { get; set; }
}