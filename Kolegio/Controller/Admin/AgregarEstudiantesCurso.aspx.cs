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

        try
        {
            usua.SUserName = Session["empezar"].ToString();
            MPE_Idioma.Show();
        }
        catch
        {

        }


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 9;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminEstuCursoTitulo.Text = encId.CompIdioma["L_AdminEstuCursoTitulo"].ToString();
        L_AdminEstuCursoSubAnio.Text = encId.CompIdioma["L_AdminEstuCursoSubAnio"].ToString();
        L_AdminEstuCursoSubCurso.Text = encId.CompIdioma["L_AdminEstuCursoSubCurso"].ToString();
        btn_Aceptar.Text = encId.CompIdioma["btn_Aceptar"].ToString();
        GridView1.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GridView1.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GridView1.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GridView1.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GridView1.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();


        //L_ErrorUsuario_estudiante_curso.Text = "Debe Elegir un Curso";


        //L_ErrorUsuario.Text_aceptar = "Debe Elegir un Curso";
        //L_OkUsuario.Text_aceptar = "Estudiantes Agregados al curso";
        
    }

    protected void descartar_idioma_Click(object sender, EventArgs e)
    {
        LIdioma logica = new LIdioma();
        UIdioma enc = new UIdioma();

        int idioma = Convert.ToInt32(Session["nombreIdioma"]);

        enc = logica.eliminarIdiomaCompleto(idioma);

        Session["empezar"] = null;

    }

    protected void volver_idioma_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditarPaginaInicio.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LMReg logic = new LMReg();

        enc = logic.selecEstudianteACurso(ddt_curso.SelectedValue, GridView1.SelectedRow.Cells[0].Text, int.Parse(Session["idioma"].ToString()));
        GridView1.DataBind();
        L_ErrorUsuario.Text = enc.Mensaje; 
    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LMReg logic = new LMReg();

        enc = logic.agregarEstudianteACurso(ddt_anio.SelectedValue, ddt_curso.SelectedValue, GridView1.Rows.Count, GridView1, int.Parse(Session["idioma"].ToString()));
               
        L_ErrorUsuario.Text = enc.Mensaje;
        L_OkUsuario.Text = enc.MensajeAcudiente;
        GridView1.DataBind();
    }

}

