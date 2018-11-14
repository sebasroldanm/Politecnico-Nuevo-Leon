using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebServiceTokens.Logica
{
    public class clsSeguridadOnce : System.Web.Services.Protocols.SoapHeader
    {
        public string stToken { get; set; }
        public string AutenticacionToken { get; set; }

        public bool blCredencialesValidas(string stToken)
        {
            try
            {
                if (stToken == "once")
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

        public bool blCredencialesValidas(clsSeguridadOnce SoapHeader)
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