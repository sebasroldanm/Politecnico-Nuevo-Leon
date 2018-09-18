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
        L_EstuMTitulo.Text = "Bienvenido Estudiante";
        L_EstuMHorario.Text = "Horario";
        L_EstuMCertifica.Text = "Certificado";
        L_EstuMProfe.Text = "Profesor";
        L_EstuMConfig.Text = "Configuración";
        L_EstuMCerrar.Text = "Cerrar Sesion";
    }
}
