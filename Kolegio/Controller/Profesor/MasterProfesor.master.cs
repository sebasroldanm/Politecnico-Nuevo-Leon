using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Profesor_MasterProfesor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 62;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));
        //Page.Title ="";
        L_ProfeMTitulo.Text = encId.CompIdioma["L_ProfeMTitulo"].ToString();
        L_ProfeMSubirNota.Text = encId.CompIdioma["L_ProfeMSubirNota"].ToString();
        L_ProfeMHoraio.Text = encId.CompIdioma["L_ProfeMHoraio"].ToString();
        L_ProfeMObservacion.Text = encId.CompIdioma["L_ProfeMObservacion"].ToString();
        L_ProfeMMensaje.Text = encId.CompIdioma["L_ProfeMMensaje"].ToString();
        L_ProfeMConfig.Text = encId.CompIdioma["L_ProfeMConfig"].ToString();
        btn_cerrar_sesion.Text = encId.CompIdioma["L_ProfeMCerrar"].ToString();
    }
    protected void btn_cerrar_sesion_click(object sender, EventArgs e)
    {
        LUser logica = new LUser();

        logica.cerrarSession(Session.SessionID);
        logica.limpiaSesionActiva(Session["userName"].ToString());

        Response.Redirect("~/View/Inicio/InicioNosotros.aspx");
    }


}
