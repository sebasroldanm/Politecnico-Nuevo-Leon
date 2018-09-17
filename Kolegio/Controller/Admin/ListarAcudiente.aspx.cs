using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_ListarAcudiente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "Lista de Acudientes";
        L_AdminListaAcuTitulo.Text = "Lista de Acudientes";
        btn_descargar.Text = "Descargar Lista";
        
        GridView1.Columns[0].HeaderText = "Acudiente";
        GridView1.Columns[1].HeaderText = "Apellido";
        GridView1.Columns[2].HeaderText = "Nombre";
        GridView1.Columns[3].HeaderText = "Documento";
        GridView1.Columns[4].HeaderText = "Teléfono";
        GridView1.Columns[5].HeaderText = "Usuario";
        GridView1.Columns[6].HeaderText = "Contraseña";
        GridView1.Columns[8].HeaderText = "Estudiante";
        GridView1.Columns[9].HeaderText = "Nombre";
        GridView1.Columns[10].HeaderText = "Apellido";
        GridView1.Columns[12].HeaderText = "Documento";
        GridView1.Columns[13].HeaderText = "Teléfono";


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

        Session["documento"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("~/View/Admin/EditarEliminarAcudiente.aspx");
    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarAcudientes.aspx' ,'Descargar','height=300', 'width=300')</script>");
    }
}