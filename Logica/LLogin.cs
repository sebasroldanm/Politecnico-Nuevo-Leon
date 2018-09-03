using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;
using System.Data;
using System.IO;

namespace Logica
{
    public class LLogin : System.Web.UI.Page
    {
        public UUser logAgregarAdmin(string userId)
        {
            UUser usua = new UUser();
            DUser datos = new DUser();

            //if (!IsPostBack)
            //{
                if (userId != "pailas")
                {
                    //fechanac.ReadOnly = true;
                    //btnigm_calendar.Visible = false;va
                    int year;
                    year = int.Parse(DateTime.Now.ToString("yyyy"));
                    usua.RolId = year - 18;
                    string url = "AgregarAdministrador.aspx";
                    usua.Url = url;
                    //CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + year);
                }
                else
                {
                    string url = "AccesoDenegado.aspx";
                    usua.Url = url;
                }

            //}
            return usua;

            //if (userId != "pailas")
            //{
            //    //fechanac.ReadOnly = true;
            //    //btnigm_calendar.Visible = false;va
            //    int year;
            //    year = int.Parse(DateTime.Now.ToString("yyyy"));
            //    usua.RolId = year - 18;
            //    string url = "";
            //    usua.Url = url;
            //    //CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + year);
            //}
            //else
            //{
            //    string url = "AccesoDenegado.aspx";
            //    usua.Url = url;
            //}

            //return usua;
        }
    }
}
