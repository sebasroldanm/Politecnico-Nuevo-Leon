﻿using System;
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
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
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
        Int32 FORMULARIO = 13;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
    }


    protected InfReporte ObtenerInforme()
    {
        DataTable informacion = new DataTable();
        InfReporte datos = new InfReporte();

        informacion = datos.Tables["Acudiente"]; // nombre de la tabla que cree en crystal en el InfReporte.xsd


        //LUser administrador = new LUser();
        LMUser logica = new LMUser();
        //administrador.reporteAcudiente(informacion);
        logica.reporteAcudiente(informacion);
        return datos;
}



    protected void CRV_administradores_Init(object sender, EventArgs e)
    {

    }







    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
