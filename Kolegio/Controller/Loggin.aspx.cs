using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilitarios;
using Logica;
using System.Globalization;
using System.Threading;

public partial class Loggin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["userId"] = null;  
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();    
        Int32 FORMULARIO = 40;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_LoginTitulo.Text = encId.CompIdioma["L_LoginTitulo"].ToString();
        L_LoginUsuario.Text = encId.CompIdioma["L_LoginUsuario"].ToString();
        TB_UserName.Attributes.Add("placeholder", encId.CompIdioma["TB_UserName"].ToString());
        RFV_UserName.ErrorMessage = encId.CompIdioma["RFV_UserName"].ToString();
        REV_UserName.ErrorMessage = encId.CompIdioma["REV_UserName"].ToString();
        L_LoginClave.Text = encId.CompIdioma["L_LoginClave"].ToString();
        RFV_Clave.ErrorMessage = encId.CompIdioma["RFV_Clave"].ToString();
        REV_Clave.ErrorMessage = encId.CompIdioma["REV_Clave"].ToString();
        BT_Ingresar.Text = encId.CompIdioma["BT_Ingresar"].ToString();
        BT_Recuperar.Text = encId.CompIdioma["BT_Recuperar"].ToString();
        BT_Salir.Text = encId.CompIdioma["BT_Salir"].ToString();
        TB_Clave.Attributes.Add("placeholder", encId.CompIdioma["TB_Clave"].ToString());

        //L_Error_inactivo.Text = "Usuario Se Encuentra Inactivo";
        //L_Error_clave_incorrecto.Text = "Usuario Y/o Clave Incorrecto";

    }

    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {
        UUser datos = new UUser();
        LUser logic = new LUser();



        datos = logic.loggear(TB_UserName.Text, TB_Clave.Text, int.Parse(Session["idioma"].ToString()), NoBotLogin.IsValid());

        Session["userId"] = datos.SUserId;
        Session["userName"] = datos.SUserName;
        Session["nombre"] = datos.SNombre;
        Session["apellido"] = datos.SApellido;
        Session["clave"] = datos.SClave;
        Session["correo"] = datos.SCorreo;
        Session["documento"] = datos.SDocumento;
        Session["foto"] = datos.SFoto;

        try
        {
            Response.Redirect(datos.Url);
        }
        catch
        {
            L_Error.Text = datos.Mensaje;
        }
        
    }

    protected void BT_Recuperar_Click(object sender, EventArgs e)
    {
        Session["userId"] = null;
        Response.Redirect("/View/Recuperar.aspx");
        
    }

    protected void BT_Salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/Inicio/InicioNosotros.aspx");

    }

}