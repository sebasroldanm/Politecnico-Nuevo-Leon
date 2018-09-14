using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;


public partial class View_Administrador_MasterAdministrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_MAdminTitulo.Text = "Bienvenido Administrador";
        HL_MAdminAgreAdmin.Text = "Administrador";
        HL_MAdminAgreEstu.Text = "Estudiante";
        HL_MAdminAgreProfe.Text = "Docente";
        HL_MAdminAgreAcu.Text = "Acudiente";
        HL_MAdminAgreMateriaCurso.Text = "Curso";
        HL_MAdminMensaje.Text = "Mensaje";
        HL_MAdminPagInicio.Text = "Configuración Leon";
        HL_MAdminConfig.Text = "Configuración";
        HL_MAdminInicio.Text = "Cerrar Sesión";
    }
}
