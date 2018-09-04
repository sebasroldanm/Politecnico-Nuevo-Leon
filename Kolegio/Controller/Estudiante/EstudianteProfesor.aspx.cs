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
        Response.Cache.SetNoStore();
        try
        {
            UUser usua = new UUser();
            LLogin log = new LLogin();

            usua = log.logEstudianteSecillo(Session["userId"].ToString());

            destinatario = DDL_Materia.SelectedValue.ToString();
            TB_Destinatario.Text = destinatario;
            TB_Destinatario.Enabled = false;

            Response.Redirect(usua.Url);
        }
        catch
        {

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

        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}