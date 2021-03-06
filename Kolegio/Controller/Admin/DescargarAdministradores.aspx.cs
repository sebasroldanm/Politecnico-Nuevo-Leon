﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_DescargarAdministradores : System.Web.UI.Page
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
                string urlCarpeta = Server.MapPath("~/FotosUser/");
                LUser log = new LUser();
                LMUser muser = new LMUser();
                //CRS_admin.ReportDocument.SetDataSource(log.reporteAdmin(urlCarpeta));
                CRS_admin.ReportDocument.SetDataSource(muser.reporteAdmin(urlCarpeta));
                CRV_administradores.ReportSource = CRS_admin;
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
        Int32 FORMULARIO = 14;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();

        
        

    }


    protected void CRV_administradores_Init(object sender, EventArgs e)
    {

    }


    


}