using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Logica;

public partial class View_Profesor_Uniempleo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_buscaroferta_Click(object sender, EventArgs e)
    {
        try
        {

            SR_ServicioUniempleo.ServidorUniempleoSoapClient servicio = new SR_ServicioUniempleo.ServidorUniempleoSoapClient();
            servicio.ClientCredentials.UserName.UserName = "colegio";

            servicio.ClientCredentials.UserName.Password = "HwbHFgKSWE";
            SR_ServicioUniempleo.SeguridadToken ObjSeguridad = new SR_ServicioUniempleo.SeguridadToken()
            {
                username = "colegio",
                Pass = "HwbHFgKSWE"

            };
            String tokken = servicio.AutenticacionUsuario(ObjSeguridad);
            if (tokken.Equals("-1"))
            {
                throw new Exception("Requiere Validacion");
            }
            ObjSeguridad.Token_Autenticacion = tokken;
            List<JoinOferta> a = JsonConvert.DeserializeObject<List<JoinOferta>>(servicio.Busqueda_Ofertas(ObjSeguridad, tb_buscar.Text));
            GridView1.DataSource = a;
            GridView1.DataBind();
        }

        catch (Exception)
        {
            Response.Write("<Script Language='JavaScript'>parent.Alert('El servicio No se encuentra Activo');</Script>");

           

        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}