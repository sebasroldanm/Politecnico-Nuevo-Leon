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
        L_SubMAcudienteNuevo.Text = "NUEVO";
        L_SubMAcudienteEditarEliminar.Text = "LISTAR - EDITAR ";
    }
}
