using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Profesor_ProfesorListado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            tb_documentoestudiante.ReadOnly = true;
            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {
            try
            {
                usua.Session = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Profesor/AccesoDenegado.aspx");
            }
        }
        tb_documentoestudiante.Text = (string)Session["documentoestudiante"];
        tb_documentoestudiante.ReadOnly = true;


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 36;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_ProfeListado.Text = encId.CompIdioma["L_ProfeListado"].ToString();
        tb_documentoestudiante.Attributes.Add("placeholder", encId.CompIdioma["tb_documentoestudiante"].ToString());
        REV_documentoestudiante.ErrorMessage = encId.CompIdioma["REV_documentoestudiante"].ToString();
        TB_Observ.Attributes.Add("placeholder", encId.CompIdioma["TB_Observ"].ToString());
        REV_Observ.ErrorMessage = encId.CompIdioma["REV_Observ"].ToString();
        btn_Aceptar.Text = encId.CompIdioma["btn_Aceptar"].ToString();


        GridView1.Columns[0].HeaderText = "Fecha y Hora";
        GridView1.Columns[1].HeaderText = "Observación";


        

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
     //  Session["documentoestudiante"] = GridView1.SelectedRow.Cells[0].Text;
     //   Response.Redirect("/View/Admin/EditarEliminarAdministrador.aspx");
    }

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LMReg logic = new LMReg();
        enc = logic.insertObservacion(Session["id"].ToString(), TB_Observ.Text.ToString(), Session.SessionID);

        GridView1.DataBind();
    }

    protected void tb_documentoestudiante_TextChanged(object sender, EventArgs e)
    {

    }
}