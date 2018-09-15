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
        Page.Title = "Ver Notas - Boletin";
        L_AcuTituloVerNotas.Text = "Ver Notas - Boletin";
        L_AcuEstudiante.Text = "Estudiante :";
        //GW


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