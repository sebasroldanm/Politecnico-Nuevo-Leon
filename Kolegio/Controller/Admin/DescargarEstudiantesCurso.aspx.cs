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

public partial class View_Admin_DescargarEstudiantesCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            try
            {
                InfReporte reporte = ObtenerInforme();
                CRS_listaestcur.ReportDocument.SetDataSource(reporte);
                CrystalReportViewer1.ReportSource = CRS_listaestcur;
            }
            catch (Exception)
            {

                throw;
            }
     
    }

    protected InfReporte ObtenerInforme()
    {

        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        int curs;
        curs = Convert.ToInt16(Session["Cursoestu"]);

        informacion = datos.Tables["EstudianteCurso"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd

        LUser estudiante = new LUser();

        estudiante.reporteEstudiante(informacion, curs);
        
        return datos;
    }




    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}