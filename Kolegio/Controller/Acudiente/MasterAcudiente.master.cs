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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 59;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_ACuSubTitulo.Text = encId.CompIdioma["L_ACuSubTitulo"].ToString();
        L_AcuSubBoletin.Text = encId.CompIdioma["L_AcuSubBoletin"].ToString();
        L_AcuSubObservador.Text = encId.CompIdioma["L_AcuSubObservador"].ToString();
        L_AcuSubMensaje.Text = encId.CompIdioma["L_AcuSubMensaje"].ToString();
        L_AcuSubConfig.Text = encId.CompIdioma["L_AcuSubConfig"].ToString();
        L_AcuSubCerrar.Text = encId.CompIdioma["L_AcuSubCerrar"].ToString();
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
