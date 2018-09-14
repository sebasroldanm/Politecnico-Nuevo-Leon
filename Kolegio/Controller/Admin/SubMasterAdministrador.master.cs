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
        L_SubMAdminNuevo.Text = "NUEVO";
        L_SubMAdminEditarEliminar.Text = "LISTAR - EDITAR ";
    }
}
