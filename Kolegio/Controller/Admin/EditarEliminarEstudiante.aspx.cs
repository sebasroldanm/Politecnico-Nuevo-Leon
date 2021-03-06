﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarEstudiante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documento"].ToString());
            tb_EstudianteId.Text = (string)Session["documento"];
            tb_EstudianteNombre.ReadOnly = usua.BotonTrue;
            tb_EstudianteApellido.ReadOnly = usua.BotonTrue;
            tb_EstudianteCorreo.ReadOnly = usua.BotonTrue;
            tb_EstudianteDireccion.ReadOnly = usua.BotonTrue;
            tb_EstudianteTelefono.ReadOnly = usua.BotonTrue;
            tb_EstudianteUsuario.ReadOnly = usua.BotonTrue;
            tb_EstudianteContrasenia.ReadOnly = usua.BotonTrue;
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



        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 17;
        //<asp:Label ID="" runat="server"></asp:Label>

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        //[L_AdminEditEstuTitulo] ???????????????????????????????????????????????
        L_AdminEditEstuId.Text = encId.CompIdioma["L_AdminEditEstuId"].ToString();
        tb_EstudianteId.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteId"].ToString());
        REV_EstudianteId.ErrorMessage = encId.CompIdioma["REV_EstudianteId"].ToString();
        L_AdminEditEstuNombre.Text = encId.CompIdioma["L_AdminEditEstuNombre"].ToString();
        tb_EstudianteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteNombre"].ToString());
        REV_EstudianteNombre.ErrorMessage = encId.CompIdioma["REV_EstudianteNombre"].ToString();
        L_AdminEditEstuApellido.Text = encId.CompIdioma["L_AdminEditEstuApellido"].ToString();
        tb_EstudianteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteApellido"].ToString());
        REV_EstudianteApellido.ErrorMessage = encId.CompIdioma["REV_EstudianteApellido"].ToString();
        L_AdminEditEstuDep.Text = encId.CompIdioma["L_AdminEditEstuDep"].ToString();
        L_AdminEditEstuFoto.Text = encId.CompIdioma["L_AdminEditEstuFoto"].ToString();
        L_AdminEditEstuFechanac.Text = encId.CompIdioma["L_AdminEditEstuFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminEditEstuCorreo.Text = encId.CompIdioma["L_AdminEditEstuCorreo"].ToString();
        tb_EstudianteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteCorreo"].ToString());
        REV_EstudianteCorreo.ErrorMessage = encId.CompIdioma["REV_EstudianteCorreo"].ToString();
        L_ADminEditEstuDir.Text = encId.CompIdioma["L_ADminEditEstuDir"].ToString();
        tb_EstudianteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteDireccion"].ToString());
        REV_EstudianteDireccion.ErrorMessage = encId.CompIdioma["REV_EstudianteDireccion"].ToString();
        L_AdminEditEstuTel.Text = encId.CompIdioma["L_AdminEditEstuTel"].ToString();
        tb_EstudianteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteTelefono"].ToString());
        REV_EstudianteTelefono.ErrorMessage = encId.CompIdioma["REV_EstudianteTelefono"].ToString();
        L_AdminEditEstuUser.Text = encId.CompIdioma["L_AdminEditEstuUser"].ToString();
        tb_EstudianteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteUsuario"].ToString());
        REV_EstudianteUsuario.ErrorMessage = encId.CompIdioma["REV_EstudianteUsuario"].ToString();
        L_AdminEditEstuContra.Text = encId.CompIdioma["L_AdminEditEstuContra"].ToString();
        tb_EstudianteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_EstudianteContrasenia"].ToString());
        REV_EstudianteContrasenia.ErrorMessage = encId.CompIdioma["REV_EstudianteContrasenia"].ToString();
        L_AdminEditEstuEstado.Text = encId.CompIdioma["L_AdminEditEstuEstado"].ToString();
        btn_EstudianteAceptar.Text = encId.CompIdioma["btn_EstudianteAceptar"].ToString();
        btn_EstudianteEditar.Text = encId.CompIdioma["btn_EstudianteEditar"].ToString();
        btn_EstudianteNuevo.Text = encId.CompIdioma["btn_EstudianteNuevo"].ToString();

        //editarBuscarUser
        //L_ErrorAdmin.Text_sin_registro = "Sin Registros";


        //editarAdmin
        //L_ErrorAdmin.Text_sin_selecionar = "Debe seleccionar una opcion";
        //script_foto = "Usuario Editado con Exito";
        //script_foto_null Usuario = "Editado con Exito";


        //cargarFoto
        //script_error_formato="Solo se admiten imagenes en formato Jpeg o Gif";
        //script_error_foto_repite="Ya existe una imagen en el servidor con ese nombre";
        //script_foto_cargada="El archivo de imagen ha sido cargado;

        if (IsPostBack == false)
        {
            DDL_Estado.Items.Clear();
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado"].ToString());
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado2"].ToString());
        }
        //DDL_Estado
        //item1="Activo";
        //item2="Inactivo";


        
        

    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       
    }

    protected void tb_AministradorEstudiantefechanac_TextChanged(object sender, EventArgs e)
    {
       
    }

    protected void btn_AdministradorAceptar_Click(object sender, EventArgs e)
    {

        LMUser logica = new LMUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_EstudianteId.Text), int.Parse(Session["idioma"].ToString()));


        tb_EstudianteId.ReadOnly = usua.B_Botones1;
        tb_EstudianteNombre.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteNombre.Text = usua.Nombre;
        tb_EstudianteApellido.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteApellido.Text = usua.Apellido;
        tb_EstudianteCorreo.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteCorreo.Text = usua.Correo;
        tb_EstudianteDireccion.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteDireccion.Text = usua.Direccion;
        tb_EstudianteTelefono.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteTelefono.Text = usua.Telefono;
        tb_EstudianteUsuario.ReadOnly = true;
        tb_EstudianteUsuario.Text = usua.UserName;
        tb_EstudianteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        DDL_Estado.SelectedValue = usua.Estado;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        Session["fotosinedit"] = usua.Foto;
        L_ErrorEstudiante.Text = "";

        btn_EstudianteEditar.Visible = usua.B_Botones1;
        btn_EstudianteNuevo.Visible = usua.B_Botones1;
        btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        L_ErrorEstudiante.Text = usua.Mensaje;
    }

    protected void btn_AdministradorEdditar_Click(object sender, EventArgs e)
    {

        //    LUser logica = new LUser();
        //    UUser usua = new UUser();
        //    string foto = cargarImagen();
        //    int rol = 3;
        //    usua = logica.editarAdmin(
        //        tb_EstudianteNombre.Text,
        //        tb_EstudianteUsuario.Text,
        //        tb_EstudianteContrasenia.Text,
        //        tb_EstudianteCorreo.Text,
        //        tb_EstudianteApellido.Text,
        //        tb_EstudianteDireccion.Text,
        //        tb_EstudianteTelefono.Text,
        //        int.Parse(tb_EstudianteId.Text),
        //        DDL_Estado.SelectedValue,
        //        fechanac.Text,
        //        int.Parse(ddt_lugarnacimDep.SelectedValue),
        //        int.Parse(DDT_Ciudad.SelectedValue),
        //        Session.SessionID,
        //        foto,
        //        Session["fotosinedit"].ToString(),
        //        int.Parse(Session["idioma"].ToString()),
        //        rol
        //        );
        //this.Page.Response.Write(usua.Notificacion);



        //tb_EstudianteId.ReadOnly = usua.BotonTrue;
        //tb_EstudianteNombre.ReadOnly = usua.BotonFalse;
        //tb_EstudianteApellido.ReadOnly = usua.BotonFalse;
        //tb_EstudianteCorreo.ReadOnly = usua.BotonFalse;
        //tb_EstudianteDireccion.ReadOnly = usua.BotonFalse;
        //tb_EstudianteTelefono.ReadOnly = usua.BotonFalse;
        //tb_EstudianteUsuario.ReadOnly = usua.BotonFalse;
        //tb_EstudianteContrasenia.ReadOnly = usua.BotonFalse;
        //btn_EstudianteEditar.Visible = usua.BotonFalse;
        //btn_EstudianteNuevo.Visible = usua.BotonTrue;
        //btn_EstudianteAceptar.Visible = usua.BotonFalse;


        LMUser logica = new LMUser();
        Usuario user = new Usuario();
        UUser usu = new UUser();

        user.num_documento = int.Parse(tb_EstudianteId.Text);
        user.nombre_usua = tb_EstudianteNombre.Text;
        user.clave = tb_EstudianteContrasenia.Text;
        user.correo = tb_EstudianteCorreo.Text;
        user.apellido_usua = tb_EstudianteApellido.Text;
        user.direccion = tb_EstudianteDireccion.Text;
        user.telefono = tb_EstudianteTelefono.Text;
        user.foto_usua = cargarImagen();
        user.fecha_nac = fechanac.Text;
        user.dep_nacimiento = int.Parse(ddt_lugarnacimDep.SelectedValue.ToString());
        user.ciu_nacimiento = int.Parse(DDT_Ciudad.SelectedValue.ToString());
        user.sesion = Session.SessionID;
        user.rol_id = 3;
        user.user_name = tb_EstudianteUsuario.Text;




        usu = logica.editarEstudiante(user, int.Parse(Session["idioma"].ToString()), DDL_Estado.SelectedValue, Session["fotosinedit"].ToString());

        this.Page.Response.Write(usu.Notificacion);

        tb_EstudianteId.ReadOnly = usu.BotonTrue;
        tb_EstudianteNombre.ReadOnly = usu.BotonFalse;
        tb_EstudianteApellido.ReadOnly = usu.BotonFalse;
        tb_EstudianteCorreo.ReadOnly = usu.BotonFalse;
        tb_EstudianteDireccion.ReadOnly = usu.BotonFalse;
        tb_EstudianteTelefono.ReadOnly = usu.BotonFalse;
        tb_EstudianteUsuario.ReadOnly = usu.BotonFalse;
        tb_EstudianteContrasenia.ReadOnly = usu.BotonFalse;
        btn_EstudianteEditar.Visible = usu.BotonFalse;
        btn_EstudianteNuevo.Visible = usu.BotonTrue;
        btn_EstudianteAceptar.Visible = usu.BotonFalse;




    }
            
      

    protected void btn_AdministradorNuevo_Click(object sender, EventArgs e)
    {
        tb_EstudianteId.Enabled = true;
        tb_EstudianteNombre.Text = "";
        tb_EstudianteUsuario.Text = "";
        tb_EstudianteContrasenia.Text = "";
        tb_EstudianteCorreo.Text = "";
        tb_EstudianteApellido.Text = "";
        tb_EstudianteDireccion.Text = "";
        tb_EstudianteTelefono.Text = "";
        tb_EstudianteId.Text = "";
        L_Error.Text = "";
        L_Error.Text = "";
        fechanac.Text = "";
        ImagenEst.ImageUrl = "";

        tb_EstudianteNombre.ReadOnly = true;
        tb_EstudianteApellido.ReadOnly = true;
        tb_EstudianteCorreo.ReadOnly = true;
        tb_EstudianteDireccion.ReadOnly = true;
        tb_EstudianteTelefono.ReadOnly = true;
        tb_EstudianteUsuario.ReadOnly = true;
        tb_EstudianteContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_EstudianteId.ReadOnly = false;

        tb_EstudianteId.Focus();
        btn_EstudianteEditar.Visible = false;
        btn_EstudianteNuevo.Visible = false;
        btn_EstudianteAceptar.Visible = true;

    }

    protected string cargarImagen()
    {
        LMUser logic = new LMUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName), System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName), FileUpload1.ToString(), Server.MapPath("~/FotosUser"), int.Parse(Session["idioma"].ToString()));
        try
        {
            ClientScriptManager cm = this.ClientScript;
            //cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);
            btnigm_calendar.Visible = true;

            FileUpload1.PostedFile.SaveAs(enc.SaveLocation);
            return enc.FotoCargada;
        }
        catch
        {
            return null;
        }
    }
}
