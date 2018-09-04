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
        if (Session["userId"] != null)
        {
            LReg logic = new LReg();
            UUser enc = new UUser();

            enc = logic.obtenerAñodeCurso();
            Session["anio"] = enc.Año;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");

    }

    protected void GV_boletin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}