using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Datos;
using Logica;

public partial class View_Admin_AgregarEstudiantesCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            Console.WriteLine("");
        }
        else
            Response.Redirect("~/View/Admin/AccesoDenegado.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DUser datos = new DUser();
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.selecEstudianteACurso(ddt_curso.SelectedValue, GridView1.SelectedRow.Cells[0].Text);
        GridView1.DataBind();
        L_ErrorUsuario.Text = enc.Mensaje; 
    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        DUser datos = new DUser();
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.agregarEstudianteACurso(ddt_anio.SelectedValue, ddt_curso.SelectedValue, GridView1.Rows.Count, GridView1);
               
        L_ErrorUsuario.Text = enc.Mensaje;
        L_OkUsuario.Text = enc.MensajeAcudiente;
        GridView1.DataBind();
    }

}

