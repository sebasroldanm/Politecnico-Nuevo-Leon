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
        Response.Cache.SetNoStore();
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            usua = logica.logAcudienteSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {

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