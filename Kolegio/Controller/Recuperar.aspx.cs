using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Recuperar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        Page.Title = "Recuperar Cuenta";
        L_RecuperarTitulo.Text = "Recuperar Cuenta";
        L_RecuperarUsuario.Text = "Usuario :";
        TB_Usuario.Attributes.Add("placeholder", "Digitar Usuario");
        RFV_Usuario.ErrorMessage = "Campo Vacio";
        REV_Usuario.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";
        //VER FUNCIOEN logica.recuperarContra
        //L_Verificar.Text = "Revisar su correo para recuperar contraseña";
        //L_Verificar.Text = "Ya extsite un link de recuperación, por favor verifique su correo.";
        //L_Verificar.Text = "El usuario digitado no existe";

    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.recuperarContra(TB_Usuario.Text);
        L_Verificar.Text = usua.Mensaje;
        
    }


    protected void B_Salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Loggin.aspx");
    }
}