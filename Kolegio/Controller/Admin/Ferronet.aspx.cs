using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Admin_Ferronet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
            data = obwsClientesSoap.ConsultaDeProveedores(obclsSeguridad, int.Parse(DDL_Categoria.SelectedValue));
            DataTable inf = JsonConvert.DeserializeObject<DataTable>(data);
            
            

            if (inf.Rows.Count > 0)
            {
                GV_Ferronet.DataSource = inf;
            }
            else
            {
                GV_Ferronet.DataSource = null;
            }

            GV_Ferronet.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.Alert('" + ex.Message + "');</Script>");
        }
    }
}