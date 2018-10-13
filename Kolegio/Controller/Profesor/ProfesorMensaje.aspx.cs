using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_Profesor_ProfesorMensaje : System.Web.UI.Page
{
    string destinatario;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser usua = new UUser();
        LUser logica = new LUser();
        try
        {
            usua = logica.profeMensaje();

            Session["anio"] = usua.Año;
            TB_Destinatario.Enabled = usua.BotonFalse;

            usua = log.logAdminSecillo(Session["userId"].ToString());
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
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }



        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 37;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_ProfeMensajeTitulo.Text = encId.CompIdioma["L_ProfeMensajeTitulo"].ToString();
        L_ProfeMensCurso.Text = encId.CompIdioma["L_ProfeMensCurso"].ToString();
        L_ProfeMensMateria.Text = encId.CompIdioma["L_ProfeMensMateria"].ToString();
        L_ProfeMensAlumon.Text = encId.CompIdioma["L_ProfeMensAlumon"].ToString();
        B_Actualizar.Text = encId.CompIdioma["B_Actualizar"].ToString();
        L_ProfeMensAsunto.Text = encId.CompIdioma["L_ProfeMensAsunto"].ToString();
        L_ProfeMensDestinatario.Text = encId.CompIdioma["L_ProfeMensDestinatario"].ToString();
        L_ProfeMensMensaje.Text = encId.CompIdioma["L_ProfeMensMensaje"].ToString();
        REV_Mensaje.ErrorMessage = encId.CompIdioma["REV_Mensaje"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();
        //script_msm_enviado="Su Mensaje ha sido Enviado.";

        
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.ActualizarMensajeProf(int.Parse(DDL_Alumno.SelectedValue));
        TB_Destinatario.Text = enc.Mensaje;
        destinatario = enc.CDestinatario;
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        string userId = Session["userId"].ToString();
        string persona = Session["nombre"].ToString();
        string apePersona = Session["apellido"].ToString();
        string correo_l = Session["correo"].ToString();
        string asunto = TB_Asuto.Text;
        string mensaje = TB_Mensaje.Text;

        enc = logic.enviarMensajeProf(DDL_Materia.SelectedValue.ToString(), DDL_Alumno.SelectedValue.ToString(), DDL_Curso.SelectedValue.ToString(), userId, persona, apePersona, correo_l, asunto, mensaje, TB_Destinatario.Text.ToString(), destinatario, int.Parse(Session["idioma"].ToString()));

        this.RegisterStartupScript(enc.MensajeAcudiente, enc.Notificacion);

        L_Verificar.Text = enc.Mensaje;
        TB_Destinatario.Text = enc.CDestinatario;

    }
}