using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

/// <summary>
/// Descrição resumida de Data
/// </summary>
[DataContract]
public class Data
{
    private int id;
    private String name;

    [DataMember]
    public int Id { get => id; set => id = value; }
    [DataMember]
    public string Name { get => name; set => name = value; }
}