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


        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
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
        }
        else
            Response.Redirect("AccesoDenegado.aspx");


    }


    protected InfReporte ObtenerInforme()
    {
        //String reg = 

        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["ProfesorCert"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd

        UUser dat = new UUser();
        dat.Documento = Session["userId"].ToString();

        LUser logica = new LUser();

        logica.reporteCertificadoTrabajoProfe(informacion, dat);
        
        return datos;
    }





    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}