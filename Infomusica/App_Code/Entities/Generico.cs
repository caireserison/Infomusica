using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Generico
/// </summary>
public class Generico
{
    private List<Artistas> artistas;
    private List<Albuns> albuns;
    private List<Faixas> faixas;

    public List<Artistas> Artistas { get => artistas; set => artistas = value; }
    public List<Albuns> Albuns { get => albuns; set => albuns = value; }
    public List<Faixas> Faixas { get => faixas; set => faixas = value; }
}