using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Estudiante_EstudianteVernotas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Ver Notas";
        L_EstuVerNotasTitulo.Text = "Ver Notas";
        GV_boletin.Columns[0].HeaderText = "Materia";
        GV_boletin.Columns[1].HeaderText = "Primer Periodo";
        GV_boletin.Columns[2].HeaderText = "Segundo Periodo";
        GV_boletin.Columns[3].HeaderText = "Tercer Periodo";
        GV_boletin.Columns[4].HeaderText = "Nota Definitiva";

        Response.Cache.SetNoStore();
        LUser logic = new LUser();
        UUser enc = new UUser();
        LLogin log = new LLogin();
        try
        {
            enc = logic.PL_EstudianteVerNotas(Session["userId"].ToString());
            Session["anio"] = enc.SAño;
            Session["userId"] = enc.Id_estudiante;

            enc = log.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(enc.Url);

        }
        catch
        {
            try
            {
                enc.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Estudiante/AccesoDenegado.aspx");
            }
        }

    }

    protected void GV_boletin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}