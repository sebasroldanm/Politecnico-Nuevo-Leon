using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Inicio_InicioContactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        UUser usua = new UUser();
        LUser logica = new LUser();

        usua = logica.verificarCorreoContactenos(
            TB_Nombres.Text, 
            TB_Apellidos.Text, 
            TB_Correo.Text, 
            TB_Telefono.Text, 
            TB_Mensaje.Text);

        this.Page.Response.Write(usua.Notificacion);
        Response.Redirect(usua.Url);
    }
}