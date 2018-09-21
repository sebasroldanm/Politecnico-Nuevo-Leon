using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Estudiante_EstudianteProfesor : System.Web.UI.Page
{
    string destinatario;
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 28;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_EstuMensaTitulo.Text = encId.CompIdioma["L_EstuMensaTitulo"].ToString();
        L_EstuMensProfe.Text = encId.CompIdioma["L_EstuMensProfe"].ToString();
        L_EstuMenAsunto.Text = encId.CompIdioma["L_EstuMenAsunto"].ToString();
        REV_Asuto.ErrorMessage = encId.CompIdioma["REV_Asuto"].ToString();
        L_EstuMenDestinatario.Text = encId.CompIdioma["L_EstuMenDestinatario"].ToString();
        L_EstuMenMensaje.Text = encId.CompIdioma["L_EstuMenMensaje"].ToString();
        REV_Mensaje.ErrorMessage = encId.CompIdioma["REV_Mensaje"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();
        //L_Error_selecione = "Seleccione una opcion"
        //script_msm_enviado="Se ha enviado su mensaje con éxito"
        //L_Error_correo = "El correo digitado no existe"

        Response.Cache.SetNoStore();
        UUser usua = new UUser();
        LLogin log = new LLogin();
        try
        {
            usua = log.logEstudianteSecillo(Session["userId"].ToString());

            destinatario = DDL_Materia.SelectedValue.ToString();
            TB_Destinatario.Text = destinatario;
            TB_Destinatario.Enabled = false;

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
                Response.Redirect("~/View/Estudiante/AccesoDenegado.aspx");
            }
        }
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        UUser usua = new UUser();
        LUser logica = new LUser();

        usua = logica.verificarCorreoEstudoiante(
            DDL_Materia.SelectedValue,
            Session["userId"].ToString(),
            Session["nombre"].ToString(),
            Session["apellido"].ToString(),
            Session["correo"].ToString(),
            TB_Destinatario.Text,
            TB_Asuto.Text,
            TB_Mensaje.Text,
            int.Parse(Session["idioma"].ToString())
            );
        L_Verificar.Text = usua.Mensaje;
        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}