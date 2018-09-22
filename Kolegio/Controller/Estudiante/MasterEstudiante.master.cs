using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_MasterEstudiante : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 60;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_EstuMTitulo.Text = encId.CompIdioma["L_EstuMTitulo"].ToString();
        L_EstuMHorario.Text = encId.CompIdioma["L_EstuMHorario"].ToString();
        L_EstuMCertifica.Text = encId.CompIdioma["L_EstuMCertifica"].ToString();
        L_EstuMVerNotas.Text = encId.CompIdioma["L_EstuMVerNotas"].ToString();
        L_EstuMProfe.Text = encId.CompIdioma["L_EstuMProfe"].ToString();
        L_EstuMConfig.Text = encId.CompIdioma["L_EstuMConfig"].ToString();
        btn_cerrar_sesion.Text = encId.CompIdioma["L_EstuMCerrar"].ToString();
    }
    protected void btn_cerrar_sesion_click(object sender, EventArgs e)
    {
        LUser logica = new LUser();

        logica.cerrarSession(Session.SessionID);

        Response.Redirect("~/View/Inicio/InicioNosotros.aspx");
    }
}
