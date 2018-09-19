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

        usua = logica.cambiarContra(Request.QueryString.Count, Request.QueryString[0], usua.SUserId, int.Parse(Session["idioma"].ToString()));
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 42;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_ContraseniaTitulo.Text = encId.CompIdioma["L_ContraseniaTitulo"].ToString();
        L_ContraseniaNueva.Text = encId.CompIdioma["L_ContraseniaNueva"].ToString();
        TB_NuevaClave.Attributes.Add("placeholder", encId.CompIdioma["TB_NuevaClave"].ToString());
        RFV_Clave.ErrorMessage = encId.CompIdioma["RFV_Clave"].ToString();
        REV_Clave.ErrorMessage = encId.CompIdioma["REV_Clave"].ToString();
        L_ContraseniaNuevamente.Text = encId.CompIdioma["L_ContraseniaNuevamente"].ToString();
        TB_NuevamenteClave.Attributes.Add("placeholder", encId.CompIdioma["TB_NuevamenteClave"].ToString());
        RFV_NuevamenteClave.ErrorMessage = encId.CompIdioma["RFV_NuevamenteClave"].ToString();
        REV_Clave.ErrorMessage = encId.CompIdioma["REV_Clave"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();

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
