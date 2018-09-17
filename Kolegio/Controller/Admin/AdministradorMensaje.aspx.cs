using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Administrador_AdministradorMensaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 5;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminMensaTitulo.Text = encId.CompIdioma["L_AdminMensaTitulo"].ToString();
        L_AdminMensAsunto.Text = encId.CompIdioma["L_AdminMensAsunto"].ToString();
        REV_Asuto.ErrorMessage = encId.CompIdioma["REV_Asuto"].ToString();
        L_AdminMensDestinatario.Text = encId.CompIdioma["L_AdminMensDestinatario"].ToString();
        REV_Destinatario.ErrorMessage = encId.CompIdioma["REV_Destinatario"].ToString();
        L_AdminMensMensaje.Text = encId.CompIdioma["L_AdminMensMensaje"].ToString();
        REV_Mensaje.ErrorMessage = encId.CompIdioma["REV_Mensaje"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();


        //verificarCorreo
        L_Verificar.Text = "El correo digitado no existe";
        //scrip_msm_enviado="Se ha enviado su mensaje con éxito";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {
            try
            {
                usua.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Admin/AccesoDenegado.aspx");
            }

        }
        
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.verificarCorreo(
            Session["userId"].ToString(),
            Session["nombre"].ToString(),
            Session["apellido"].ToString(),
            Session["correo"].ToString(),
            TB_Destinatario.Text,
            TB_Asuto.Text,
            TB_Mensaje.Text
            );

        this.Page.Response.Write(usua.Notificacion);
        L_Verificar.Text = usua.Mensaje;
        TB_Destinatario.Text = usua.CDestinatario;
        
    }
}