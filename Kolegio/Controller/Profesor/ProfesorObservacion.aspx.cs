﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Profesor_ProfesorObservacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Lista Estudiantes";
        L_ProfeObseTitulo.Text = "Lista Estudiantes";
        L_ProfeObseCurso.Text = "Curso :";
        //GridView2.HeaderRow.Cells[0].Text = "Documento";
        //GridView2.HeaderRow.Cells[1].Text = "Nombre";
        //GridView2.HeaderRow.Cells[2].Text = "Apellido";
        //GridView2.HeaderRow.Cells[3].Text = "Observador";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            LReg logic = new LReg();
            UUser enc = new UUser();
            enc = logic.ObAniodeCurso(Session["userId"].ToString());
            Session["anio"] = enc.Año;

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
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }

    }

    protected void ddt_curso_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        Session["documentoestudiante"] = GridView2.SelectedRow.Cells[0].Text;
        enc = logic.selecObservador(Session["documentoestudiante"].ToString());
       
        Session["id"] = enc.Id_estudiante;

        Response.Redirect(enc.Url);

    }
}