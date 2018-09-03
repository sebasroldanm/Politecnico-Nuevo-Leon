﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios;

public partial class View_Acudiente_AcudienteConfiguracion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {

            ImagenEst.ImageUrl = Session["foto"].ToString();
            tb_correo.ReadOnly = true;
            tb_contrasenia.ReadOnly = true;
            tb_usuario.ReadOnly = true;
            tb_Foto.Visible = false;
            lb_foto.Visible = false;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
        

    }

    protected void btn_Editar_Click(object sender, EventArgs e)
    {
        tb_usuario.Text = Session["userName"].ToString();
        tb_contrasenia.Text = Session["clave"].ToString();
        tb_correo.Text = Session["correo"].ToString();
        ImagenEst.ImageUrl = Session["foto"].ToString();
        btn_Editar.Visible = false;
        btn_cancelar.Visible = true;
        btn_Aceptar.Visible = true;
        tb_correo.ReadOnly = false;
        tb_contrasenia.ReadOnly = false;
        tb_Foto.Visible = true;
        lb_foto.Visible = true;
    }

    protected void btn_Aceptar_Click(object sender, EventArgs e)
    {
        UUser enc = new UUser();
        DUser datos = new DUser();
        LUser logic = new LUser();

        String foto = System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName);
        enc = logic.ModifConfiguracion(
                           tb_Foto,
                           tb_usuario.Text,
                           tb_contrasenia.Text,
                           tb_correo.Text,
                           Session.SessionID,
                           Session["userId"].ToString(),
                           Session["foto"].ToString(),
                           Session["userName"].ToString(),
                           Session["clave"].ToString(),
                           Session["correo"].ToString()
            );


        Session["userName"] = enc.UserName;
        Session["clave"] = enc.Clave;
        Session["correo"] = enc.Correo;
        Session["foto"] = enc.Foto;

        this.Page.Response.Write("<script language='JavaScript'>window.alert('Datos Modificados con Exito');</script>");

        ImagenEst.ImageUrl = Session["foto"].ToString();
        tb_usuario.Text = Session["username"].ToString();
        tb_contrasenia.Text = Session["clave"].ToString();
        tb_correo.Text = Session["correo"].ToString();
        btn_Editar.Visible = true;
        btn_Aceptar.Visible = false;

    }


    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/View/Acudiente/AcudienteBoletin.aspx");
    }
}