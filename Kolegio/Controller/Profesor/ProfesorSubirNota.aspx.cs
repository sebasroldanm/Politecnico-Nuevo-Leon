using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Profesor_ProfesorSubirNota : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 39;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_ProfeSubirTitulo.Text = encId.CompIdioma["L_ProfeSubirTitulo"].ToString();
        L_ProfeSubirCurso.Text = encId.CompIdioma["L_ProfeSubirCurso"].ToString();
        L_ProfeSubirMateria.Text = encId.CompIdioma["L_ProfeSubirMateria"].ToString();
        L_ProfeSubirAlumno.Text = encId.CompIdioma["L_ProfeSubirAlumno"].ToString();
        ButtonVerNota.Text = encId.CompIdioma["ButtonVerNota"].ToString();
        L_ProfeSubirNota1.Text = encId.CompIdioma["L_ProfeSubirNota1"].ToString();
        tb_nt.Attributes.Add("placeholder", encId.CompIdioma["tb_nt"].ToString());
        REV_nt.ErrorMessage = encId.CompIdioma["REV_nt"].ToString();
        RV_N1.ErrorMessage = encId.CompIdioma["RV_N1"].ToString();
        L_ProfeSubirNota2.Text = encId.CompIdioma["L_ProfeSubirNota2"].ToString();
        tb_nt2.Attributes.Add("placeholder", encId.CompIdioma["tb_nt2"].ToString());
        REV_nt2.ErrorMessage = encId.CompIdioma["REV_nt2"].ToString();
        RV_n2.ErrorMessage = encId.CompIdioma["RV_n2"].ToString();
        L_ProfeSubirNota3.Text = encId.CompIdioma["L_ProfeSubirNota3"].ToString();
        tb_nt3.Attributes.Add("placeholder", encId.CompIdioma["tb_nt3"].ToString());
        REV_nt3.ErrorMessage = encId.CompIdioma["REV_nt3"].ToString();
        RV_n3.ErrorMessage = encId.CompIdioma["RV_n3"].ToString();
        L_ProfeSubirNotaDef.Text = encId.CompIdioma["L_ProfeSubirNotaDef"].ToString();
        tb_denifitiva.Attributes.Add("placeholder", encId.CompIdioma["tb_denifitiva"].ToString());
        btn_Subirnota.Text = encId.CompIdioma["btn_Subirnota"].ToString();


        //subirNota
        //L_Error_subirnota.Text = "Falta seleccionar";

        //verNota
        //L_Error_falta_seleccionar.Text = "Falta seleccionar";


        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();

        LReg logic = new LReg();
        UUser enc = new UUser();
        try
        {   
            enc = logic.ObAniodeCurso(Session["userId"].ToString());
            Session["anio"] = enc.Año;
            btn_Subirnota.Visible = false;
            ButtonVerNota.Visible = true;
            tb_nt.Enabled = false;
            tb_nt2 .Enabled = false;
            tb_nt3.Enabled = false;

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
        
    }

    protected void ddt_curso_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_Subirnota_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.subirNota(ddl_alumno.SelectedValue, ddl_materia.SelectedValue, ddt_curso.SelectedValue, tb_nt.Text, tb_nt2.Text, tb_nt3.Text);
        L_Error.Text = enc.Mensaje;

        tb_denifitiva.Text = enc.Notadef;
        ButtonVerNota.Visible = true;
        btn_Subirnota.Visible = false;


    }

    protected void ButtonVerNota_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.verNota(ddl_alumno.SelectedValue, ddl_materia.SelectedValue, ddt_curso.SelectedValue);

        tb_nt.Text = enc.Nota1;
        tb_nt2.Text = enc.Nota2;
        tb_nt3.Text = enc.Nota3;
        tb_denifitiva.Text = enc.Notadef;

        L_Error.Text = enc.Mensaje;

        btn_Subirnota.Visible = true;
        tb_nt.Enabled = true;
        tb_nt2.Enabled = true;
        tb_nt3.Enabled = true;

    }
}