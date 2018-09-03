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

            if (userId != null)
            {
                //fechanac.ReadOnly = true;
                //btnigm_calendar.Visible = false;va
                int year;
                year = int.Parse(DateTime.Now.ToString("yyyy"));
                usua.RolId = year - 18;
                usua.Url = "AgregarAdministrador.aspx";
                //CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + year);
            }
            else
                usua.Url="AccesoDenegado.aspx";

            return usua;
        }
    }
}
