using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Data;

public partial class View_Profesor_PlatoWeb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Reservar_Click(object sender, EventArgs e)
    {

        try
        {
            Servicios.ServiciosSoapClient men = new Servicios.ServiciosSoapClient();
            //men.ClientCredentials.UserName.UserName = "";

            Servicios.Seguridad obSeguridad = new Servicios.Seguridad()
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

            String dia = TextBox1.Text.ToString();
            String hora = DropDownList1.SelectedValue.ToString();
            Int32 cantidad = int.Parse(DropDownList2.SelectedValue.ToString());
            try
            {
                men.Reserva(obSeguridad, dia, hora, cantidad, json);
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
}