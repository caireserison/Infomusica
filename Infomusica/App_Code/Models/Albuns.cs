using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Albuns
/// </summary>
public class Albuns : Comum
{
    private String title;
    private String cover_medium;
    private int genre_id;

    public string Title { get => title; set => title = value; }
    public string Cover_medium { get => cover_medium; set => cover_medium = value; }
    public int Genre_id { get => genre_id; set => genre_id = value; }
}