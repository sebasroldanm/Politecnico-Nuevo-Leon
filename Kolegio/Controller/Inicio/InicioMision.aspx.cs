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
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 31;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_InMisTitulo.Text = encId.CompIdioma["L_InMisTitulo"].ToString();
        IMG_Mision.ImageUrl = encId.CompIdioma["IMG_Mision"].ToString();

        Session["userId"] = null;
        Session["nombre"] = null;

 

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        L_Mision.Text = usua.Mision;
       
    }
}