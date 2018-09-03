﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarProfesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            tb_DocenteId.Text = (string)Session["documento"];
            tb_DocenteNombre.ReadOnly = true;
            tb_DocenteApellido.ReadOnly = true;
            tb_DocenteCorreo.ReadOnly = true;
            tb_DocenteDireccion.ReadOnly = true;
            tb_DocenteTelefono.ReadOnly = true;
            tb_DocenteUsuario.ReadOnly = true;
            tb_DocenteContrasenia.ReadOnly = true;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
        
    }
    
   

    protected void btn_DocenteAceptar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_DocenteId.Text));

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();

        //usua.Documento = tb_DocenteId.Text;

        //DataTable registros = dat.obtenerUsuarioMod(usua);

        //if (registros.Rows.Count > 0)
        //{
        //    tb_DocenteNombre.Text = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
        //    tb_DocenteApellido.Text = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
        //    tb_DocenteCorreo.Text = Convert.ToString(registros.Rows[0]["correo"].ToString());
        //    tb_DocenteDireccion.Text = Convert.ToString(registros.Rows[0]["direccion"].ToString());
        //    tb_DocenteTelefono.Text = Convert.ToString(registros.Rows[0]["telefono"].ToString());
        //    tb_DocenteUsuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //    tb_DocenteContrasenia.Text = Convert.ToString(registros.Rows[0]["clave"].ToString());
        //    fechanac.Text = Convert.ToString(registros.Rows[0]["fecha_nac"].ToString());
        //    ImagenEst.ImageUrl = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());


        //    Session["fotosinedit"] = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());






        //    ddt_lugarnacimDep.SelectedValue = Convert.ToString(registros.Rows[0]["dep_nacimiento"].ToString());

        //    DDT_Ciudad.DataBind();

        //    DDT_Ciudad.SelectedValue = Convert.ToString(registros.Rows[0]["ciu_nacimiento"].ToString());

        tb_DocenteId.ReadOnly = usua.B_Botones1;
        tb_DocenteNombre.ReadOnly = usua.L_Aceptar1;
        tb_DocenteNombre.Text = usua.Nombre;
        tb_DocenteApellido.ReadOnly = usua.L_Aceptar1;
        tb_DocenteApellido.Text = usua.Apellido;
        tb_DocenteCorreo.ReadOnly = usua.L_Aceptar1;
        tb_DocenteCorreo.Text = usua.Correo;
        tb_DocenteDireccion.ReadOnly = usua.L_Aceptar1;
        tb_DocenteDireccion.Text = usua.Direccion;
        tb_DocenteTelefono.ReadOnly = usua.L_Aceptar1;
        tb_DocenteTelefono.Text = usua.Telefono;
        tb_DocenteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_DocenteUsuario.Text = usua.UserName;
        tb_DocenteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_DocenteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        L_ErrorAdmin.Text = "";

        btn_DocenteEditar.Visible = usua.B_Botones1;
        btn_DocenteNuevo.Visible = usua.B_Botones1;
        btn_DocenteAceptar.Visible = usua.L_Aceptar1;
        //}    
        //else
        //{
        L_ErrorAdmin.Text = usua.Mensaje;
        //}

    }





    protected void btn_DocenteEditar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();


        usua = logica.editarAdmin(
            tb_DocenteNombre.Text,
            tb_DocenteUsuario.Text,
            tb_DocenteContrasenia.Text,
            tb_DocenteCorreo.Text,
            tb_DocenteApellido.Text,
            tb_DocenteDireccion.Text,
            tb_DocenteTelefono.Text,
            int.Parse(tb_DocenteId.Text),
            DDL_Estado.SelectedValue,
            fechanac.Text,
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            Session.SessionID,
            FileUpload1,
            Session["fotosinedit"].ToString()
            );

        this.Page.Response.Write(usua.Notificacion);

        tb_DocenteId.ReadOnly = usua.BotonTrue;
        tb_DocenteNombre.ReadOnly = usua.BotonFalse;
        tb_DocenteApellido.ReadOnly = usua.BotonFalse;
        tb_DocenteCorreo.ReadOnly = usua.BotonFalse;
        tb_DocenteDireccion.ReadOnly = usua.BotonFalse;
        tb_DocenteTelefono.ReadOnly = usua.BotonFalse;
        tb_DocenteUsuario.ReadOnly = usua.BotonFalse;
        tb_DocenteContrasenia.ReadOnly = usua.BotonFalse;
        btn_DocenteEditar.Visible = usua.BotonFalse;
        btn_DocenteNuevo.Visible = usua.BotonTrue;
        btn_DocenteAceptar.Visible = usua.BotonFalse;

    }

    protected void btn_DocenteNuevo_Click(object sender, EventArgs e)
    {

        tb_DocenteId.Enabled = true;
        tb_DocenteNombre.Text = "";
        tb_DocenteUsuario.Text = "";
        tb_DocenteContrasenia.Text = "";
        tb_DocenteCorreo.Text = "";
        tb_DocenteApellido.Text = "";
        tb_DocenteDireccion.Text = "";
        tb_DocenteTelefono.Text = "";
        tb_DocenteId.Text = "";
        L_ErrorAdmin.Text = "";
        L_Error.Text = "";
        fechanac.Text = "";

        ImagenEst.ImageUrl = "";
        tb_DocenteNombre.ReadOnly = true;
        tb_DocenteApellido.ReadOnly = true;
        tb_DocenteCorreo.ReadOnly = true;
        tb_DocenteDireccion.ReadOnly = true;
        tb_DocenteTelefono.ReadOnly = true;
        tb_DocenteUsuario.ReadOnly = true;
        tb_DocenteContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_DocenteId.ReadOnly = false;

        tb_DocenteId.Focus();
        btn_DocenteEditar.Visible = false;
        btn_DocenteNuevo.Visible = false;
        btn_DocenteAceptar.Visible = true;

    }


    protected String cargarImagen()
    {


        string sDia = Convert.ToString(DateTime.Now.Day);
        string sMes = Convert.ToString(DateTime.Now.Month);
        string sAgno = Convert.ToString(DateTime.Now.Year);
        string sHora = Convert.ToString(DateTime.Now.Hour);
        string sMinu = Convert.ToString(DateTime.Now.Minute);
        string sSeco = Convert.ToString(DateTime.Now.Second);
        string sFecha = sDia + sMes + sAgno + sHora + sMinu + sSeco;




        ClientScriptManager cm = this.ClientScript;
        String nombreArchivo = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        String saveLocation = "";

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");



            return null;
        }

        saveLocation = Server.MapPath("~/FotosUser") + "/" + sFecha + sMinu + nombreArchivo;

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return null;
        }

        FileUpload1.PostedFile.SaveAs(saveLocation);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
    }



}