using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Inicio_MantenimientoPagina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Estamos Trabajando";
        IMG_Error.ImageUrl = "~/Imagenes/politecnicoleonmantenimientof.png";
    }
}