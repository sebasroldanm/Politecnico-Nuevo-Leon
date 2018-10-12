using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Profesor_ProfesorObservacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 38;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_ProfeObseTitulo.Text = encId.CompIdioma["L_ProfeObseTitulo"].ToString();
        L_ProfeObseCurso.Text = encId.CompIdioma["L_ProfeObseCurso"].ToString();


        GridView2.Columns[0].HeaderText = "Documento";
        GridView2.Columns[1].HeaderText = "Apellido";
        GridView2.Columns[2].HeaderText = "Nombre";
        GridView2.Columns[3].HeaderText = "Observador";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            LReg logic = new LReg();
            UUser enc = new UUser();
            enc = logic.ObAniodeCurso(Session["userId"].ToString());
            Session["anio"] = enc.Año;

            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {
            try
            {
                usua.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }

    }

    protected void ddt_curso_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        Session["documentoestudiante"] = GridView2.SelectedRow.Cells[0].Text;
        enc = logic.selecObservador(Session["documentoestudiante"].ToString());
       
        Session["id"] = enc.Id_estudiante;

        Response.Redirect(enc.Url);

    }
}