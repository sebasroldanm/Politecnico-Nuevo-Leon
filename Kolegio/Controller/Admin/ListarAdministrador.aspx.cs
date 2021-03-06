﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Admin_ListarAdministrador : System.Web.UI.Page
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


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 22;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminListaAdminTitulo.Text = encId.CompIdioma["L_AdminListaAdminTitulo"].ToString();
        btn_descargar.Text = encId.CompIdioma["btn_descargar"].ToString();

        GridView1.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GridView1.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GridView1.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GridView1.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GridView1.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();
        GridView1.Columns[5].HeaderText = encId.CompIdioma["GridView1_5"].ToString();
        GridView1.Columns[6].HeaderText = encId.CompIdioma["GridView1_6"].ToString();
        GridView1.Columns[7].HeaderText = encId.CompIdioma["GridView1_7"].ToString();


        
    }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["documento"] = GridView1.SelectedRow.Cells[3].Text;
        Response.Redirect("/View/Admin/EditarEliminarAdministrador.aspx");
      
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('/View/Admin/ReporteAdministradores.aspx' ,'Descargar','height=300', 'width=300')</script>");
    }
}