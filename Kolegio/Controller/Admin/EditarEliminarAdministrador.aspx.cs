using System;
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
    protected void Page_Load(object sender, EventArgs e)  //  <asp:Label ID = "" runat="server"></asp:Label>
    {
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 16;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminEditAdminTitulo.Text = encId.CompIdioma["L_AdminEditAdminTitulo"].ToString();
        L_AdminEditAdminDocumento.Text = encId.CompIdioma["L_AdminEditAdminDocumento"].ToString();
        tb_AministradorAdministradorId.Attributes.Add("placeholder", encId.CompIdioma["tb_AministradorAdministradorId"].ToString());
        REV_AministradorAdministradorId.ErrorMessage = encId.CompIdioma["REV_AministradorAdministradorId"].ToString();
        L_AdminEditAdminNombre.Text = encId.CompIdioma["L_AdminEditAdminNombre"].ToString();
        tb_AdministradorAdministradorNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorNombre"].ToString());
        REV_AdministradorAdministradorNombre.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorNombre"].ToString();
        L_AdminEditAdminApellido.Text = encId.CompIdioma["L_AdminEditAdminApellido"].ToString();
        tb_AdministradorAdministradorApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorApellido"].ToString());
        REV_AdministradorAdministradorApellido.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorApellido"].ToString();
        L_AdminEditAdminDep.Text = encId.CompIdioma["L_AdminEditAdminDep"].ToString();
        L_AdminEditAdminFoto.Text = encId.CompIdioma["L_AdminEditAdminFoto"].ToString();
        L_AdminEditAdminFechanac.Text = encId.CompIdioma["L_AdminEditAdminFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminEditAdminCorreo.Text = encId.CompIdioma["L_AdminEditAdminCorreo"].ToString();
        tb_AdministradorAdministradorCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorCorreo"].ToString());
        REV_AdministradorAdministradorCorreo.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorCorreo"].ToString();
        L_ADminEditAdminDir.Text = encId.CompIdioma["L_ADminEditAdminDir"].ToString();
        tb_AdministradorAdministradorDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorDireccion"].ToString());
        REV_AdministradorAdministradorDireccion.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorDireccion"].ToString();
        L_AdminEditAdminTel.Text = encId.CompIdioma["L_AdminEditAdminTel"].ToString();
        tb_AdministradorTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorTelefono"].ToString());
        REV_AdministradorTelefono.ErrorMessage = encId.CompIdioma["REV_AdministradorTelefono"].ToString();
        L_AdminEditAdminUser.Text = encId.CompIdioma["L_AdminEditAdminUser"].ToString();
        tb_AdministradorUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorUsuario"].ToString());
        REV_AdministradorUsuario.ErrorMessage = encId.CompIdioma["REV_AdministradorUsuario"].ToString();
        L_AdminEditAdminContra.Text = encId.CompIdioma["L_AdminEditAdminContra"].ToString();
        tb_AdministradorContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_AdministradorContrasenia"].ToString());
        REV_AdministradorContrasenia.ErrorMessage = encId.CompIdioma["REV_AdministradorContrasenia"].ToString();
        L_AdminEditAdminEstado.Text = encId.CompIdioma["L_AdminEditAdminEstado"].ToString();
        btn_AdministradorAceptar.Text = encId.CompIdioma["btn_AdministradorAceptar"].ToString();
        btn_AdministradorEditar.Text = encId.CompIdioma["btn_AdministradorEditar"].ToString();
        btn_AdministradorNuevo.Text = encId.CompIdioma["btn_AdministradorNuevo"].ToString();

        //editarBuscarUser
        //L_ErrorAdmin.Text_sin_registro = "Sin Registros";


        //editarAdmin
        //L_ErrorAdmin.Text_sin_selecionar = "Debe seleccionar una opcion";
        //script_foto = "Usuario Editado con Exito";
        //script_foto_null Usuario = "Editado con Exito";


        //cargarFoto
        //script_error_formato="Solo se admiten imagenes en formato Jpeg o Gif";
        //script_error_foto_repite="Ya existe una imagen en el servidor con ese nombre";
        //script_foto_cargada="El archivo de imagen ha sido cargado";
        if (IsPostBack == false)
        {
            DDL_Estado.Items.Clear();
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado"].ToString());
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado2"].ToString());
        }
        //DDL_Estado
        //item1="Activo";
        //item2="Inactivo";


        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documento"].ToString());
            tb_AministradorAdministradorId.Text = Session["documento"].ToString();
            //tb_AdministradorAdministradorNombre.ReadOnly = usua.BotonTrue;
            //tb_AdministradorAdministradorApellido.ReadOnly = usua.BotonTrue;
            //tb_AdministradorAdministradorCorreo.ReadOnly = usua.BotonTrue;
            //tb_AdministradorAdministradorDireccion.ReadOnly = usua.BotonTrue;
            //tb_AdministradorTelefono.ReadOnly = usua.BotonTrue;
            //tb_AdministradorUsuario.ReadOnly = usua.BotonTrue;
            //tb_AdministradorContrasenia.ReadOnly = usua.BotonTrue;
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

        usua = logica.editarBuscarUser(int.Parse(tb_AministradorAdministradorId.Text), int.Parse(Session["idioma"].ToString()));


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
        DDL_Estado.SelectedValue = usua.Estado;
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
        //LUser logica = new LUser();
        //UUser usua = new UUser();
        //string foto = cargarImagen();
        //int rol = 1;
        //usua = logica.editarAdmin(
        //    tb_AdministradorAdministradorNombre.Text,
        //    tb_AdministradorUsuario.Text,
        //    tb_AdministradorContrasenia.Text,
        //    tb_AdministradorAdministradorCorreo.Text,
        //    tb_AdministradorAdministradorApellido.Text,
        //    tb_AdministradorAdministradorDireccion.Text,
        //    tb_AdministradorTelefono.Text,
        //    int.Parse(tb_AministradorAdministradorId.Text),
        //    DDL_Estado.SelectedValue,
        //    fechanac.Text,
        //    int.Parse(ddt_lugarnacimDep.SelectedValue),
        //    int.Parse(DDT_Ciudad.SelectedValue),
        //    Session.SessionID,
        //    foto,
        //    c,
        //    int.Parse(Session["idioma"].ToString()),
        //    rol
        //    );

        //this.Page.Response.Write(usua.Notificacion);

        //tb_AministradorAdministradorId.ReadOnly = usua.BotonTrue;
        //tb_AdministradorAdministradorNombre.ReadOnly = usua.BotonFalse;
        //tb_AdministradorAdministradorApellido.ReadOnly = usua.BotonFalse;
        //tb_AdministradorAdministradorCorreo.ReadOnly = usua.BotonFalse;
        //tb_AdministradorAdministradorDireccion.ReadOnly = usua.BotonFalse;
        //tb_AdministradorTelefono.ReadOnly = usua.BotonFalse;
        //tb_AdministradorUsuario.ReadOnly = usua.BotonFalse;
        //tb_AdministradorContrasenia.ReadOnly = usua.BotonFalse;
        //btn_AdministradorEditar.Visible = usua.BotonFalse;
        //btn_AdministradorNuevo.Visible = usua.BotonTrue;
        //btn_AdministradorAceptar.Visible = usua.BotonFalse;


        LMUser logica = new LMUser();
        Usuario user = new Usuario();
        UUser usu = new UUser();

        user.num_documento = (tb_AministradorAdministradorId.Text);
        user.nombre_usua = tb_AdministradorAdministradorNombre.Text;
        user.clave = tb_AdministradorContrasenia.Text;
        user.correo = tb_AdministradorAdministradorCorreo.Text;
        user.apellido_usua = tb_AdministradorAdministradorApellido.Text;
        user.direccion = tb_AdministradorAdministradorDireccion.Text;
        user.telefono = tb_AdministradorTelefono.Text;
        user.foto_usua = cargarImagen();
        user.fecha_nac = fechanac.Text;
        user.dep_nacimiento = (ddt_lugarnacimDep.SelectedValue.ToString());
        user.ciu_nacimiento = (DDT_Ciudad.SelectedValue.ToString());
        user.sesion = Session.SessionID;
        user.rol_id = "1";
        user.user_name = tb_AdministradorUsuario.Text;




        usu = logica.editarAdmin(user, int.Parse(Session["idioma"].ToString()), DDL_Estado.SelectedValue, Session["fotosinedit"].ToString());

        this.Page.Response.Write(usu.Notificacion);

        tb_AministradorAdministradorId.ReadOnly = usu.BotonTrue;
        tb_AdministradorAdministradorNombre.ReadOnly = usu.BotonFalse;
        tb_AdministradorAdministradorApellido.ReadOnly = usu.BotonFalse;
        tb_AdministradorAdministradorCorreo.ReadOnly = usu.BotonFalse;
        tb_AdministradorAdministradorDireccion.ReadOnly = usu.BotonFalse;
        tb_AdministradorTelefono.ReadOnly = usu.BotonFalse;
        tb_AdministradorUsuario.ReadOnly = usu.BotonFalse;
        tb_AdministradorContrasenia.ReadOnly = usu.BotonFalse;
        btn_AdministradorEditar.Visible = usu.BotonFalse;
        btn_AdministradorNuevo.Visible = usu.BotonTrue;
        btn_AdministradorAceptar.Visible = usu.BotonFalse;

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
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_AdministradorFoto.PostedFile.FileName), System.IO.Path.GetExtension(tb_AdministradorFoto.PostedFile.FileName), tb_AdministradorFoto.ToString(), Server.MapPath("~/FotosUser"), int.Parse(Session["idioma"].ToString()));
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