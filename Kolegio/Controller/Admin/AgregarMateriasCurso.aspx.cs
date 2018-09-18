﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarMateriasCurso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 10;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreMateCursoTitulo.Text = encId.CompIdioma["L_AdminAgreMateCursoTitulo"].ToString();
        L_AdminAgreMateCursoSubAgregarMateria.Text = encId.CompIdioma["L_AdminAgreMateCursoSubAgregarMateria"].ToString();
        REV_materia.ErrorMessage = encId.CompIdioma["REV_materia"].ToString();
        tb_materia.Attributes.Add("placeholder", encId.CompIdioma["tb_materia"].ToString());
        btn_agregam.Text = encId.CompIdioma["btn_agregam"].ToString();
        L_AdminAgreMateCursoSubAnio.Text = encId.CompIdioma["L_AdminAgreMateCursoSubAnio"].ToString();
        L_AdminAgreMateCursoSubCurso.Text = encId.CompIdioma["L_AdminAgreMateCursoSubCurso"].ToString();
        L_AdminAgreMateCursoSubMateria.Text = encId.CompIdioma["L_AdminAgreMateCursoSubMateria"].ToString();
        L_AdminAgreMateCursoSubDia.Text = encId.CompIdioma["L_AdminAgreMateCursoSubDia"].ToString();
        L_AdminAgreMateCursoSubHora.Text = encId.CompIdioma["L_AdminAgreMateCursoSubHora"].ToString();
        btn_CursoMateriaAceptar.Text = encId.CompIdioma["btn_CursoMateriaAceptar"].ToString();

        //funcion agregaraHorario        
        //L_Error_falta.Text = "Falta seleccionar";
        //L_Error.Text_materia_insertada = "Materia Insertada a Curso con Exito";
        //L_Error.Text_docente_cruce = "El docente presenta un cruce de Horarios";
        //L_Error.Text_curce = "Presenta un cruce de Horarios";

        //funcion agregarMateria
        //L_Error.Text_falta = "Materia Insertada con Exito";
        //L_Error.Text_materia_ya_esta = "La Materia ya se encuentra en nuestra Base de Datos";


        //pasarAñoClick
        //script_pasar_anio = "Se ha migraido de año con Exito";

        Response.Cache.SetNoStore();
        horario();
        LLogin logica = new LLogin();
        UUser usua = new UUser();

        try
        {
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
                Response.Redirect("~/View/Admin/AccesoDenegado.aspx");
            }
        }
    }

    protected void btn_CursoMateriaAceptar_Click(object sender, EventArgs e)
    {

        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.agregaraHorario(ddt_curso.SelectedValue, ddt_anio.SelectedValue, ddt_Dia.SelectedValue, ddt_Docente.SelectedValue, ddt_Hora.SelectedValue, ddt_Materia.SelectedValue);
        L_Error.Text = enc.Mensaje;
        horario();
        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada a Curso con Exito');</script>");

    }

    protected void ddt_Hora_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void horario()
    {
        UUser util = new UUser();
        LReg logic = new LReg();

        int curso = int.Parse(ddt_curso.SelectedValue);

        DataTable registro = logic.horarioEng(curso, 1);
        GridView1.DataSource = registro;
        GridView1.DataBind();

    }

    protected void btn_agregam_Click(object sender, EventArgs e)
    {
        LReg l_reg = new LReg();
        UUser user = new UUser();
        user = l_reg.agregarMateria(tb_materia.Text, Session.SessionID);

        L_Error.Text = user.Mensaje;
    }

    protected void btn_pasaranio_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.pasarAñoClick();
        this.Page.Response.Write(enc.Notificacion);

    }


}
