using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;
using Datos;

public partial class View_Estudiante_EstudianteHorario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {

            UUser util = new UUser();
            LReg logic = new LReg();
            DUser datos = new DUser();
            String id_est = Session["userId"].ToString();
            int curso = int.Parse(id_est);

            DataTable registro = logic.horario(curso, 3);
            GridView1.DataSource = registro;
            GridView1.DataBind();
        }
        else
            Response.Redirect("~/View/Estudiante/AccesoDenegado.aspx");
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}