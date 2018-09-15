using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Acudiente_AcudienteObservador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Observador";
        L_AcuObEstu.Text = "Observador";
        //GW

        Response.Cache.SetNoStore();
        LUser logic = new LUser();
        LLogin log = new LLogin();
        UUser enc = new UUser();

        try
        {
            enc = logic.PL_AcudienteObservador(DDT_estudiante.SelectedValue);
            Session["anio"] = enc.SAño;
            Session["est"] = enc.SEstudiante;
            enc = log.logAcudienteSecillo(Session["userId"].ToString());
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
                Response.Redirect("~/View/Acudiente/AccesoDenegado.aspx");
            }
        }


        //try
        //{
        //    UUser usua = new UUser();
        //    LUser logica = new LUser();
        //    LLogin log = new LLogin();

        //    usua = log.logAcudienteSecillo(Session["userId"].ToString());

        //    DateTime fecha = DateTime.Now;
        //    string año = (fecha.Year).ToString();
        //    año = año + "-01-01";

        //    logica.acudienteObservador(año, int.Parse(DDT_estudiante.SelectedValue));

        //    Response.Redirect(usua.Url);
        //}
        //catch
        //{

        //}

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}