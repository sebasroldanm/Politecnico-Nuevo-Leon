﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Acudiente_MasterAcudiente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 59;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        L_ACuSubTitulo.Text = encId.CompIdioma["L_ACuSubTitulo"].ToString();
        L_AcuSubBoletin.Text = encId.CompIdioma["L_AcuSubBoletin"].ToString();
        L_AcuSubObservador.Text = encId.CompIdioma["L_AcuSubObservador"].ToString();
        L_AcuSubMensaje.Text = encId.CompIdioma["L_AcuSubMensaje"].ToString();
        L_AcuSubConfig.Text = encId.CompIdioma["L_AcuSubConfig"].ToString();
        btn_cerrar_sesion.Text = encId.CompIdioma["L_AcuSubCerrar"].ToString();
    }
    protected void btn_cerrar_sesion_click(object sender, EventArgs e)
    {
        LMUser logica = new LMUser();


        logica.limpiaSesionActiva(Session["userName"].ToString());
        logica.cerrarSession(Session.SessionID);


        Response.Redirect("~/View/Inicio/InicioNosotros.aspx");
    }
}
