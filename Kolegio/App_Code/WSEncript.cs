﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de WSEncript
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSEncript : System.Web.Services.WebService
{

    public WSEncript()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string encriptar(string cadena)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(cadena);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    [WebMethod]
    public string desencriptar(string encriptado)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(encriptado);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

}
