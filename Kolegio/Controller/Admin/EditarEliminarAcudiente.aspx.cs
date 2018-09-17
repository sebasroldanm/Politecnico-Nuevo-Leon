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
        Page.Title = "Ediar Acudiente";
        L_AdminEditAcuTitulo.Text = "Editar Acudiente";
        L_AdminEditAcuDocumento.Text = "Número de Documento :";
        tb_AcudienteId.Attributes.Add("placeholder", "Número de Documento");
        REV_AcudienteId.ErrorMessage = "Digitar solo números";
        L_AdminEditAcuNombre.Text = "Nombres :";
        tb_AcudienteNombre.Attributes.Add("placeholder", "Nombres   Acudiente");
        REV_AcudienteNombre.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuApellido.Text = "Apellido :";
        tb_AcudienteApellido.Attributes.Add("placeholder", "Apellidos Acudiente ");
        REV_AcudienteApellido.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuDep.Text = "Lugar Nacimiento.:";
        L_AdminEditAcuFoto.Text = "Foto :";
        L_AdminEditAcuFechanac.Text = "Fecha Nacimiento:";
        fechanac.Attributes.Add("placeholder", "Fecha de Nacimiento");
        L_AdminEditAcuCorreo.Text = "Correo :";
        tb_AcudienteCorreo.Attributes.Add("placeholder", "Email");
        REV_AcudienteCorreo.ErrorMessage = "No se aceptan caracteres especiales";
        L_ADminEditAcuDir.Text = "Direccion :";
        tb_AcudienteDireccion.Attributes.Add("placeholder", "Dirección");
        REV_AcudienteDireccion.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuTel.Text = "Telefono :";
        tb_AcudienteTelefono.Attributes.Add("placeholder", "Teléfono");
        REV_AcudienteTelefono.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuUser.Text = "Usuario :";
        tb_AcudienteUsuario.Attributes.Add("placeholder", "Usuario");
        REV_AcudienteUsuario.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuContra.Text = "Contraseña:";
        tb_AcudienteContrasenia.Attributes.Add(" placeholder", "Contraseña");
        REV_AcudienteContrasenia.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditAcuEstado.Text = "Estado :";

        btn_AcudienteAceptar.Text = "Aceptar";
        btn_AcudienteEditar.Text = "Editar";
        btn_AcudienteNuevo.Text = "Nuevo";

        L_Error.Text = "Sin Registros";
        // script Usuario Insertado con Exito
        // script Usuario Insertado con Exito
        
        L_Error.Text = "Debe seleccionar una opción";


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
        

        usua = logica.editarBuscarUser(int.Parse(tb_AcudienteId.Text));

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
            Session["fotosinedit"].ToString()
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
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName), System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName), FileUpload1.ToString(), Server.MapPath("~/FotosUser"));
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