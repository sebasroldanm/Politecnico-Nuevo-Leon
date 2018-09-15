using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Acudiente_AccesoRestringido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Acceso denegado";
        L_AdminAccesoTitulo.Text = "Acceso Denegado";
        L_AdminAccesoCuerpo.Text = "Usted esta intentando visitar la página desde una URL incorrrecta, por favor Iniciar Sesión.";
        L_AdminAccesoDescrip.Text = "En caso de ser un error, contactese con Nosotros.";
        L_AdminAccesoFirma.Text = "Atentamente: Administración Colegio";

        Response.Cache.SetNoStore();
    }
}