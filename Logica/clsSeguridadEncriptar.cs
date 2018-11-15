using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace WebServiceTokens.Logica
{
   public class clsSeguridadEncriptar : System.Web.Services.Protocols.SoapHeader
    {


        public string stToken { get; set; }
        public string AutenticacionToken { get; set; }

        public bool blCredencialesValidas(string stToken)
        {
            try
            {
                if (stToken == "encriptar")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool blCredencialesValidas(clsSeguridadEncriptar SoapHeader)
        {
            try
            {
                if (SoapHeader == null)
                {
                    return false;
                }
                if (!string.IsNullOrEmpty(SoapHeader.AutenticacionToken))
                {
                    return (HttpRuntime.Cache[SoapHeader.AutenticacionToken] != null);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}