using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Estudiante_ReporteCertificado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            usua = logica.logAdminSecillo(Session["userId"].ToString());
            try
            {
                InfReporte reporte = ObtenerInforme();
                CRS_certificado.ReportDocument.SetDataSource(reporte);
                CRV_certificado.ReportSource = CRS_certificado;
            }
            catch (Exception)
            {

                throw;
            }
            Response.Redirect(usua.Url);
        }
        catch
        {

        }
        
    }


    protected InfReporte ObtenerInforme()
    {
        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["Estudiante"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd

        string documento = Session["userId"].ToString(); ;

        LUser reporte = new LUser();

        reporte.reporteCertidicadoEstudiante(informacion, documento);
        
        return datos;
    }




}