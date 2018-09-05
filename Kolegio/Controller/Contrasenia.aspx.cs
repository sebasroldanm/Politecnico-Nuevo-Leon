using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Contrasenia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        UUser usua = new UUser();
        LUser logica = new LUser();

        usua = logica.cambiarContra(Request.QueryString.Count, Request.QueryString[0]);

        try
        {
            this.Page.Response.Write(usua.Notificacion);
            Response.Redirect(usua.Url);
        }
        catch
        {

        }
        
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        LUser logic = new LUser();
        UContrasenia usua = new UContrasenia();
        usua = logic.ContraseñaBEnviar(TB_NuevamenteClave.Text, Session["user_id"].ToString());

        this.Page.Response.Write("<script language='JavaScript'>window.alert('El Token esta vencido. Genere uno nuevo');</script>");
        Response.Redirect("~/View/Loggin.aspx");
    }
}
