using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_DescargarAcudientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            try
            {
                InfReporte reporte = ObtenerInforme();
                CRS_acudientes.ReportDocument.SetDataSource(reporte);
                CrystalReportViewer1.ReportSource = CRS_acudientes;
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

        informacion = datos.Tables["Acudiente"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd


        LUser administrador = new LUser();

        administrador.reporteAcudiente(informacion);
        
        return datos;
}



    protected void CRV_administradores_Init(object sender, EventArgs e)
    {

    }







    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
