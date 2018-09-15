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
        Page.Title = "Horario";
        L_ProfeConfigHorario.Text = "Horario";
        btn_descargar.Text = "Descargar Certificado";


        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser util = new UUser();
        LReg logic = new LReg();
        try
        {
            String id_est = Session["userId"].ToString();
            int curso = int.Parse(id_est);

            DataTable registro = logic.horario(curso, 2);
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
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_descargar_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript("script", "<script>window.open('CertificadoTrabajoProf.aspx' ,'Descargar','height=300', 'width=300')</script>");

    }
}

