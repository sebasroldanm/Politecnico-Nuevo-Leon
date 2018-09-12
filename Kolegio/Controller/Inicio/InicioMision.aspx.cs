using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Inicio_Mision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Misión";
        L_InMisTitulo.Text = "Misión";
        IMG_Mision.ImageUrl = "~/Imagenes/mision.png";

        Session["userId"] = null;
        Session["nombre"] = null;

 

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        L_Mision.Text = usua.Mision;
       
    }
}