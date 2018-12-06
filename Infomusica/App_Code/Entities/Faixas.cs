using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Faixas
/// </summary>
public class Faixas
{
    private String title;
    private String link;
    private String preview;
    private Artistas artist;
    
    public string Title { get => title; set => title = value; }
    public string Link { get => link; set => link = value; }
    public string Preview { get => preview; set => preview = value; }
    public Artistas Artist { get => artist; set => artist = value; }
}