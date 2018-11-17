using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
public partial class View_Profesor_Ferronet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_buscarproducto_Click(object sender, EventArgs e)
    {
        try
        {
            string data = null;

            SR_ServicioFerronet.ServiciosSoapClient obwsClientesSoap = new SR_ServicioFerronet.ServiciosSoapClient();
            obwsClientesSoap.ClientCredentials.UserName.UserName = "colegio";
            obwsClientesSoap.ClientCredentials.UserName.Password = "-6K3HCpD@cC{^";

            SR_ServicioFerronet.SeguridadToken obclsSeguridad = new SR_ServicioFerronet.SeguridadToken
            {
                username = "colegio",
                contrasena = "-6K3HCpD@cC{^"
            };


            string stToken = obwsClientesSoap.autenticacionUsuario(obclsSeguridad);

            if (stToken.Equals("-1"))
            {
                throw new Exception("Requiere Validacion");

            }
            obclsSeguridad.AutenticacionToken = stToken;
            // data = 
            String resultado = "";
            //DataTable inf = 
            List<Productos> a= JsonConvert.DeserializeObject<List<Productos>>(obwsClientesSoap.ConsultaDeProductos(obclsSeguridad, tb_buscar.Text));
            List<Productos> u = new List<Productos>();
            foreach (Productos p in a)
            {
                resultado = p.Imagen.Replace("~", "http://ferronet.hopto.org");
                p.Imagen = resultado;
                u.Add(p);
            }

            GV_Ferronet.DataSource = u;
            GV_Ferronet.DataBind();

            /*if (inf.Rows.Count > 0)
            {
                GV_Ferronet.DataSource = inf;
            }
            else
            {
                GV_Ferronet.DataSource = null;
            }*/

           // GV_Ferronet.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.Alert('" + ex.Message + "');</Script>");
        }
    }
}