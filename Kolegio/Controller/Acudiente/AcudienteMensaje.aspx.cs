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
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 3;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));


        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AcuMensTitulo.Text = encId.CompIdioma["L_AcuMensTitulo"].ToString();
        L_AcuMensEstudiante.Text = encId.CompIdioma["L_AcuMensEstudiante"].ToString();
        L_AcuMensProfe.Text = encId.CompIdioma["L_AcuMensProfe"].ToString();
        L_AcuMensAsunto.Text = encId.CompIdioma["L_AcuMensAsunto"].ToString();
        REV_Asuto.ErrorMessage = encId.CompIdioma["REV_Asuto"].ToString();
        L_AcuMensMensaje.Text = encId.CompIdioma["L_AcuMensMensaje"].ToString();
        RV_Mensaje.ErrorMessage = encId.CompIdioma["RV_Mensaje"].ToString();
        B_Enviar.Text = encId.CompIdioma["B_Enviar"].ToString();
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
            TB_Mensaje.Text,
            int.Parse(Session["idioma"].ToString())
            );

        this.Page.Response.Write(usua.Notificacion);
        L_Verificar.Text = usua.Mensaje;

        TB_Mensaje.Text = usua.Mensaje;
    }
}