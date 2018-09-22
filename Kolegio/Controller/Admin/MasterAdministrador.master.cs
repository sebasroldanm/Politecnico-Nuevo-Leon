using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;


public partial class View_Administrador_MasterAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 47;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_MAdminTitulo.Text = encId.CompIdioma["L_MAdminTitulo"].ToString();
        HL_MAdminAgreAdmin.Text = encId.CompIdioma["HL_MAdminAgreAdmin"].ToString();
        HL_MAdminAgreEstu.Text = encId.CompIdioma["HL_MAdminAgreEstu"].ToString();
        HL_MAdminAgreProfe.Text = encId.CompIdioma["HL_MAdminAgreProfe"].ToString();
        HL_MAdminAgreAcu.Text = encId.CompIdioma["HL_MAdminAgreAcu"].ToString();
        HL_MAdminAgreMateriaCurso.Text = encId.CompIdioma["HL_MAdminAgreMateriaCurso"].ToString();
        HL_MAdminMensaje.Text = encId.CompIdioma["HL_MAdminMensaje"].ToString();
        HL_MAdminPagInicio.Text = encId.CompIdioma["HL_MAdminPagInicio"].ToString();
        HL_MAdminConfig.Text = encId.CompIdioma["HL_MAdminConfig"].ToString();
        btn_cerrar_sesion.Text = encId.CompIdioma["HL_MAdminInicio"].ToString();
    }
    protected void btn_cerrar_sesion_click(object sender, EventArgs e)
    {
        LUser logica = new LUser();

        logica.cerrarSession(Session.SessionID);

        Response.Redirect("~/View/Inicio/InicioNosotros.aspx");
    }
}
