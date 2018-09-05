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
        Response.Cache.SetNoStore();

        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();
            tb_documentoestudiante.ReadOnly = true;
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {

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