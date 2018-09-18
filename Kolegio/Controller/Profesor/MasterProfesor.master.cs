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
        L_ProfeMCerrar.Text = encId.CompIdioma["L_ProfeMCerrar"].ToString();
    }
    protected void B_Cerrar_Click(object sender, EventArgs e)
    {
        UUser datos = new UUser();
        LLogin logic = new LLogin();

        datos = logic.cerrarSessionAcudiente(Session.SessionID);
        Session["userId"] = datos.SUserId;
        Session["nombre"] = datos.Nombre;

        Response.Redirect(datos.Url);
    }


}
