using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Profesor_ProfesorHorario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser util = new UUser();
        LMReg logic = new LMReg();
        try
        {
            String id_est = Session["userId"].ToString();
            int curso = int.Parse(id_est);

            DataTable registro = logic.horario(curso, 2, int.Parse(Session["idioma"].ToString()));
            GridView1.DataSource = registro;
            GridView1.DataBind();

            util = log.logAdminSecillo(Session["userId"].ToString());
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
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }



        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 35;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_ProfeConfigHorario.Text = encId.CompIdioma["L_ProfeConfigHorario"].ToString();
        btn_descargar.Text = encId.CompIdioma["btn_descargar"].ToString();



        //HORARIO
        //ho_lunes = "Lunes";
        //ho_martes = "Martes";
        //ho_miercoles = "Miercoles";
        //ho_jueves = "Jueves";
        //ho_viernes = "Viernes";
        //ho_libre = "Libre";


        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('CertificadoTrabajoProf.aspx' ,'Descargar','height=300', 'width=300')</script>");

    }
}

