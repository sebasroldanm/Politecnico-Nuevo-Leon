﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebServiceTokens.Logica
{
    public class clsSeguridad : System.Web.Services.Protocols.SoapHeader
    {
        public string stToken { get; set; }
        public string AutenticacionToken { get; set; }

        public bool blCredencialesValidas(string stToken)
        {
            try
            {
                if (stToken == "abc")
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

        public bool blCredencialesValidas(clsSeguridad SoapHeader)
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

