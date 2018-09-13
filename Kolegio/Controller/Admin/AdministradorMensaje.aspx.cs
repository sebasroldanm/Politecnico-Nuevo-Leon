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
        Page.Title = "Mensaje";
        L_AdminMensaTitulo.Text = "Mensaje Nuevo";
        L_AdminMensAsunto.Text = "Asunto :";
        REV_Asuto.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminMensDestinatario.Text = "Destinatario :";
        REV_Destinatario.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminMensMensaje.Text = "Mensaje :";
        REV_Mensaje.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";
        //L_Verificar.Text -> Ver funciones

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