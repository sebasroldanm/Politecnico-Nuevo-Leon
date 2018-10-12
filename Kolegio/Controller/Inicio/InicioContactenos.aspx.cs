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
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 30;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_InConTitulo.Text = encId.CompIdioma["L_InConTitulo"].ToString();
        L_InConSubTitulo.Text = encId.CompIdioma["L_InConSubTitulo"].ToString();
        TB_Nombres.Attributes.Add("placeholder", encId.CompIdioma["TB_Nombres"].ToString());
        REV_Nombres.ErrorMessage = encId.CompIdioma["REV_Nombres"].ToString();
        TB_Apellidos.Attributes.Add("placeholder", encId.CompIdioma["TB_Apellidos"].ToString());
        REV_Apellidos.ErrorMessage = encId.CompIdioma["REV_Apellidos"].ToString();
        TB_Correo.Attributes.Add("placeholder", encId.CompIdioma["TB_Correo"].ToString());
        REV_Correo.ErrorMessage = encId.CompIdioma["REV_Correo"].ToString();
        TB_Telefono.Attributes.Add("placeholder", encId.CompIdioma["TB_Telefono"].ToString());
        REV_Correo.ErrorMessage = encId.CompIdioma["REV_Correo"].ToString();
        TB_Mensaje.Attributes.Add("placeholder", encId.CompIdioma["TB_Mensaje"].ToString());
        REV_Mensaje.ErrorMessage = encId.CompIdioma["REV_Mensaje"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();

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
            TB_Mensaje.Text,
            int.Parse(Session["idioma"].ToString()));

        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}