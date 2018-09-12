using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Inicio_MasterInicio : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Politecnico Leon";
        HL_InicioNosotros.Text = "Inicio";
        HL_InicioMision.Text = "Misión";
        HL_InicioVision.Text = "Visión";
        HL_InicioContactenos.Text = "Contáctenos";
        HL_InicioLoggin.Text = "Iniciar Sesión";
    }
}
