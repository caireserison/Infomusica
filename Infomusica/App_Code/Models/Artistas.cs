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
    private List<Albuns> albuns;
    
    public List<Albuns> Albuns { get => albuns; set => albuns = value; }
}