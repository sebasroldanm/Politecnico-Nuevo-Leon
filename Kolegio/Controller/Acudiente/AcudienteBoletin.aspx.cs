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

        try
        {
            LUser logica = new LUser();
            LLogin log = new LLogin();
            UUser usua = new UUser();

            usua = log.logAcudienteSecillo(Session["userId"].ToString());

            logica.acudienteBoletin(usua.Año, int.Parse(DDT_estudiante.SelectedValue));
            Response.Redirect(usua.Url);
        }
        catch
        {

        }

        

        
        

        
        
    }
}