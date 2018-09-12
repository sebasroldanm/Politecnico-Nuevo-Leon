using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Inicio_InicioContactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contactenos";
        L_InConTitulo.Text = "Contactenos";
        L_InConSubTitulo.Text = "Contacto con nosotros";
        TB_Nombres.Attributes.Add("placeholder", "Nombres");
        REV_Nombres.ErrorMessage = "No se aceptan caracteres especiales";
        TB_Apellidos.Attributes.Add("placeholder", "Apellidos");
        REV_Apellidos.ErrorMessage = "No se aceptan caracteres especiales";
        TB_Correo.Attributes.Add("placeholder", "Correo");
        REV_Correo.ErrorMessage = "No se aceptan caracteres especiales";
        TB_Telefono.Attributes.Add("placeholder", "Teléfono");
        REV_Correo.ErrorMessage = "No se aceptan caracteres especiales";
        TB_Mensaje.Attributes.Add("placeholder", "Enviamos tu mensaje, nos contactaremos contigo lo mas pronto posible");
        REV_Mensaje.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";

    }
    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        UUser usua = new UUser();
        LUser logica = new LUser();

        usua = logica.verificarCorreoContactenos(
            TB_Nombres.Text, 
            TB_Apellidos.Text, 
            TB_Correo.Text, 
            TB_Telefono.Text, 
            TB_Mensaje.Text);

        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}