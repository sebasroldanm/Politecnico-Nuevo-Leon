using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using Utilitarios;
using Logica;

public partial class View_Inicio_InicioNosotros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 32;

        Int32 IDIOMA = int.Parse(DDL_Idioma.SelectedValue);
        Session["idioma"] = IDIOMA;
        encId = idioma.obtIdioma(FORMULARIO, IDIOMA);

        Page.Title = encId.CompIdioma["Title"].ToString();
        IMG_Slider1.ImageUrl = encId.CompIdioma["IMG_Slider1"].ToString();
        IMG_Slider2.ImageUrl = encId.CompIdioma["IMG_Slider2"].ToString();
        IMG_Slider3.ImageUrl = encId.CompIdioma["IMG_Slider3"].ToString();
        L_InNosTitulo.Text = encId.CompIdioma["L_InNosTitulo"].ToString();
        L_InNosDescarga.Text = encId.CompIdioma["L_InNosDescarga"].ToString();
        L_InNosSubtitulo.Text = encId.CompIdioma["L_InNosSubtitulo"].ToString();
        L_InNosBievenido.Text = encId.CompIdioma["L_InNosBievenido"].ToString();
        L_InNosInstalaciones.Text = encId.CompIdioma["L_InNosInstalaciones"].ToString();


        Session["userId"] = null;
        Session["nombre"] = null;

        LMUser logica = new LMUser();
        UUser usua = new UUser();



        usua = logica.TraerDatosPagina();

        L_Inicio.Text = usua.Inicio;

        //logica.cerrarSession(Session.SessionID);



        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAño(int.Parse(Session["idioma"].ToString()));
        this.Page.Response.Write(enc.Notificacion);

    }

    protected void DDL_Idioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        encId = idioma.obtTerminacionIdioma(int.Parse(Session["idioma"].ToString()));

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(encId.IdiomaTermina);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(encId.IdiomaTermina);
    }
}