using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_SubMasterAcudiente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 49;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_SubMAcudienteNuevo.Text = encId.CompIdioma["L_SubMAcudienteNuevo"].ToString();
        L_SubMAcudienteEditarEliminar.Text = encId.CompIdioma["L_SubMAcudienteEditarEliminar"].ToString();
    }
}
