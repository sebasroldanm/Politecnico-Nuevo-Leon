using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarAcudiente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 15;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminEditAcuTitulo.Text = encId.CompIdioma["L_AdminEditAcuTitulo"].ToString();
        L_AdminEditAcuDocumento.Text = encId.CompIdioma["L_AdminEditAcuDocumento"].ToString();
        tb_AcudienteId.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteId"].ToString());
        REV_AcudienteId.ErrorMessage = encId.CompIdioma["REV_AcudienteId"].ToString();
        L_AdminEditAcuNombre.Text = encId.CompIdioma["L_AdminEditAcuNombre"].ToString();
        tb_AcudienteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteNombre"].ToString());
        REV_AcudienteNombre.ErrorMessage = encId.CompIdioma["REV_AcudienteNombre"].ToString();
        L_AdminEditAcuApellido.Text = encId.CompIdioma["L_AdminEditAcuApellido"].ToString();
        tb_AcudienteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteApellido"].ToString());
        REV_AcudienteApellido.ErrorMessage = encId.CompIdioma["REV_AcudienteApellido"].ToString();
        L_AdminEditAcuDep.Text = encId.CompIdioma["L_AdminEditAcuDep"].ToString();
        L_AdminEditAcuFoto.Text = encId.CompIdioma["L_AdminEditAcuFoto"].ToString();
        L_AdminEditAcuFechanac.Text = encId.CompIdioma["L_AdminEditAcuFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminEditAcuCorreo.Text = encId.CompIdioma["L_AdminEditAcuCorreo"].ToString();
        tb_AcudienteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteCorreo"].ToString());
        REV_AcudienteCorreo.ErrorMessage = encId.CompIdioma["REV_AcudienteCorreo"].ToString();
        L_ADminEditAcuDir.Text = encId.CompIdioma["L_ADminEditAcuDir"].ToString();
        tb_AcudienteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteDireccion"].ToString());
        REV_AcudienteDireccion.ErrorMessage = encId.CompIdioma["REV_AcudienteDireccion"].ToString();
        L_AdminEditAcuTel.Text = encId.CompIdioma["L_AdminEditAcuTel"].ToString();
        tb_AcudienteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteTelefono"].ToString());
        REV_AcudienteTelefono.ErrorMessage = encId.CompIdioma["REV_AcudienteTelefono"].ToString();
        L_AdminEditAcuUser.Text = encId.CompIdioma["L_AdminEditAcuUser"].ToString();
        tb_AcudienteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteUsuario"].ToString());
        REV_AcudienteUsuario.ErrorMessage = encId.CompIdioma["REV_AcudienteUsuario"].ToString();
        L_AdminEditAcuContra.Text = encId.CompIdioma["L_AdminEditAcuContra"].ToString();
        tb_AcudienteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_AcudienteContrasenia"].ToString());
        REV_AcudienteContrasenia.ErrorMessage = encId.CompIdioma["REV_AcudienteContrasenia"].ToString();
        L_AdminEditAcuEstado.Text = encId.CompIdioma["L_AdminEditAcuEstado"].ToString();

        btn_AcudienteAceptar.Text = encId.CompIdioma["btn_AcudienteAceptar"].ToString();
        btn_AcudienteEditar.Text = encId.CompIdioma["btn_AcudienteEditar"].ToString();
        btn_AcudienteNuevo.Text = encId.CompIdioma["btn_AcudienteNuevo"].ToString();


        //editarBuscarUser
        //L_Error.Text_sin_registro = "Sin Registros";


        //editarAdmin
        //L_ErrorAdmin.Text_sin_selecionar = "Debe seleccionar una opcion";
        //script_foto = "Usuario Editado con Exito";
        //script_foto_null Usuario = "Insertado con Exito";


        //cargarFoto
        //script_error_formato="Solo se admiten imagenes en formato Jpeg o Gif";
        //script_error_foto_repite="Ya existe una imagen en el servidor con ese nombre";
        //script_foto_cargada="El archivo de imagen ha sido cargado";
        DDL_Estado.Items.Clear();
        DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado"].ToString());
        DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado2"].ToString());

        //DDL_Estado
        //item1="Activo";
        //item2="Inactivo";

        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
    
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documento"].ToString());
            tb_AcudienteId.Text = Session["documento"].ToString();
            tb_AcudienteNombre.ReadOnly = usua.BotonTrue;
            tb_AcudienteApellido.ReadOnly = usua.BotonTrue;
            tb_AcudienteCorreo.ReadOnly = usua.BotonTrue;
            tb_AcudienteDireccion.ReadOnly = usua.BotonTrue;
            tb_AcudienteTelefono.ReadOnly = usua.BotonTrue;
            tb_AcudienteUsuario.ReadOnly = usua.BotonTrue;
            tb_AcudienteContrasenia.ReadOnly = usua.BotonTrue;
        }
        catch
        {
            try
            {
                usua.SUserId = Session["userId"].ToString();
            }
            catch
            {
                Response.Redirect("~/View/Admin/AccesoDenegado.aspx");
            }
        }
    }

    protected void btn_AdministradorEstudianteEditar_Click(object sender, EventArgs e)
    {

    }

    protected void btn_AcudienteAceptar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();
        

        usua = logica.editarBuscarUser(int.Parse(tb_AcudienteId.Text), int.Parse(Session["idioma"].ToString()));

        tb_AcudienteId.ReadOnly = usua.B_Botones1;
        tb_AcudienteNombre.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteNombre.Text = usua.Nombre;
        tb_AcudienteApellido.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteApellido.Text = usua.Apellido;
        tb_AcudienteCorreo.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteCorreo.Text = usua.Correo;
        tb_AcudienteDireccion.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteDireccion.Text = usua.Direccion;
        tb_AcudienteTelefono.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteTelefono.Text = usua.Telefono;
        tb_AcudienteUsuario.ReadOnly = true;
        tb_AcudienteUsuario.Text = usua.UserName;
        tb_AcudienteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        DDL_Estado.SelectedValue = usua.Estado;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        Session["fotosinedit"] = usua.Foto;

        L_ErrorAdmin.Text = "";

        btn_AcudienteEditar.Visible = usua.B_Botones1;
        btn_AcudienteNuevo.Visible = usua.B_Botones1;
        btn_AcudienteAceptar.Visible = usua.L_Aceptar1;
        L_ErrorAdmin.Text = usua.Mensaje;
    }

    protected void btn_AcudienteEditar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();
        string foto = cargarImagen();
        usua = logica.editarAdmin(
            tb_AcudienteNombre.Text,
            tb_AcudienteUsuario.Text,
            tb_AcudienteContrasenia.Text,
            tb_AcudienteCorreo.Text,
            tb_AcudienteApellido.Text,
            tb_AcudienteDireccion.Text,
            tb_AcudienteTelefono.Text,
            int.Parse(tb_AcudienteId.Text),
            DDL_Estado.SelectedValue,
            fechanac.Text,
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            Session.SessionID,
            foto,
            Session["fotosinedit"].ToString(),
            int.Parse(Session["idioma"].ToString())
            );

        this.Page.Response.Write(usua.Notificacion);

        tb_AcudienteId.ReadOnly = usua.BotonTrue;
        tb_AcudienteNombre.ReadOnly = usua.BotonFalse;
        tb_AcudienteApellido.ReadOnly = usua.BotonFalse;
        tb_AcudienteCorreo.ReadOnly = usua.BotonFalse;
        tb_AcudienteDireccion.ReadOnly = usua.BotonFalse;
        tb_AcudienteTelefono.ReadOnly = usua.BotonFalse;
        tb_AcudienteUsuario.ReadOnly = usua.BotonFalse;
        tb_AcudienteContrasenia.ReadOnly = usua.BotonFalse;
        btn_AcudienteEditar.Visible = usua.BotonFalse;
        btn_AcudienteNuevo.Visible = usua.BotonTrue;
        btn_AcudienteAceptar.Visible = usua.BotonFalse;
    }

    protected void btn_AcudienteNuevo_Click(object sender, EventArgs e)
    {
        tb_AcudienteId.Enabled = true;
        tb_AcudienteNombre.Text = "";
        tb_AcudienteUsuario.Text = "";
        tb_AcudienteContrasenia.Text = "";
        tb_AcudienteCorreo.Text = "";
        tb_AcudienteApellido.Text = "";
        tb_AcudienteDireccion.Text = "";
        tb_AcudienteTelefono.Text = "";
        tb_AcudienteId.Text = "";
        fechanac.Text = "";
        L_ErrorAdmin.Text = "";
        ImagenEst.ImageUrl = "";

        tb_AcudienteNombre.ReadOnly = true;
        tb_AcudienteApellido.ReadOnly = true;
        tb_AcudienteCorreo.ReadOnly = true;
        tb_AcudienteDireccion.ReadOnly = true;
        tb_AcudienteTelefono.ReadOnly = true;
        tb_AcudienteUsuario.ReadOnly = true;
        tb_AcudienteContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_AcudienteId.ReadOnly = false;

        tb_AcudienteId.Focus();
        btn_AcudienteEditar.Visible = false;
        btn_AcudienteNuevo.Visible = false;
        btn_AcudienteAceptar.Visible = true;

    }
    protected string cargarImagen()
    {
        LUser logic = new LUser();
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