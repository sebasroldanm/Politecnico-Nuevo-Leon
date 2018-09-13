using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilitarios;
using Logica;

public partial class Loggin : System.Web.UI.Page
{
    Int32 IDIOMA;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["userId"] = null;
        
        UIdioma encId = new UIdioma();

        Int32 FORMULARIO = 40;
        IDIOMA = 1;
        LIdioma idioma = new LIdioma();
        encId = idioma.obtIdioma(FORMULARIO, IDIOMA);

        Page.Title = "Ingresar";
        L_LoginTitulo.Text = encId.Texto[0];
        L_LoginUsuario.Text = encId.Texto[1];
        TB_UserName.Attributes.Add("placeholder", encId.Texto[2]);
        RFV_UserName.ErrorMessage = encId.Texto[3];
        REV_UserName.ErrorMessage = encId.Texto[4];
        L_LoginClave.Text = encId.Texto[5];
        RFV_Clave.ErrorMessage = encId.Texto[6];
        REV_Clave.ErrorMessage = encId.Texto[7];
        BT_Ingresar.Text = encId.Texto[8];
        BT_Recuperar.Text = encId.Texto[9];
        BT_Salir.Text = encId.Texto[10];
        TB_Clave.Attributes.Add("placeholder", encId.Texto[11]);


        //Page.Title = "Ingresar";
        //L_LoginTitulo.Text = info.Rows[0]["texto"].ToString();
        //L_LoginUsuario.Text = info.Rows[1]["texto"].ToString();
        //TB_UserName.Attributes.Add("placeholder", info.Rows[2]["texto"].ToString());
        //RFV_UserName.ErrorMessage = info.Rows[3]["texto"].ToString();
        //REV_UserName.ErrorMessage = info.Rows[4]["texto"].ToString();
        //L_LoginClave.Text = info.Rows[5]["texto"].ToString();
        //TB_Clave.Attributes.Add("placeholder", info.Rows[11]["texto"].ToString());
        //RFV_Clave.ErrorMessage = info.Rows[6]["texto"].ToString();
        //REV_Clave.ErrorMessage = info.Rows[7]["texto"].ToString();
        //BT_Ingresar.Text = info.Rows[8]["texto"].ToString();
        //BT_Recuperar.Text = info.Rows[9]["texto"].ToString();
        //BT_Salir.Text = info.Rows[10]["texto"].ToString();


        //L_Error.Text = "Usuario Se Encuentra Inactivo";
        //L_Error.Text = "Usuario Y/o Clave Incorrecto";

        //TB_UserName.Attributes.Add("placeholder", "Dijite Usuario");
        //Page.Title = "Ingresar";
        ////L_LoginTitulo.Text = "Ingreso a la plataforma";
        //L_LoginTitulo.Text = info.Rows[0]["texto"].ToString();
        ////L_LoginUsuario.Text = "Usuario";
        //L_LoginUsuario.Text = info.Rows[1]["texto"].ToString();
        //TB_UserName.Attributes.Add("placeholder", "Digitar Usuario");
        //RFV_UserName.ErrorMessage = "Campo Vacio";
        //REV_UserName.ErrorMessage = "No se aceptan caracteres especiales";
        //L_LoginClave.Text = "Contraseña";
        //TB_Clave.Attributes.Add("placeholder", "Digitar Contraseña");
        //RFV_Clave.ErrorMessage = "Campo Vacio";
        //REV_Clave.ErrorMessage = "No se aceptan caracteres especiales";
        //BT_Ingresar.Text = "Ingresar";
        //BT_Recuperar.Text = "Recurperar Contraseña";
        //BT_Salir.Text = "Salir";
        ////L_Error.Text = "Usuario Se Encuentra Inactivo";
        ////L_Error.Text = "Usuario Y/o Clave Incorrecto";

    }

    protected void BT_Ingresar_Click(object sender, EventArgs e)
    {
        UUser datos = new UUser();
        LUser logic = new LUser();
        datos = logic.loggear(TB_UserName.Text, TB_Clave.Text);

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
        

        /*
        if (datos.Url == null)
        {
            L_Error.Text = datos.Mensaje;
        }
        else
        {
            MAC datosConexion = new MAC();
            int prueba = int.Parse(Session["userId"].ToString());
            logic.logicaGuardarSesion(int.Parse(Session["userId"].ToString()),
                datosConexion.ip(),
                datosConexion.mac(),
                Session.SessionID);
            Response.Redirect(datos.Url);
        }
        */
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