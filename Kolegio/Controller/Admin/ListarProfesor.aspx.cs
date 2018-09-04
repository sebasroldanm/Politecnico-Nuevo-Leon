﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_ListarProfesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {

        }
    }

        protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/DescargarProfesores.aspx' ,'Descargar','height=300', 'width=300')</script>");

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["documento"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("/View/Admin/EditarEliminarProfesor.aspx");
    }
}