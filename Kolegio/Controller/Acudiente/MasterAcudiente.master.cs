using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;

public partial class View_Acudiente_MasterAcudiente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            Console.WriteLine("");
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
    }
    protected void B_Cerrar_Click(object sender, EventArgs e)
    {
        Session["userId"] = null;
        Session["nombre"] = null;

        DUser user = new DUser();
        UUser datos = new UUser();
        datos.Session = Session.SessionID;
        user.cerrarSession(datos);

        Response.Redirect("../Inicio/InicioNosotros.aspx");
    }
}
