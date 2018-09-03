using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Datos;
using Utilitarios;


public partial class View_Profesor_ProfesorMensaje : System.Web.UI.Page
{
    string destinatario;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            DaoUser datos = new DaoUser();
            DateTime fecha = DateTime.Now;
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            DataTable re = datos.obtenerAniodeCurso(año);
            Session["anio"] = re.Rows[0]["id_anio"];
            TB_Destinatario.Enabled = false;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
    }

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        DUser datos = new DUser();
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.ActualizarMensajeProf(int.Parse(DDL_Alumno.SelectedValue));
        TB_Destinatario.Text = enc.Mensaje;
        destinatario = enc.CDestinatario;
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        DUser datos = new DUser();
        UUser enc = new UUser();
        LReg logic = new LReg();

        string userId = Session["userId"].ToString();
        string persona = Session["nombre"].ToString();
        string apePersona = Session["apellido"].ToString();
        string correo_l = Session["correo"].ToString();
        string asunto = TB_Asuto.Text;
        string mensaje = TB_Mensaje.Text;

        enc = logic.enviarMensajeProf(DDL_Materia.SelectedValue.ToString(), DDL_Alumno.SelectedValue.ToString(), DDL_Curso.SelectedValue.ToString(), userId, persona, apePersona, correo_l, asunto, mensaje, TB_Destinatario.Text.ToString(), destinatario);

        this.RegisterStartupScript(enc.MensajeAcudiente, enc.Notificacion);

        L_Verificar.Text = enc.Mensaje;
        TB_Destinatario.Text = enc.CDestinatario;

    }
}