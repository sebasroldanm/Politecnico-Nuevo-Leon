using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_SubMasterEstudiante : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 52;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_SubMEstuNuevo.Text = encId.CompIdioma["L_SubMEstuNuevo"].ToString();
        L_SubMEstuEditarEliminar.Text = encId.CompIdioma["L_SubMEstuEditarEliminar"].ToString();
    }
}
