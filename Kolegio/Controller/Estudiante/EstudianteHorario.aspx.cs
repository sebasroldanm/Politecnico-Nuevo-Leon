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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 26;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));
        Page.Title = encId.CompIdioma["Title"].ToString();
        L_EstiHorarioTitulo.Text = encId.CompIdioma["L_EstiHorarioTitulo"].ToString();



        //HORARIO
        //ho_lunes = "Lunes";
        //ho_martes = "Martes";
        //ho_miercoles = "Miercoles";
        //ho_jueves = "Jueves";
        //ho_viernes = "Viernes";
        //ho_libre = "Libre";


        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser util = new UUser();
        try
        {
            util = log.logEstudianteSecillo(Session["userId"].ToString());

            LMReg logic = new LMReg();
            String id_est = Session["userId"].ToString();
            int curso = int.Parse(id_est);

            DataTable registro = logic.horario(curso, 3, int.Parse(Session["idioma"].ToString()));
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