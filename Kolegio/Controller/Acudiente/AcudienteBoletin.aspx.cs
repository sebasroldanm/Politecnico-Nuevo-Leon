﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Acudiente_AcudienteBoletin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LMUser logica = new LMUser();
        LLogin log = new LLogin();
        UUser usua = new UUser();
        UUser enc = new UUser();
        try
        {
            usua = log.logAcudienteSecillo(Session["userId"].ToString());

            enc = logica.PL_AcudienteObservador(DDT_estudiante.SelectedValue);
            Session["anio"] = enc.SAño;
            Session["est"] = enc.SEstudiante;
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
                Response.Redirect("~/View/Acudiente/AccesoDenegado.aspx");
            }
        }


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 1;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AcuTituloVerNotas.Text = encId.CompIdioma["L_AcuTituloVerNotas"].ToString();
        L_AcuEstudiante.Text = encId.CompIdioma["L_AcuEstudiante"].ToString();
        GridView1.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GridView1.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GridView1.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GridView1.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GridView1.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();


        

        

        
        

        
        
    }
}