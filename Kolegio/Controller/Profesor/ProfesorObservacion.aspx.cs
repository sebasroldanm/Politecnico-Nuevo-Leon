using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_Profesor_ProfesorObservacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            LReg logic = new LReg();
            UUser enc = new UUser();
            enc = logic.ObAniodeCurso(Session["userId"].ToString());
            Session["anio"] = enc.Año;
        }
        else
            Response.Redirect("~/View/Acudiente/AccesoDenegado.aspx");

    }

    protected void ddt_curso_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DUser datos = new DUser();
        UUser enc = new UUser();
        LReg logic = new LReg();

        Session["documentoestudiante"] = GridView2.SelectedRow.Cells[0].Text;
        enc = logic.selecObservador(Session["documentoestudiante"].ToString());
       
        Session["id"] = enc.Id_estudiante;

        Response.Redirect(enc.Mensaje);

    }
}