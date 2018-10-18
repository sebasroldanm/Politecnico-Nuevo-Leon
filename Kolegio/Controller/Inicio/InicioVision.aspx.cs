using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Inicio_Vision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 33;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_InMisTitulo.Text = encId.CompIdioma["L_InMisTitulo"].ToString();
        IMG_Mision.ImageUrl = encId.CompIdioma["IMG_Mision"].ToString();


        Session["userId"] = null;
        Session["nombre"] = null;

       

        LMUser logica = new LMUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        L_Vision.Text = usua.Vision;

        
    }
}