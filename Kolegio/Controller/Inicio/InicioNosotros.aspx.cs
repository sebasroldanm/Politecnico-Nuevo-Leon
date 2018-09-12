using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Inicio_InicioNosotros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Politecnico Leon";
        IMG_Slider1.ImageUrl = "~/Imagenes/1f.png";
        IMG_Slider2.ImageUrl = "~/Imagenes/4f.png";
        IMG_Slider3.ImageUrl = "~/Imagenes/3f.png";
        L_InNosTitulo.Text = "Plataforma Estudiantil";
        L_InNosDescarga.Text = "Descarga el Manual de Uso desde los siguientes enlaces";
        L_InNosSubtitulo.Text = "Nosotros";
        L_InNosBievenido.Text = "Bienvenidos";
        L_InNosInstalaciones.Text = "Nuestras Instalaciones";


        Session["userId"] = null;
        Session["nombre"] = null;

        LUser logica = new LUser();
        UUser usua = new UUser();



        usua = logica.TraerDatosPagina();

        L_Inicio.Text = usua.Nosotros;

        logica.cerrarSession(Session.SessionID);


        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAño();
        this.Page.Response.Write(enc.Notificacion);

    }
}