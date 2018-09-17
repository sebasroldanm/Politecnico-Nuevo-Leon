using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_AgregarEstudiantesCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 9;
        Page.Title = "Agregar Estudiates Curso";
        L_AdminEstuCursoTitulo.Text = "Agregar Estudiantes a un Curso";
        L_AdminEstuCursoSubAnio.Text = "Año :";
        L_AdminEstuCursoSubCurso.Text = "Curso :";        
        btn_Aceptar.Text = "Agregar al Curso";
        GridView1.Columns[0].HeaderText = "Documento";
        GridView1.Columns[1].HeaderText = "Nombre";
        GridView1.Columns[2].HeaderText = "Apellido";
        GridView1.Columns[3].HeaderText = "Agregar al Curso";
        GridView1.Columns[4].HeaderText = "Agregar Curso";


        //L_ErrorUsuario_estudiante_curso.Text = "Debe Elegir un Curso";


        //L_ErrorUsuario.Text_aceptar = "Debe Elegir un Curso";
        //L_OkUsuario.Text_aceptar = "Estudiantes Agregados al curso";


        Response.Cache.SetNoStore();
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.selecEstudianteACurso(ddt_curso.SelectedValue, GridView1.SelectedRow.Cells[0].Text);
        GridView1.DataBind();
        L_ErrorUsuario.Text = enc.Mensaje; 
    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.agregarEstudianteACurso(ddt_anio.SelectedValue, ddt_curso.SelectedValue, GridView1.Rows.Count, GridView1);
               
        L_ErrorUsuario.Text = enc.Mensaje;
        L_OkUsuario.Text = enc.MensajeAcudiente;
        GridView1.DataBind();
    }

}

