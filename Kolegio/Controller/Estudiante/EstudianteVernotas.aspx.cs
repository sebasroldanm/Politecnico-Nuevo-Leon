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
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 29;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));


        Page.Title = encId.CompIdioma["Title"].ToString();
        L_EstuVerNotasTitulo.Text = encId.CompIdioma["L_EstuVerNotasTitulo"].ToString();

        GV_boletin.Columns[0].HeaderText = encId.CompIdioma["GridView1_0"].ToString();
        GV_boletin.Columns[1].HeaderText = encId.CompIdioma["GridView1_1"].ToString();
        GV_boletin.Columns[2].HeaderText = encId.CompIdioma["GridView1_2"].ToString();
        GV_boletin.Columns[3].HeaderText = encId.CompIdioma["GridView1_3"].ToString();
        GV_boletin.Columns[4].HeaderText = encId.CompIdioma["GridView1_4"].ToString();

        Response.Cache.SetNoStore();
        LMUser logic = new LMUser();
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