using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Profesor_CertificadoTrabajoProf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 61;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logProfesorSecillo(Session["userId"].ToString());
            try
            {
                InfReporte reporte = ObtenerInforme();
                CRS_certProf.ReportDocument.SetDataSource(reporte);
                CrystalReportViewer1.ReportSource = CRS_certProf;
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
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }

    }


    protected InfReporte ObtenerInforme()
    {
        //String reg = 

        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["ProfesorCert"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd

        string documento = Session["userId"].ToString();

        LUser logica = new LUser();

        logica.reporteCertificadoTrabajoProfe(informacion, documento);
        
        return datos;
    }





    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}