using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ILogin
/// </summary>
public interface ILogin
{
    int id { get; set; }
    string nome { get; set; }
    string login { get; set; }
    string senha { get; set; }
}