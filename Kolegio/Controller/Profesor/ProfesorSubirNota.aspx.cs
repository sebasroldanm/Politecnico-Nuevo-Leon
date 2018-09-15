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
        Page.Title = "Subir Nota";
        L_ProfeSubirTitulo.Text = "Subir Nota";
        L_ProfeSubirCurso.Text = "Curso :";
        L_ProfeSubirMateria.Text = "Materia :";
        L_ProfeSubirAlumno.Text = "Alumno :";
        ButtonVerNota.Text = "Ver Notas";
        L_Error.Text = "Falta seleccionar";
        L_Error.Text = "Falta seleccionar";
        L_Error.Text = "";
        L_ProfeSubirNota1.Text = "Nota 1:";
        tb_nt.Attributes.Add("placeholder", "Nota 1");
        REV_nt.ErrorMessage = "Digitar dos numeros";
        RV_N1.ErrorMessage = "Sobrepasó el limite";
        L_ProfeSubirNota2.Text = "Nota 2:";
        tb_nt2.Attributes.Add("placeholder", "Nota 2");
        REV_nt2.ErrorMessage = "Digitar dos numeros";
        RV_n2.ErrorMessage = "Sobrepasó el limite";
        L_ProfeSubirNota3.Text = "Nota 3:";
        tb_nt3.Attributes.Add("placeholder", "Nota 3");
        REV_nt3.ErrorMessage = "Digitar dos numeros";
        RV_n3.ErrorMessage = "Sobrepasó el limite";
        L_ProfeSubirNotaDef.Text = "Nota Definitiva:";
        tb_denifitiva.Attributes.Add("placeholder", "Nota Definitiva");
        btn_Subirnota.Text = "Subir Calificacion";

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