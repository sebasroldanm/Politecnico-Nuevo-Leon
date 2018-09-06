﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarProfesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin Logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = Logica.logAgregarAdmin(Session["userId"].ToString());
            Response.Redirect(usua.Url);
            CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + usua.RolId);
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

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.AgregarAdmin(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_DocenteNombre.Text,
            tb_DocenteApellido.Text,
            tb_DocenteDireccion.Text,
            tb_DocenteTelefono.Text,
            tb_DocenteContrasenia.Text,
            tb_DocenteCorreo.Text,
            tb_Foto,
            int.Parse(tb_DocenteId.Text),
            tb_DocenteUsuario.Text,
            2,
            fechanac.Text,
            Session.SessionID
            );

        L_ErrorUsuario.Text = usua.Mensaje;
        btn_DocenteAceptar.Visible = false;
        this.Page.Response.Write(usua.Notificacion);

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();
        //int rol = 2;

        //int dep;
        //dep = int.Parse(ddt_lugarnacimDep.SelectedValue);

        //int ciu;
        //ciu = int.Parse(DDT_Ciudad.SelectedValue);

        //if (ddt_lugarnacimDep.SelectedValue == "0" || DDT_Ciudad.SelectedValue == "0")
        //{
        //    L_ErrorUsuario.Text = "Debe seleccionar una opcion";
        //}
        //else
        //{
        //    usua.Nombre = tb_DocenteNombre.Text;
        //    usua.Rol = Convert.ToString(rol);
        //    usua.UserName = tb_DocenteUsuario.Text;
        //    usua.Clave = tb_DocenteContrasenia.Text;
        //    usua.Correo = tb_DocenteCorreo.Text;
        //    usua.Apellido = tb_DocenteApellido.Text;
        //    usua.Direccion = tb_DocenteDireccion.Text;
        //    usua.Telefono = tb_DocenteTelefono.Text;
        //    usua.Documento = tb_DocenteId.Text;

        //    usua.fecha_nacimiento = fechanac.Text;
        //    usua.Departamento = Convert.ToString(dep);
        //    usua.Ciudad = Convert.ToString(ciu);
        //    usua.Foto = cargarImagen();
        //    usua.Session = Session.SessionID;

        //    if (usua.Foto != null)
        //    {
        //        dat.insertarUsuarios(usua);
        //        this.Page.Response.Write("<script language='JavaScript'>window.alert('Docente Insertado con Exito');</script>");

        //      btn_DocenteAceptar.Visible = false;
        //    }

        //    tb_DocenteId.ReadOnly = true;
        //    tb_DocenteNombre.ReadOnly = true;
        //    tb_DocenteApellido.ReadOnly = true;
        //    tb_DocenteCorreo.ReadOnly = true;
        //    tb_DocenteTelefono.ReadOnly = true;
        //    tb_DocenteContrasenia.ReadOnly = true;
        //    tb_DocenteDireccion.ReadOnly = true;
        //    fechanac.ReadOnly = true;
        //    tb_DocenteUsuario.ReadOnly = true;
        //}



    }

    protected void btn_AdministradorNuevo_Click(object sender, EventArgs e)
    {


        Response.Redirect("/View/Admin/AgregarProfesor.aspx");
        fechanac.Text = "";
        tb_DocenteNombre.Text = "";
        tb_DocenteUsuario.Text = "";
        tb_DocenteContrasenia.Text = "";
        tb_DocenteCorreo.Text = "";
        tb_DocenteApellido.Text = "";
        tb_DocenteDireccion.Text = "";
        tb_DocenteTelefono.Text = "";
        tb_DocenteId.Text = "";
        tb_DocenteId.Focus();
        tb_DocenteId.ReadOnly = false;
        tb_DocenteNombre.ReadOnly = false;
        tb_DocenteApellido.ReadOnly = false;
        tb_DocenteCorreo.ReadOnly = false;
        tb_DocenteTelefono.ReadOnly = false;
        tb_DocenteContrasenia.ReadOnly = false;
        tb_DocenteDireccion.ReadOnly = false;
        fechanac.ReadOnly = false;
        tb_DocenteUsuario.ReadOnly = false;
    }

    protected void btn_validar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.validarUser(tb_DocenteUsuario.Text, tb_DocenteId.Text);
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_DocenteAceptar.Visible = usua.L_Aceptar1;
        btn_DocenteNuevo.Visible = usua.L_Aceptar1;
        tb_DocenteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_DocenteId.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();


        //usua.UserName = tb_DocenteUsuario.Text;
        //usua.Documento = tb_DocenteId.Text;

        //DataTable registros = dat.validar_usuarioadmin(usua);

        //if (registros.Rows.Count > 0)
        //{

        //    tb_Vusuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //    tb_Vdocumento.Text = Convert.ToString(registros.Rows[0]["num_documento"].ToString());
        //    L_ErrorUsuario.Text = "El Usuario ya existe";

        //}
        //else
        //{
        //    L_ErrorUsuario.Text = "";
        //    L_OkUsuario.Text = "Usuario Disponible";
        //    btn_DocenteAceptar.Visible = true;
        //    btn_DocenteNuevo.Visible = true;
        //    btn_validar.Visible = false;
        //    tb_DocenteUsuario.ReadOnly = true;
        //    tb_DocenteId.ReadOnly = true;
        //}

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
        String nombreArchivo = System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(tb_Foto.PostedFile.FileName);
        String saveLocation = "";

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
            btnigm_calendar.Visible = true;


            return null;
        }

        saveLocation = Server.MapPath("~/FotosUser") + "/" + sFecha + sMinu + nombreArchivo;

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return null;
        }

        tb_Foto.PostedFile.SaveAs(saveLocation);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
    }





}