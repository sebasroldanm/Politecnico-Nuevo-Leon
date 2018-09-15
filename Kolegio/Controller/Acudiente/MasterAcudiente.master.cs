using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Acudiente_MasterAcudiente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_ACuSubTitulo.Text = "Bienvenido Acudiente";
        L_AcuSubBoletin.Text = "Boletin";
        L_AcuSubObservador.Text = "Observador";
        L_AcuSubMensaje.Text = "Mensaje Profesor";
        L_AcuSubConfig.Text = "Configuración";
        L_AcuSubCerrar.Text = "Cerrar Sesión";
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
