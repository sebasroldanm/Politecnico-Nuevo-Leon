using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Estudiante_EstudianteVernotas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        try
        {
            LUser logic = new LUser();
            UUser enc = new UUser();
            LLogin log = new LLogin();

            enc = logic.PL_EstudianteVerNotas();
            Session["anio"] = enc.Año;

            enc = log.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(enc.Url);

        }
        catch
        {

        }

    }

    protected void GV_boletin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}