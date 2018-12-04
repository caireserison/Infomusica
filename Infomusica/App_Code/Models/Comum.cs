using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descrição resumida de Comum
/// </summary>
public class Comum
{
    private long id;
    private String name;

    public long Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
}