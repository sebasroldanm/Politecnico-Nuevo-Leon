﻿using System;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["userId"] = null;


        Int32 FORMULARIO = 1;
        LIdioma idioma = new LIdioma();
        
        TB_UserName.Attributes.Add("placeholder", "Dijite Usuario");
        Page.Title = "Ingresar";
        L_LoginTitulo.Text = "Ingreso a la plataforma";
        L_LoginUsuario.Text = "Usuario";
        TB_UserName.Attributes.Add("placeholder", "Digitar Usuario");
        RFV_UserName.ErrorMessage = "Campo Vacio";
        REV_UserName.ErrorMessage = "No se aceptan caracteres especiales";
        L_LoginClave.Text = "Contraseña";
        TB_Clave.Attributes.Add("placeholder", "Digitar Contraseña");
        RFV_Clave.ErrorMessage = "Campo Vacio";
        REV_Clave.ErrorMessage = "No se aceptan caracteres especiales";
        BT_Ingresar.Text = "Ingresar";
        BT_Recuperar.Text = "Recurperar Contraseña";
        BT_Salir.Text = "Salir";
        //L_Error.Text = "Usuario Se Encuentra Inactivo";
        //L_Error.Text = "Usuario Y/o Clave Incorrecto";
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