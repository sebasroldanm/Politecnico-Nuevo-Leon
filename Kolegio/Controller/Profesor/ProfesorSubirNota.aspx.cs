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
        Response.Cache.SetNoStore();
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            LReg logic = new LReg();
            UUser enc = new UUser();
            enc = logic.ObAniodeCurso(Session["userId"].ToString());
            Session["anio"] = enc.Año;
            btn_Subirnota.Visible = false;
            ButtonVerNota.Visible = true;

            usua = logica.logAdminSecillo(Session["userId"].ToString());
            Response.Redirect(usua.Url);
        }
        catch
        {

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

    }
}