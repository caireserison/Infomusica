using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Albuns
/// </summary>
public class Albuns : Comum
{
    private List<Faixas> faixas;

    public List<Faixas> Faixas { get => faixas; set => faixas = value; }
}