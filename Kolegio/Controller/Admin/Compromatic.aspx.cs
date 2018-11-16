using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;

public partial class View_Admin_Compromatic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string data = null;
            string categoria = null;

            SR_ServicioCompramatic.WebServiceSoapClient obwsClientesSoapClient = new SR_ServicioCompramatic.WebServiceSoapClient();

            SR_ServicioCompramatic.clsSeguridad obclsSeguridad = new SR_ServicioCompramatic.clsSeguridad
            {
                stToken = "73f1e357308e5dbfe426fea1a462e832",
                nomEmp = "colegio"
            };


            string stToken = obwsClientesSoapClient.AutenticacionUsuario(obclsSeguridad);

            if (stToken.Equals("-1"))
            {
                throw new Exception("Loggin Incorrecto");

            }
            obclsSeguridad.AutenticacionToken = stToken;
            categoria = obwsClientesSoapClient.traer_categorias_productos(obclsSeguridad);
            DataTable cate = JsonConvert.DeserializeObject<DataTable>(categoria);
            if (IsPostBack == false)
            {
                DDL_Categoria.DataSource = cate;
                DDL_Categoria.DataBind();
            }
            data = obwsClientesSoapClient.traer_por_categoria(obclsSeguridad, int.Parse(DDL_Categoria.SelectedValue));
            //data = obwsClientesSoapClient.traer_por_categoria(obclsSeguridad, int.Parse(DDL_Categoria.SelectedValue));
            DataTable inf = JsonConvert.DeserializeObject<DataTable>(data);

            if (inf.Rows.Count > 0)
            {
                string test = inf.Rows[0]["_foto"].ToString();
                GV_Compramatic.DataSource = inf;
            }
            else
            {
                GV_Compramatic.DataSource = null;
            }

            GV_Compramatic.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.Alert('" + ex.Message + "');</Script>");
        }
 
    }

 
}