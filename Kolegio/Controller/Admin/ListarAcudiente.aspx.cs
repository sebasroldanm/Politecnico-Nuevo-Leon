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

        Session["documentoa"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("/View/Admin/EditarEliminarAcudiente.aspx");
    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarAcudientes.aspx' ,'Descargar','height=300', 'width=300')</script>");
    }
}