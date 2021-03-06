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


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 20;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminGenerarTitulo.Text = encId.CompIdioma["L_AdminGenerarTitulo"].ToString();
        L_AdminGenerarAño.Text = encId.CompIdioma["L_AdminGenerarAño"].ToString();
        L_AdminGenerarCurso.Text = encId.CompIdioma["L_AdminGenerarCurso"].ToString();
        GridView1.Columns[0].HeaderText = "Foto";
        GridView1.Columns[1].HeaderText = "Apellido";
        GridView1.Columns[2].HeaderText = "Nombre";
        GridView1.Columns[3].HeaderText = "Documento";
        GridView1.Columns[4].HeaderText = "Correo";
        GridView1.Columns[5].HeaderText = "Teléfono";
        GridView1.Columns[6].HeaderText = "Usuario";
        GridView1.Columns[7].HeaderText = "Contraseña";
        GridView1.Columns[8].HeaderText = "Estado";
        GridView1.Columns[9].HeaderText = "Diploma";


        
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