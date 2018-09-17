using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_ListarAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Lista de Administrador";
        L_AdminListaAdminTitulo.Text = "Lista de Administrador";
        btn_descargar.Text = "Descargar Lista";

        GridView1.Columns[0].HeaderText = "Foto";
        GridView1.Columns[1].HeaderText = "Apellido";
        GridView1.Columns[2].HeaderText = "Nombre";
        GridView1.Columns[3].HeaderText = "Documento";
        GridView1.Columns[4].HeaderText = "Correo Electónico";
        GridView1.Columns[5].HeaderText = "Teléfono";
        GridView1.Columns[6].HeaderText = "Usuario";
        GridView1.Columns[7].HeaderText = "Estado";


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
        Response.Redirect("/View/Admin/EditarEliminarAdministrador.aspx");
      
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/ReporteAdministradores.aspx' ,'Descargar','height=300', 'width=300')</script>");
    }
}