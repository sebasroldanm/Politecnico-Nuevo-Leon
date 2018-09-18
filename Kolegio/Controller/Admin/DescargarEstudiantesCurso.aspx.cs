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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 45;

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
                InfReporte reporte = ObtenerInforme();
                CRS_listaestcur.ReportDocument.SetDataSource(reporte);
                CrystalReportViewer1.ReportSource = CRS_listaestcur;
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