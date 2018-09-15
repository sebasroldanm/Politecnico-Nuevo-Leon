using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_ListarEstudiante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Lista de Estudiante";
        L_AdminListaEstuTitulo.Text = "Lista de Estudiante";
        L_AdminListaEstuAnio.Text = "Año :";
        L_AdminListaEstuCurso.Text = "Curso :";
        btn_descargar.Text = "Descargar Lista";
        B_diploma.Text = "Descargar Diploma";

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

        protected void btn_listaestudiante_Click(object sender, EventArgs e)
    {

    }
    
    protected void btn_descargardiploma_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/GenerarDiploma.aspx' ,'Descargar','height=300', 'width=300')</script>");
    }

    protected void btn_todos_Click(object sender, EventArgs e)
    {
 
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["documentoe"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("/View/Admin/EditarEliminarEstudiante.aspx");
    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Session["Cursoestu"] = ODL_Curso.SelectedValue;
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarEstudiantesCurso.aspx' ,'Descargar','height=300', 'width=300')</script>");


    }
}