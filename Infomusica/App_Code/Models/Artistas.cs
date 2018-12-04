using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descrição resumida de Artistas
/// </summary>
public class Artistas : Comum
{
    private String name;
    private String picture_medium;

    public string Name { get => name; set => name = value; }
    public string Picture_medium { get => picture_medium; set => picture_medium = value; }
}