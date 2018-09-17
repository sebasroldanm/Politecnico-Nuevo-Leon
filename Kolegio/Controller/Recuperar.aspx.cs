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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 41;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_RecuperarTitulo.Text = encId.CompIdioma["L_RecuperarTitulo"].ToString();
        L_RecuperarUsuario.Text = encId.CompIdioma["L_RecuperarUsuario"].ToString();
        TB_Usuario.Attributes.Add("placeholder", encId.CompIdioma["TB_Usuario"].ToString());
        RFV_Usuario.ErrorMessage = encId.CompIdioma["RFV_Usuario"].ToString();
        REV_Usuario.ErrorMessage = encId.CompIdioma["REV_Usuario"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();
        //B_Salir.Text = encId.CompIdioma["B_Salir"].ToString();

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