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
        L_SubMEstuNuevo.Text = "NUEVO";
        L_SubMEstuEditarEliminar.Text = "LISTAR - EDITAR ";
    }
}
