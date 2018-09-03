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
        Response.Cache.SetNoStore();


        LUser logica = new LUser();
        UUser usua = new UUser();

        DateTime fecha = DateTime.Now;
        string año = (fecha.Year).ToString();
        año = año + "-01-01";


        logica.acudienteBoletin(año, int.Parse(DDT_estudiante.SelectedValue));


        

        //DataTable re = datos.obtenerAniodeCurso(año);
        //enc.Año = re.Rows[0]["id_anio"].ToString();
        //enc.Id_estudiante = DDT_estudiante.SelectedValue;

        //DataTable registros = datos.obtenerCursoEst(enc);
        //if (registros.Rows.Count > 0)
        //{
        //    Session["anio"] = registros.Rows[0]["id_ancu"].ToString();
        //    Session["est"] = DDT_estudiante.SelectedValue;
        //}
        //else
        //{
        //    Session["anio"] = "0";
        //    Session["est"] = DDT_estudiante.SelectedValue;
        //}

    }
}