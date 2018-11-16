using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;
using Utilitarios.ClasesServicios;

public partial class View_Profesor_PlatoWeb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Reservar_Click(object sender, EventArgs e)
    {
        try
        {
            SR_ServicioPlatoWeb.ServiciosSoapClient men = new SR_ServicioPlatoWeb.ServiciosSoapClient();
            //men.ClientCredentials.UserName.UserName = "";

            SR_ServicioPlatoWeb.Seguridad obSeguridad = new SR_ServicioPlatoWeb.Seguridad()
            {
                stToken = DateTime.Now.ToString("yyyyMMdd")
            };

            String StToken = men.AutenticationUsuario(obSeguridad);
            if (StToken.Equals("-1")) throw new Exception("Requiere Validacion");

            obSeguridad.AutenticationToken = StToken;
            Usuario usuario = new Usuario();

            usuario.Nombre = "julian";
            usuario.Apellido = "bustos";
            usuario.Email = "juliandd@gmail.com";
            usuario.User_Name1 = "juliandd";
            usuario.Clave = "1234";
            usuario.Rclave = "1234";

            DataTable data = new DataTable();

            String json = JsonConvert.SerializeObject(usuario, Formatting.Indented);

            String dia = tb_fecha.Text.ToString();
            String hora = DDL_Hora.SelectedValue.ToString();
            Int32 cantidad = int.Parse(DDL_Cantidad.SelectedValue.ToString());
            try
            {
                men.Reserva(obSeguridad, dia, hora, cantidad, json);
                Response.Write("<Script language='JavaScript'>parent.alert('Reserva realizada exitosamente');</Script>");
            }
            catch
            {

            }
        }
        catch (Exception ex)
        {
            Response.Write("<Script language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }

}
