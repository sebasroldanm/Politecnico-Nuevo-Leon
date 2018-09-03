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
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
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
            }
        else
            Response.Redirect("AccesoDenegado.aspx");
        
    }


    protected InfReporte ObtenerInforme()
    {
        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["Estudiante"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd

        UUser usua = new UUser();
        usua.Documento = Session["userId"].ToString(); ;

        LUser reporte = new LUser();

        reporte.reporteCertidicadoEstudiante(informacion, usua);
        
        return datos;
    }




}