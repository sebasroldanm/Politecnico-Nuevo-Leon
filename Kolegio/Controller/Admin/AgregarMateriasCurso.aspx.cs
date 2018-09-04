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

public partial class View_Admin_AgregarMateriasCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        horario();
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {

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
        DUser datos = new DUser();

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
        DaoUser datos = new DaoUser();
        EUser enc = new EUser();
        datos.insertar_Año();

        DataTable reg = datos.obtienePromedio();
        int n = reg.DefaultView.Count;

        for (int i = 0; i < n; i++)
        {
            int a = Convert.ToInt32(reg.Rows[i]["nombre_curso"]);
            double b = Convert.ToDouble(reg.Rows[i]["notadef"]);
            if ((Convert.ToInt32(reg.Rows[i]["nombre_curso"]) > 1100) & (Convert.ToDouble(reg.Rows[i]["notadef"]) >= 30.0))
            {
                enc.Id_estudiante = reg.Rows[i]["id_usua"].ToString();
                //update
                datos.editarOnce(enc);

            }
        }
        DataTable ultaño = datos.obtenerUltimoAño();
        enc.Año = ultaño.Rows[0]["id_anio"].ToString();

        DataTable registro = datos.obtienePromedio();
        n = registro.DefaultView.Count;

        for (int i = 0; i < n; i++)
        {
            if (Convert.ToDouble(registro.Rows[i]["notadef"]) >= 30.0)
            {
                int curso = Convert.ToInt32(registro.Rows[i]["nombre_curso"]);
                enc.Id_estudiante = registro.Rows[i]["id_usua"].ToString();
                curso = curso + 100;
                if (curso >= 1 & curso <= 9)
                {
                    enc.Curso = "00" + (curso.ToString());
                }
                else
                {
                    enc.Curso = curso.ToString();
                }
                DataTable idcurso = datos.obteneridCurso(enc);
                enc.Curso = idcurso.Rows[0]["id_ancu"].ToString();
                datos.insertarEstudianteCurso(enc);
            }
            else
            {
                int curso = Convert.ToInt32(registro.Rows[i]["nombre_curso"]);
                enc.Id_estudiante = registro.Rows[i]["id_usua"].ToString();
                if (curso >= 1 & curso <= 9)
                {
                    enc.Curso = "00" + (curso.ToString());
                }
                else
                {
                    enc.Curso = curso.ToString();
                }
                DataTable idcurso = datos.obteneridCurso(enc);
                enc.Curso = idcurso.Rows[0]["id_ancu"].ToString();
                datos.insertarEstudianteCurso(enc);
            }
        }
        this.Page.Response.Write("<script language='JavaScript'>window.alert('Se ha migraido de año con Exito');</script>");

    }


}
