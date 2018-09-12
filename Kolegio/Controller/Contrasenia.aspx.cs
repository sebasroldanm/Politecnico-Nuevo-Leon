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

        usua = logica.cambiarContra(Request.QueryString.Count, Request.QueryString[0], usua.SUserId);


        L_ContraseniaTitulo.Text = "Recuperación de la Cuenta";
        L_ContraseniaNueva.Text = "Digite Nueva Clave :";
        TB_NuevaClave.Attributes.Add("placeholder", "Digite Nueva Clave");
        RFV_Clave.ErrorMessage = "Campo Vacio";
        REV_Clave.ErrorMessage = "No se aceptan caracteres especiales";
        L_ContraseniaNuevamente.Text = "Digite Nuevamente la Clave :";
        TB_NuevamenteClave.Attributes.Add("placeholder", "Repetir Clave");
        RFV_NuevamenteClave.ErrorMessage = "Campo Vacio";
        REV_Clave.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";

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
        usua.UserId = int.Parse(Session["user_id"].ToString());

        usua = logic.ContraseñaBEnviar(TB_NuevamenteClave.Text, usua.UserId.ToString());

        //this.Page.Response.Write("<script language='JavaScript'>window.alert('El Token esta vencido. Genere uno nuevo');</script>");
        Response.Redirect("~/View/Loggin.aspx");
    }
}
