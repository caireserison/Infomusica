using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Login
/// </summary>
public class LoginEntity : ILogin
{
    public int id { get; set; }
    public string nome { get; set; }
    public string login { get; set; }
    public string senha { get; set; }
}