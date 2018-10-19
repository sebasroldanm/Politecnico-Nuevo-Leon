using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            try
            {
                LMUser logicaper = new LMUser();
                UUser enc = new UUser();
                enc.Documento = Session["documentoe"].ToString();


                string urlCarpeta = Server.MapPath("~/FotosUser/");

                //CRS_desdiploma.ReportDocument.SetDataSource(logicaper.reporteDiplomaper(urlCarpeta, enc));
                CRS_desdiploma.ReportDocument.SetDataSource(logicaper.reporteDiploma(urlCarpeta, enc));
                CrystalReportViewer1.ReportSource = CRS_desdiploma;

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


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 44;
        
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();

        
       
    }

    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}

