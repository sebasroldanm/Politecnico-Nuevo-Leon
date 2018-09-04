﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarAcudiente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        try
        {
            LLogin Logica = new LLogin();
            UUser usua = new UUser();

            usua = Logica.logAgregarAdmin(Session["userId"].ToString());
            Response.Redirect(usua.Url);
            CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + usua.RolId);
        }
        catch
        {

        }


    }

  


    protected void btn_AcudienteAceptar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.AgregarAdmin(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_AcudienteNombre.Text,
            tb_AcudienteApellido.Text,
            tb_AcudienteDireccion.Text,
            tb_AcudienteTelefono.Text,
            tb_AcudienteContrasenia.Text,
            tb_AcudienteCorreo.Text,
            tb_Foto,
            int.Parse(tb_AcudienteId.Text),
            tb_AcudienteUsuario.Text,
            4,
            fechanac.Text,
            Session.SessionID
            );

        L_ErrorUsuario.Text = usua.Mensaje;
        btn_AcudienteAceptar.Visible = false;
        this.Page.Response.Write(usua.Notificacion);

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();
        //int rol = 4;

        //int dep;
        //dep = int.Parse(ddt_lugarnacimDep.SelectedValue);

        //int ciu;
        //ciu = int.Parse(DDT_Ciudad.SelectedValue);

        //if(ddt_lugarnacimDep.SelectedValue == "0" || DDT_Ciudad.SelectedValue == "0")
        //{
        //    L_ErrorUsuario.Text = "Debe seleccionar una opcion";
        //}
        //else
        //{ 
        //    String acu = usua.Id_estudiante;

        //    usua.Nombre = tb_AcudienteNombre.Text;
        //    usua.Rol = Convert.ToString(rol);
        //    usua.UserName = tb_AcudienteUsuario.Text;
        //    usua.Clave = tb_AcudienteContrasenia.Text;
        //    usua.Correo = tb_AcudienteCorreo.Text;
        //    usua.Apellido = tb_AcudienteApellido.Text;
        //    usua.Direccion = tb_AcudienteDireccion.Text;
        //    usua.Telefono = tb_AcudienteTelefono.Text;
        //    usua.Documento = tb_AcudienteId.Text;
        //    usua.fecha_nacimiento = fechanac.Text;
        //    usua.Departamento = Convert.ToString(dep);
        //    usua.Ciudad = Convert.ToString(ciu);
        //    usua.Foto = cargarImagen();
        //    usua.Session = Session.SessionID;

        //    if (usua.Foto != null)
        //    {
        //        dat.insertarUsuarios(usua);
        //        this.Page.Response.Write("<script language='JavaScript'>window.alert('Acudiente Insertado con Exito');</script>");

        //        btn_AcudienteAceptar.Visible = false;
        //    }
        //}
    }

    protected void btn_AcudienteNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Admin/AgregarAcudiente.aspx");

        fechanac.Text = "";
        tb_AcudienteNombre.Text = "";
        tb_AcudienteUsuario.Text = "";
        tb_AcudienteContrasenia.Text = "";
        tb_AcudienteCorreo.Text = "";
        tb_AcudienteApellido.Text = "";
        tb_AcudienteDireccion.Text = "";
        tb_AcudienteTelefono.Text = "";
        tb_AcudienteId.Text = "";
      
        tb_AcudienteId.ReadOnly = true;
        tb_AcudienteApellido.ReadOnly = true;
        tb_AcudienteNombre.ReadOnly = true;
        tb_AcudienteTelefono.ReadOnly = true;
        tb_AcudienteUsuario.ReadOnly = true;
        tb_AcudienteDireccion.ReadOnly = true;
        tb_AcudienteContrasenia.ReadOnly = true;
        tb_AcudienteCorreo.ReadOnly = true;
 
    }

    protected void btn_validar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.validarUser(tb_AcudienteUsuario.Text, tb_AcudienteId.Text);
        L_ErrorUsuario.Text = usua.Mensaje;

        btn_AcudienteAceptar.Visible = usua.L_Aceptar1;
        btn_AcudienteNuevo.Visible = usua.L_Aceptar1;

        tb_AcudienteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();

        //usua.UserName = tb_AcudienteUsuario.Text;
        //usua.Documento = tb_AcudienteId.Text;

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
        //    btn_AcudienteAceptar.Visible = true;
        //    btn_AcudienteNuevo.Visible = true;
        //    btn_validar.Visible = false;
        //    tb_AcudienteId.ReadOnly = true;
        //    tb_AcudienteUsuario.ReadOnly = true;
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