﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documento"].ToString());
            tb_AministradorAdministradorId.Text = Session["documento"].ToString();
            tb_AdministradorAdministradorNombre.ReadOnly = usua.BotonTrue;
            tb_AdministradorAdministradorApellido.ReadOnly = usua.BotonTrue;
            tb_AdministradorAdministradorCorreo.ReadOnly = usua.BotonTrue;
            tb_AdministradorAdministradorDireccion.ReadOnly = usua.BotonTrue;
            tb_AdministradorTelefono.ReadOnly = usua.BotonTrue;
            tb_AdministradorUsuario.ReadOnly = usua.BotonTrue;
            tb_AdministradorContrasenia.ReadOnly = usua.BotonTrue;
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

    protected void btn_AdministradorAceptar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_AministradorAdministradorId.Text));


        tb_AministradorAdministradorId.ReadOnly = usua.B_Botones1;
        tb_AdministradorAdministradorNombre.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorNombre.Text = usua.Nombre;
        tb_AdministradorAdministradorApellido.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorApellido.Text = usua.Apellido;
        tb_AdministradorAdministradorCorreo.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorCorreo.Text = usua.Correo;
        tb_AdministradorAdministradorDireccion.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorDireccion.Text = usua.Direccion;
        tb_AdministradorTelefono.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorTelefono.Text = usua.Telefono;
        tb_AdministradorUsuario.ReadOnly = true;
        tb_AdministradorUsuario.Text = usua.UserName;
        tb_AdministradorContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        Session["fotosinedit"] = usua.Foto;
        L_ErrorAdmin.Text = "";

        btn_AdministradorEditar.Visible = usua.B_Botones1;
        btn_AdministradorNuevo.Visible = usua.B_Botones1;
        btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        L_ErrorAdmin.Text = usua.Mensaje;

    }

    protected void btn_AdministradorEdditar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();
        string foto = cargarImagen();

        usua = logica.editarAdmin(
            tb_AdministradorAdministradorNombre.Text,
            tb_AdministradorUsuario.Text,
            tb_AdministradorContrasenia.Text,
            tb_AdministradorAdministradorCorreo.Text,
            tb_AdministradorAdministradorApellido.Text,
            tb_AdministradorAdministradorDireccion.Text,
            tb_AdministradorTelefono.Text,
            int.Parse(tb_AministradorAdministradorId.Text),
            DDL_Estado.SelectedValue,
            fechanac.Text,
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            Session.SessionID,
            foto,
            Session["fotosinedit"].ToString()
            );

        this.Page.Response.Write(usua.Notificacion);

        tb_AministradorAdministradorId.ReadOnly = usua.BotonTrue;
        tb_AdministradorAdministradorNombre.ReadOnly = usua.BotonFalse;
        tb_AdministradorAdministradorApellido.ReadOnly = usua.BotonFalse;
        tb_AdministradorAdministradorCorreo.ReadOnly = usua.BotonFalse;
        tb_AdministradorAdministradorDireccion.ReadOnly = usua.BotonFalse;
        tb_AdministradorTelefono.ReadOnly = usua.BotonFalse;
        tb_AdministradorUsuario.ReadOnly = usua.BotonFalse;
        tb_AdministradorContrasenia.ReadOnly = usua.BotonFalse;
        btn_AdministradorEditar.Visible = usua.BotonFalse;
        btn_AdministradorNuevo.Visible = usua.BotonTrue;
        btn_AdministradorAceptar.Visible = usua.BotonFalse;
    }

    

protected void btn_AdministradorNuevo_Click(object sender, EventArgs e)
    {
        tb_AministradorAdministradorId.Enabled = true;
        tb_AdministradorAdministradorNombre.Text = "";
        tb_AdministradorUsuario.Text = "";
        tb_AdministradorContrasenia.Text = "";
        tb_AdministradorAdministradorCorreo.Text = "";
        tb_AdministradorAdministradorApellido.Text = "";
        tb_AdministradorAdministradorDireccion.Text = "";
        tb_AdministradorTelefono.Text = "";
        tb_AministradorAdministradorId.Text = "";
        fechanac.Text = "";

        L_ErrorAdmin.Text = "";

        L_Error.Text = "";

        ImagenEst.ImageUrl = "";

        tb_AdministradorAdministradorNombre.ReadOnly = true;
        tb_AdministradorAdministradorApellido.ReadOnly = true;
        tb_AdministradorAdministradorCorreo.ReadOnly = true;
        tb_AdministradorAdministradorDireccion.ReadOnly = true;
        tb_AdministradorTelefono.ReadOnly = true;
        tb_AdministradorUsuario.ReadOnly = true;
        tb_AdministradorContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_AministradorAdministradorId.ReadOnly = false;
        
        tb_AministradorAdministradorId.Focus();
        btn_AdministradorEditar.Visible = false;
        btn_AdministradorNuevo.Visible = false;
        btn_AdministradorAceptar.Visible = true;

    }

    protected string cargarImagen()
    {
        LUser logic = new LUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_AdministradorFoto.PostedFile.FileName), System.IO.Path.GetExtension(tb_AdministradorFoto.PostedFile.FileName), tb_AdministradorFoto.ToString(), Server.MapPath("~/FotosUser"));
        try
        {
            ClientScriptManager cm = this.ClientScript;
            //cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);
            btnigm_calendar.Visible = true;

            tb_AdministradorFoto.PostedFile.SaveAs(enc.SaveLocation);
            return enc.FotoCargada;
        }
        catch
        {
            return null;
        }
    }

    

}