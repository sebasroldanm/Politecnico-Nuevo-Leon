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


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 23;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminListaEstuTitulo.Text = encId.CompIdioma["L_AdminListaEstuTitulo"].ToString();
        L_AdminListaEstuAnio.Text = encId.CompIdioma["L_AdminListaEstuAnio"].ToString();
        L_AdminListaEstuCurso.Text = encId.CompIdioma["L_AdminListaEstuCurso"].ToString();
        btn_descargar.Text = encId.CompIdioma["btn_descargar"].ToString();
        B_diploma.Text = encId.CompIdioma["B_diploma"].ToString();

        GridView1.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GridView1.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GridView1.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GridView1.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GridView1.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();
        GridView1.Columns[5].HeaderText = encId.CompIdioma["GridView1_5"].ToString();
        GridView1.Columns[6].HeaderText = encId.CompIdioma["GridView1_6"].ToString();
        GridView1.Columns[7].HeaderText = encId.CompIdioma["GridView1_7"].ToString();
        GridView1.Columns[8].HeaderText = encId.CompIdioma["GridView1_8"].ToString();

        
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