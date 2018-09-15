﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_Profesor_ProfesorMensaje : System.Web.UI.Page
{
    string destinatario;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Mensaje";
        L_ProfeMensajeTitulo.Text = "Mensaje Acudiente:";
        L_ProfeMensCurso.Text = "Curso :";
        L_ProfeMensMateria.Text = "Materia :";
        L_ProfeMensAlumon.Text = "Alumno :";
        B_Actualizar.Text = "Actualizar Destinatario";
        L_ProfeMensAsunto.Text = "Asunto :";
        L_ProfeMensDestinatario.Text = "Destinatario :";
        L_ProfeMensMensaje.Text = "Mensaje :";
        REV_Mensaje.ErrorMessage = "No se aceptan caracteres especiales";
        B_Enviar.Text = "Enviar";
        L_Verificar.Text = "";

        Response.Cache.SetNoStore();
        LLogin log = new LLogin();
        UUser usua = new UUser();
        LUser logica = new LUser();
        try
        {
            usua = logica.profeMensaje();

            Session["anio"] = usua.Año;
            TB_Destinatario.Enabled = usua.BotonFalse;

            usua = log.logAdminSecillo(Session["userId"].ToString());
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

    protected void B_Actualizar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        enc = logic.ActualizarMensajeProf(int.Parse(DDL_Alumno.SelectedValue));
        TB_Destinatario.Text = enc.Mensaje;
        destinatario = enc.CDestinatario;
    }

    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        LReg logic = new LReg();

        string userId = Session["userId"].ToString();
        string persona = Session["nombre"].ToString();
        string apePersona = Session["apellido"].ToString();
        string correo_l = Session["correo"].ToString();
        string asunto = TB_Asuto.Text;
        string mensaje = TB_Mensaje.Text;

        enc = logic.enviarMensajeProf(DDL_Materia.SelectedValue.ToString(), DDL_Alumno.SelectedValue.ToString(), DDL_Curso.SelectedValue.ToString(), userId, persona, apePersona, correo_l, asunto, mensaje, TB_Destinatario.Text.ToString(), destinatario);

        this.RegisterStartupScript(enc.MensajeAcudiente, enc.Notificacion);

        L_Verificar.Text = enc.Mensaje;
        TB_Destinatario.Text = enc.CDestinatario;

    }
}