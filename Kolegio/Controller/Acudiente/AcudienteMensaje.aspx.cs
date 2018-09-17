using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Acudiente_AcudienteMensaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 3;
        Page.Title = "Mensaje Profesor";
        L_AcuMensTitulo.Text = "Mensaje Profesor";
        L_AcuMensEstudiante.Text = "Estudiante :";
        L_AcuMensProfe.Text = "Profesor :";
        L_AcuMensAsunto.Text = "Asunto :";
        REV_Asuto.ErrorMessage = "No se aceptan caracteres especiales";
        L_AcuMensMensaje.Text = "Mensaje :";
        RV_Mensaje.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";
        L_Verificar.Text = "El correo digitado no existe";
        //script_mensaje="Se ha enviado su mensaje con éxito";


        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAcudienteSecillo(Session["userId"].ToString());
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
                Response.Redirect("~/View/Acudiente/AccesoDenegado.aspx");
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
            DDL_Profesor.SelectedValue.ToString(),
            TB_Asuto.Text,
            TB_Mensaje.Text
            );

        this.Page.Response.Write(usua.Notificacion);
        L_Verificar.Text = usua.Mensaje;

        TB_Mensaje.Text = usua.Mensaje;
    }
}