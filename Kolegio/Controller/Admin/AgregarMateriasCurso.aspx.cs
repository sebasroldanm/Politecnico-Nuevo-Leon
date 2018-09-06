using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarMateriasCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        horario();
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

    protected void btn_CursoMateriaAceptar_Click(object sender, EventArgs e)
    {

        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.agregaraHorario(ddt_curso.SelectedValue, ddt_anio.SelectedValue, ddt_Dia.SelectedValue, ddt_Docente.SelectedValue, ddt_Hora.SelectedValue, ddt_Materia.SelectedValue);
        L_Error.Text = enc.Mensaje;
        horario();
        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada a Curso con Exito');</script>");

    }

    protected void ddt_Hora_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void horario()
    {
        UUser util = new UUser();
        LReg logic = new LReg();

        int curso = int.Parse(ddt_curso.SelectedValue);

        DataTable registro = logic.horario(curso, 1);
        GridView1.DataSource = registro;
        GridView1.DataBind();

    }

    protected void btn_agregam_Click(object sender, EventArgs e)
    {
        LReg l_reg = new LReg();
        UUser user = new UUser();
        user = l_reg.agregarMateria(tb_materia.Text, Session.SessionID);

        L_Error.Text = user.Mensaje;
    }

    protected void btn_pasaranio_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAñoClick();
        this.Page.Response.Write(enc.Notificacion);

    }


}
