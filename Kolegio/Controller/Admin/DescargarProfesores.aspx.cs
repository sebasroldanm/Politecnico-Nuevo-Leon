using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_DescargarProfesores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 46;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();


        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            try
            {
                string urlCarpeta = Server.MapPath("~/FotosUser/");
                LUser log = new LUser();

                CRS_listaProfesor.ReportDocument.SetDataSource(log.reporteProfe(urlCarpeta));
                CrystalReportViewer1.ReportSource = CRS_listaProfesor;
            }
            catch (Exception)
            {

                throw;
            }
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
    
    protected void CRV_administradores_Init(object sender, EventArgs e)
    {

    }
    
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }

    protected void CrystalReportViewer1_Init1(object sender, EventArgs e)
    {

    }
}