using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_ListarProfesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Lista de Profesor";
        L_AdminListaProfeTitulo.Text = "Lista de Profesor";
        btn_descargar.Text = "Descargar Lista";

        GridView1.Columns[0].HeaderText = "Foto";
        GridView1.Columns[1].HeaderText = "Apellido";
        GridView1.Columns[2].HeaderText = "Nombre";
        GridView1.Columns[3].HeaderText = "Documento";
        GridView1.Columns[4].HeaderText = "Estado";
        GridView1.Columns[5].HeaderText = "Correo";
        GridView1.Columns[6].HeaderText = "Teléfono";
        GridView1.Columns[7].HeaderText = "Usuario";
        GridView1.Columns[8].HeaderText = "Contraseña";

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

        protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarProfesores.aspx' ,'Descargar','height=300', 'width=300')</script>");

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["documento"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("/View/Admin/EditarEliminarProfesor.aspx");
    }
}