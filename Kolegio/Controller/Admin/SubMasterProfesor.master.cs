using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_SubMasterProfesor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 53;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_SubMProfeNuevo.Text = encId.CompIdioma["L_SubMProfeNuevo"].ToString();
        L_SubMProfeEditarEliminar.Text = encId.CompIdioma["L_SubMProfeEditarEliminar"].ToString();
    }
}
