using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de WSEstudiantesOnce
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class WSEstudiantesOnce : System.Web.Services.WebService
{

    public WSEstudiantesOnce()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }
    public WebServiceTokens.Logica.clsSeguridadOnce SoapHeader;

    [WebMethod]
    [System.Web.Services.Protocols.SoapHeader("SoapHeader")]
    public string AutenticacionUsuario()
    {
        try
        {
            if (SoapHeader == null)
            {
                return "-1";
            }
            if (!SoapHeader.blCredencialesValidas(SoapHeader.stToken))
            {
                return "-1";
            }
            string stToken = Guid.NewGuid().ToString();
            HttpRuntime.Cache.Add(stToken,
                                    SoapHeader.stToken,
                                    null,
                                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                                    TimeSpan.FromMinutes(30),
                                    System.Web.Caching.CacheItemPriority.NotRemovable,
                                    null
                                    );
            return stToken;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    //[WebMethod]
    //public string HelloWorld()
    //{
    //    return "Hola a todos";
    //}

}
