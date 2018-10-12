using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_SubMasterAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 50;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_SubMAdminNuevo.Text = encId.CompIdioma["L_SubMAdminNuevo"].ToString();
        L_SubMAdminEditarEliminar.Text = encId.CompIdioma["L_SubMAdminEditarEliminar"].ToString();
    }
}
