using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;



public partial class View_Admin_AgregarAdministrador : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Agregar Administrador";
        L_AdminAgreAdminTitulo.Text = "Agregar Administrador";

        L_AdminAgreAdminDocumento.Text = "Número de Documento :";
        tb_AministradorAdministradorId.Attributes.Add("placeholder", "Número de Documento");
        REV_AministradorAdministradorId.ErrorMessage = "Digitar solo números";
        L_AdminAgreAdminNombre.Text = "Nombres :";
        tb_AdministradorAdministradorNombre.Attributes.Add("placeholder", "Nombres   Administrador");
        REV_AdministradorAdministradorNombre.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAdminApellido.Text = "Apellido :";
        tb_AdministradorAdministradorApellido.Attributes.Add("placeholder", "Apellidos Administrador ");
        REV_AdministradorAdministradorApellido.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAdminDep.Text = "Lugar Nacimiento.:";
        L_AdminAgreAdminFoto.Text = "Foto :";
        L_AdminAgreAdminFechanac.Text = "Fecha Nacimiento:";
        fechanac.Attributes.Add("placeholder", "Fecha de Nacimiento");
        L_AdminAgreAdminCorreo.Text = "Correo :";
        tb_AdministradorAdministradorCorreo.Attributes.Add("placeholder", "Email");
        REV_AdministradorAdministradorCorreo.ErrorMessage = "No se aceptan caracteres especiales";
        L_ADminAgreAdminDir.Text = "Direccion :";
        tb_AdministradorAdministradorDireccion.Attributes.Add("placeholder", "Dirección");
        REV_AdministradorAdministradorDireccion.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAdminTel.Text = "Telefono :";
        tb_AdministradorTelefono.Attributes.Add("placeholder", "Teléfono");
        REV_AdministradorTelefono.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAdminUser.Text = "Usuario :";
        tb_AdministradorUsuario.Attributes.Add("placeholder", "Usuario");
        REV_AdministradorUsuario.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAdminContra.Text = "Contraseña:";
        tb_AdministradorContrasenia.Attributes.Add(" placeholder", "Contraseña");
        REV_AdministradorContrasenia.ErrorMessage = "No se aceptan caracteres especiales";
        btn_validar.Text = "Validar Usuario";

        //L_ErrorUsuario.Text;   
        btn_AdministradorAceptar.Text = "Agregar";
        btn_EstudianteNuevo.Text = "Nuevo";

        L_ErrorUsuario.Text = "Debe seleccionar una opcion";
        // script Usuario Insertado con Exito //Error al Seleccionar la Foto

        //
        L_ErrorUsuario.Text = "El Usuario ya existe";
        L_ErrorUsuario.Text = "Usuario Disponible";


        Response.Cache.SetNoStore();
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        UUser usua = new UUser();
        LLogin Logica = new LLogin();
        Response.Cache.SetNoStore();
        try
        {
            usua = Logica.logAgregarAdmin(Session["userId"].ToString());
            //btnigm_calendar.Visible = false;

            CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + int.Parse(usua.Año));
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

            ///Response.Redirect("~/View/Inicio/MantenimientoPagina.aspx");
        }
        

    }

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {

        LUser Logica = new LUser();
        UUser usua = new UUser();
        string foto = cargarImagen();

        usua = Logica.AgregarAdmin(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_AdministradorAdministradorNombre.Text,
            tb_AdministradorAdministradorApellido.Text,
            tb_AdministradorAdministradorDireccion.Text,
            tb_AdministradorTelefono.Text,
            tb_AdministradorContrasenia.Text,
            tb_AdministradorAdministradorCorreo.Text,
            foto,
            int.Parse(tb_AministradorAdministradorId.Text),
            tb_AdministradorUsuario.Text,
            1,
            fechanac.Text,
            Session.SessionID);
        L_ErrorUsuario.Text = usua.Mensaje;
        this.Page.Response.Write(usua.Notificacion);
        btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        btn_EstudianteNuevo.Visible = usua.B_Botones1;

        
    }

    protected void btn_AdministradorNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/View/Admin/AgregarAdministrador.aspx");
        fechanac.Text = "";
        tb_AdministradorAdministradorNombre.Text = "";
        tb_AdministradorUsuario.Text = "";
        tb_AdministradorContrasenia.Text = "";
        tb_AdministradorAdministradorCorreo.Text = "";
        tb_AdministradorAdministradorApellido.Text = "";
        tb_AdministradorAdministradorDireccion.Text = "";
        tb_AdministradorTelefono.Text = "";
        tb_AministradorAdministradorId.Text = "";
        tb_AministradorAdministradorId.Focus();
        btn_EstudianteNuevo.Visible = false;
        btn_validar.Visible = true;
        L_ErrorUsuario.Text = "";     
        tb_AdministradorUsuario.ReadOnly = false;
        tb_AministradorAdministradorId.ReadOnly = false;
        L_ErrorUsuario.Text = "";
        L_OkUsuario.Text = "";
        btnigm_calendar.Visible = false;

    }



    protected void btn_validar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.validarUser(tb_AdministradorUsuario.Text, tb_AministradorAdministradorId.Text);
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        tb_AministradorAdministradorId.Visible = usua.L_Aceptar1;
        tb_AdministradorUsuario.ReadOnly = usua.L_Aceptar1;
        tb_AministradorAdministradorId.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;

    }

    protected string cargarImagen()
    {
        LUser logic = new LUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_AdministradorFoto.PostedFile.FileName), System.IO.Path.GetExtension(tb_AdministradorFoto.PostedFile.FileName), tb_AdministradorFoto.ToString(), Server.MapPath("~/FotosUser"));
        try
        {
            ClientScriptManager cm = this.ClientScript;
            cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);
            btnigm_calendar.Visible = true;

            tb_AdministradorFoto.PostedFile.SaveAs(enc.SaveLocation);
            return enc.FotoCargada;
        }
        catch
        {
            return null;
        }
    }




    protected void btnigm_calendar_Click(object sender, ImageClickEventArgs e)
    {

    }
}