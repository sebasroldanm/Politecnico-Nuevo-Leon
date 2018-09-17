﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Profesor_ProfesorListado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Lista de Estudiantes";
        L_ProfeListado.Text = "Lista de Estudiantes";
        tb_documentoestudiante.Attributes.Add("placeholder", "Numero de Documento");
        REV_documentoestudiante.ErrorMessage = "Digitar Solo Números";
        TB_Observ.Attributes.Add("placeholder", "Observacion");
        REV_Observ.ErrorMessage = "No se aceptan caracteres especiales";
        btn_Aceptar.Text = "Agregar Observacion";
        GridView1.Columns[0].HeaderText = "Fecha y Hora";
        GridView1.Columns[1].HeaderText = "Observación";


        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {   
            tb_documentoestudiante.ReadOnly = true;
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
        tb_documentoestudiante.Text = (string)Session["documentoestudiante"];
        tb_documentoestudiante.ReadOnly = true;

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
     //  Session["documentoestudiante"] = GridView1.SelectedRow.Cells[0].Text;
     //   Response.Redirect("/View/Admin/EditarEliminarAdministrador.aspx");
    }

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();
        enc = logic.insertObservacion(Session["id"].ToString(), TB_Observ.Text.ToString());

        GridView1.DataBind();
    }

    protected void tb_documentoestudiante_TextChanged(object sender, EventArgs e)
    {

    }
}