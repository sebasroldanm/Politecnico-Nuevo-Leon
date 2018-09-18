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
        //Page.Title ="";
        L_ProfeMTitulo.Text = "Bienvenido Profesor";
        L_ProfeMSubirNota.Text = "Notas";
        L_ProfeMHoraio.Text = "Horario";
        L_ProfeMObservacion.Text = "Listado - Observacion";
        L_ProfeMMensaje.Text = "Mensaje";
        L_ProfeMConfig.Text = "Configuración";
        L_ProfeMCerrar.Text = "Cerrar Sesión";
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
