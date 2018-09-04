using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Recuperar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.recuperarContra(TB_Usuario.Text);
        L_Verificar.Text = usua.Mensaje;
        //DaoUser dao = new DaoUser();
        //System.Data.DataTable validez = dao.generarToken(TB_Usuario.Text);
        //if (int.Parse(validez.Rows[0]["id_usua"].ToString()) > 0)
        //{
        //    EUserToken token = new EUserToken();
        //    token.Id = int.Parse(validez.Rows[0]["id_usua"].ToString());
        //    token.Nombre = validez.Rows[0]["nombre_usua"].ToString();
        //    token.User_name = validez.Rows[0]["user_name"].ToString();
        //    token.Estado = int.Parse(validez.Rows[0]["state_t"].ToString());

        //    token.Correo = validez.Rows[0]["correo"].ToString();
        //    token.Fecha = DateTime.Now.ToFileTimeUtc();


        //    String userToken = encriptar(JsonConvert.SerializeObject(token));
        //    dao.almacenarToken(userToken, token.Id);

        //    Correo correo = new Correo();

        //    String mensaje = "Su link de acceso es: " + "http://localhost:58629/View/Contrasenia.aspx?" + userToken;
        //    correo.enviarCorreo(token.Correo, userToken, mensaje);

        //    L_Verificar.Text = "Revisar su correo para recuperar contraseña";
        //}
        //else if (int.Parse(validez.Rows[0]["id_usua"].ToString()) == -2)
        //{
        //    L_Verificar.Text = "Ya extsite un link de recuperación, por favor verifique su correo.";
        //}
        //else
        //{
        //    L_Verificar.Text = "El usuario digitado no existe";
        //}
    }
    
}