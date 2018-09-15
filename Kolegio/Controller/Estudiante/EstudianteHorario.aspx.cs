using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Estudiante_EstudianteHorario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Horario";
        L_EstiHorarioTitulo.Text = "Horario";

        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser util = new UUser();
        try
        {
            util = log.logEstudianteSecillo(Session["userId"].ToString());

            LReg logic = new LReg();
            String id_est = Session["userId"].ToString();
            int curso = int.Parse(id_est);

            DataTable registro = logic.horario(curso, 3);
            GridView1.DataSource = registro;
            GridView1.DataBind();

            Response.Redirect(util.Url);
        }
        catch
        {
            try
            {
                util.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Estudiante/AccesoDenegado.aspx");
            }
        }
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}