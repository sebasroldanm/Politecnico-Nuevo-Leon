using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Inicio_MasterInicio : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 43;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        HL_InicioNosotros.Text = encId.CompIdioma["HL_InicioNosotros"].ToString();
        HL_InicioMision.Text = encId.CompIdioma["HL_InicioMision"].ToString();
        HL_InicioVision.Text = encId.CompIdioma["HL_InicioVision"].ToString();
        HL_InicioContactenos.Text = encId.CompIdioma["HL_InicioContactenos"].ToString();
        HL_InicioLoggin.Text = encId.CompIdioma["HL_InicioLoggin"].ToString();

    }
    

}
