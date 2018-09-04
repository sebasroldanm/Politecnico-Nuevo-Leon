using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Inicio_Vision : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userId"] = null;
        Session["nombre"] = null;

       

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.TraerDatosPagina();

        L_Vision.Text = usua.Vision;


        //DaoUser user = new DaoUser();
        //EUser datos = new EUser();
        //datos.Session = Session.SessionID;
        //user.cerrarSession(datos);


        //DataTable registros = user.incio();

        //if (registros.Rows.Count > 0)
        //{
        //    L_Vision.Text = Convert.ToString(registros.Rows[0]["vision_inicio"].ToString());
        //}
    }
}