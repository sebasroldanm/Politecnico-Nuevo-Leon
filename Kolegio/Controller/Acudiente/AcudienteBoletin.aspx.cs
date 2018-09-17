using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Acudiente_AcudienteBoletin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 1;
        Page.Title = "Ver Notas - Boletin";
        L_AcuTituloVerNotas.Text = "Ver Notas - Boletin";
        L_AcuEstudiante.Text = "Estudiante :";
        GridView1.Columns[0].HeaderText = "Materia";
        GridView1.Columns[1].HeaderText = "Primer Periodo";
        GridView1.Columns[2].HeaderText = "Segundo Periodo";
        GridView1.Columns[3].HeaderText = "Tercer Periodo";
        GridView1.Columns[4].HeaderText = "Nota Definitiva";


        Response.Cache.SetNoStore();
        LUser logica = new LUser();
        LLogin log = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = log.logAcudienteSecillo(Session["userId"].ToString());

            logica.PL_AcudienteObservador(DDT_estudiante.SelectedValue);
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
                Response.Redirect("~/View/Acudiente/AccesoDenegado.aspx");
            }
        }

        

        
        

        
        
    }
}