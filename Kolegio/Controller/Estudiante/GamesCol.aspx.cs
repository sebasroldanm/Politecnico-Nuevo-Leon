using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Estudiante_GamesCol : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SR_ServicioGamesColNoticias.ServiceToken token = new SR_ServicioGamesColNoticias.ServiceToken();
            SR_ServicioGamesColNoticias.Facebook_servideSoapClient etiqueta = new SR_ServicioGamesColNoticias.Facebook_servideSoapClient();

            {
                token.sToken = "colegioecFYoio16Ghu0OfDiHhV";
            };

            string sToken = etiqueta.AutenticacionCliente(token);

            if (sToken.Equals("-1"))
            {
                Response.Write("<Script Language='JavaScript'>parent.alert('Token invalido');</Script>");
                throw new Exception("token invalido");
            }
            token.AutenticacionToken = sToken;
            etiqueta.postpc(token);
 
            GridView1.DataSource = etiqueta.noticias(token);
            GridView1.DataBind();
        }
        catch (Exception ex)
        {

            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }
}