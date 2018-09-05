using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;
//using Datos;

public partial class View_Inicio_InicioNosotros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Session["userId"] = "wpygkcrggjyqsrtf50nlfjlu";
        Session["nombre"] = null;

        LUser logica = new LUser();
        UUser usua = new UUser();
        //DUser user = new DUser();



        usua = logica.TraerDatosPagina();

        L_Inicio.Text = usua.Nosotros;

        logica.cerrarSession(Session.SessionID);


        //DataTable regi = user.incio();

        //if (regi.Rows.Count > 0)
        //{
        //    L_Inicio.Text = Convert.ToString(regi.Rows[0]["inicio_cont"].ToString());
        //}

        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAño();
        this.Page.Response.Write(enc.Notificacion);

    }
}