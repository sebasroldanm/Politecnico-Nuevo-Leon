﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_GenerarDiploma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAdminSecillo(Session["userId"].ToString());
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

       
        Session["documentoe"] = GridView1.SelectedRow.Cells[3].Text;
       

        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarDiploma.aspx' ,'Descargar','height=500', 'width=1000')</script>");

      
    }

    protected void ODS_curso_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}