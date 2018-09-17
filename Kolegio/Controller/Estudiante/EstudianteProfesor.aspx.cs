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
        Page.Title = "Mensaje Profesor";
        L_EstuMensaTitulo.Text = "Mensaje Profesor";
        L_EstuMensProfe.Text = "Profesor :";
        L_EstuMenAsunto.Text = "Asunto :";
        REV_Asuto.ErrorMessage = "No se aceptan caracteres especiales";
        L_EstuMenDestinatario.Text = "Destinatario :";
        L_EstuMenMensaje.Text = "Mensaje :";
        REV_Mensaje.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";
        L_Verificar.Text = "Debe seleccionar una opcion";

        //script_msm_enviado="Se ha enviado su mensaje con éxito";

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
            TB_Mensaje.Text
            );
        L_Verificar.Text = usua.Mensaje;
        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}