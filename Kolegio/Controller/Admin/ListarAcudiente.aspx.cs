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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 21;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminListaAcuTitulo.Text = encId.CompIdioma["L_AdminListaAcuTitulo"].ToString();
        btn_descargar.Text = encId.CompIdioma["btn_descargar"].ToString();

        GridView1.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GridView1.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GridView1.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GridView1.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GridView1.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();
        GridView1.Columns[5].HeaderText = encId.CompIdioma["GridView1_5"].ToString();
        GridView1.Columns[6].HeaderText = encId.CompIdioma["GridView1_6"].ToString();
        GridView1.Columns[8].HeaderText = encId.CompIdioma["GridView1_8"].ToString();
        GridView1.Columns[9].HeaderText = encId.CompIdioma["GridView1_9"].ToString();
        GridView1.Columns[10].HeaderText = encId.CompIdioma["GridView1_10"].ToString();
        GridView1.Columns[11].HeaderText = encId.CompIdioma["GridView1_11"].ToString();
        GridView1.Columns[12].HeaderText = encId.CompIdioma["GridView1_12"].ToString();


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