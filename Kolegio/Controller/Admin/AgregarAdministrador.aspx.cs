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

        try
        {
            usua.SUserName = Session["empezar"].ToString();
            MPE_Idioma.Show();
        }
        catch
        {

        }


        UIdioma encId = new UIdioma();
        LMIdioma idioma = new LMIdioma();
        Int32 FORMULARIO = 7;
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreAdminTitulo.Text = encId.CompIdioma["L_AdminAgreAdminTitulo"].ToString();

        L_AdminAgreAdminDocumento.Text = encId.CompIdioma["Title"].ToString();
        tb_AministradorAdministradorId.Attributes.Add("placeholder", encId.CompIdioma["L_AdminAgreAdminDocumento"].ToString());
        REV_AministradorAdministradorId.ErrorMessage = encId.CompIdioma["REV_AministradorAdministradorId"].ToString();
        L_AdminAgreAdminNombre.Text = encId.CompIdioma["L_AdminAgreAdminNombre"].ToString();
        tb_AdministradorAdministradorNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorNombre"].ToString());
        REV_AdministradorAdministradorNombre.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorNombre"].ToString();
        L_AdminAgreAdminApellido.Text = encId.CompIdioma["L_AdminAgreAdminApellido"].ToString();
        tb_AdministradorAdministradorApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorApellido"].ToString());
        REV_AdministradorAdministradorApellido.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorApellido"].ToString();
        L_AdminAgreAdminDep.Text = encId.CompIdioma["L_AdminAgreAdminDep"].ToString();
        L_AdminAgreAdminFoto.Text = encId.CompIdioma["L_AdminAgreAdminFoto"].ToString();
        L_AdminAgreAdminFechanac.Text = encId.CompIdioma["L_AdminAgreAdminFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminAgreAdminCorreo.Text = encId.CompIdioma["L_AdminAgreAdminCorreo"].ToString();
        tb_AdministradorAdministradorCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorCorreo"].ToString());
        REV_AdministradorAdministradorCorreo.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorCorreo"].ToString();
        L_ADminAgreAdminDir.Text = encId.CompIdioma["L_ADminAgreAdminDir"].ToString();
        tb_AdministradorAdministradorDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorAdministradorDireccion"].ToString());
        REV_AdministradorAdministradorDireccion.ErrorMessage = encId.CompIdioma["REV_AdministradorAdministradorDireccion"].ToString();
        L_AdminAgreAdminTel.Text = encId.CompIdioma["L_AdminAgreAdminTel"].ToString();
        tb_AdministradorTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorTelefono"].ToString());
        REV_AdministradorTelefono.ErrorMessage = encId.CompIdioma["REV_AdministradorTelefono"].ToString();
        L_AdminAgreAdminUser.Text = encId.CompIdioma["L_AdminAgreAdminUser"].ToString();
        tb_AdministradorUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_AdministradorUsuario"].ToString());
        REV_AdministradorUsuario.ErrorMessage = encId.CompIdioma["REV_AdministradorUsuario"].ToString();
        L_AdminAgreAdminContra.Text = encId.CompIdioma["L_AdminAgreAdminContra"].ToString();
        tb_AdministradorContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_AdministradorContrasenia"].ToString());
        REV_AdministradorContrasenia.ErrorMessage = encId.CompIdioma["REV_AdministradorContrasenia"].ToString();
        btn_validar.Text = encId.CompIdioma["btn_validar"].ToString();
       
        //Por Agregar
        btn_AdministradorAceptar.Text = encId.CompIdioma["btn_AdministradorAceptar"].ToString();
        btn_AdministradorNuevo.Text = encId.CompIdioma["btn_AdministradorNuevo"].ToString();

        
        RV_id_Administrador.ErrorMessage = encId.CompIdioma["RV_id_Acudiente"].ToString();



        //AgregarAdmin
        //L_ErrorUsuario_Seleccione.Text="Debe seleccionar una opcion";
        //script_insertado = "Usuario Insertado con Exito";
        //script_error_foto = "Error al Seleccionar la Foto";


        //validarUser
        //L_ErrorUsuario_usuario_existe.Text="Usuario Disponible";
        //L_ErrorUsuario_usuario_noexiste.Text="El Usuario ya existe";


        //cargarFoto
        //script_error_formato="Solo se admiten imagenes en formato Jpeg o Gif";
        //script_error_foto_repite="Ya existe una imagen en el servidor con ese nombre";
        //script_foto_cargada="El archivo de imagen ha sido cargado";
        
    }

    protected void descartar_idioma_Click(object sender, EventArgs e)
    {
        LIdioma logica = new LIdioma();
        UIdioma enc = new UIdioma();

        int idioma = Convert.ToInt32(Session["nombreIdioma"]);

        enc = logica.eliminarIdiomaCompleto(idioma);

        Session["empezar"] = null;

    }

    protected void volver_idioma_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditarPaginaInicio.aspx");
    }

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {
        /////**************************Aqui Inicia la Migracion***********************************
        //LUser Logica = new LUser();
        //UUser usua = new UUser();
        //string foto = cargarImagen();

        //usua = Logica.AgregarAdmin(
        //    int.Parse(ddt_lugarnacimDep.SelectedValue),
        //    int.Parse(DDT_Ciudad.SelectedValue),
        //    tb_AdministradorAdministradorNombre.Text,
        //    tb_AdministradorAdministradorApellido.Text,
        //    tb_AdministradorAdministradorDireccion.Text,
        //    tb_AdministradorTelefono.Text,
        //    tb_AdministradorContrasenia.Text,
        //    tb_AdministradorAdministradorCorreo.Text,
        //    foto,
        //    int.Parse(tb_AministradorAdministradorId.Text),
        //    tb_AdministradorUsuario.Text,
        //    1,
        //    fechanac.Text,
        //    Session.SessionID,
        //    int.Parse(Session["idioma"].ToString())
        //    );
        //L_ErrorUsuario.Text = usua.Mensaje;
        //this.Page.Response.Write(usua.Notificacion);
        //btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        //btn_AdministradorNuevo.Visible = usua.B_Botones1;
        /////**************************Aqui Termina la Migracion***********************************


        /////**************************Aqui Inicia el Mapeo***********************************


        LMUser logicaM = new LMUser();
        Usuario usua = new Usuario();
        UUser usu = new UUser();

        usua.nombre_usua = tb_AdministradorAdministradorNombre.Text;
        usua.user_name = tb_AdministradorUsuario.Text;
        usua.rol_id = 1;
        usua.clave = tb_AdministradorContrasenia.Text;
        usua.correo = tb_AdministradorAdministradorCorreo.Text;
        usua.estado = true;
        usua.apellido_usua = tb_AdministradorAdministradorApellido.Text;
        usua.direccion = tb_AdministradorAdministradorDireccion.Text;
        usua.telefono = tb_AdministradorTelefono.Text;
        usua.num_documento = int.Parse(tb_AministradorAdministradorId.Text);
        usua.foto_usua = cargarImagen();
        usua.fecha_nac = fechanac.Text;
        usua.dep_nacimiento = int.Parse(ddt_lugarnacimDep.SelectedValue);
        usua.ciu_nacimiento = int.Parse(DDT_Ciudad.SelectedValue);
        usua.sesion = Session.SessionID;
        usua.ultima_modificacion = (DateTime.Now.ToShortDateString());
        usua.state_t = 1;

        usu = logicaM.insertaradmin(usua,int.Parse(Session["idioma"].ToString()));
        

        L_ErrorUsuario.Text = usu.Mensaje;
        this.Page.Response.Write(usu.Notificacion);
        btn_AdministradorAceptar.Visible = usu.L_Aceptar1;
        btn_AdministradorNuevo.Visible = usu.B_Botones1;


        /////**************************Aqui Termina el Mapeo***********************************


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
        btn_AdministradorNuevo.Visible = false;
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

        //LUser logica = new LUser();
        //UUser usua = new UUser();

        //usua = logica.validarUser(tb_AdministradorUsuario.Text, tb_AministradorAdministradorId.Text, int.Parse(Session["idioma"].ToString()));
        //L_ErrorUsuario.Text = usua.Mensaje;
        //btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        //tb_AministradorAdministradorId.ReadOnly = usua.L_Aceptar1;
        //tb_AdministradorUsuario.ReadOnly = usua.L_Aceptar1;
        //btn_validar.Visible = usua.B_Botones1;


        LMUser logica = new LMUser();
        Usuario usuario = new Usuario();
        UUser usua = new UUser();

        usua = logica.validarUsuario(tb_AdministradorUsuario.Text, tb_AministradorAdministradorId.Text, int.Parse(Session["idioma"].ToString()));
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        tb_AministradorAdministradorId.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorUsuario.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;
    }

    protected string cargarImagen()
    {
        LMUser logic = new LMUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_AdministradorFoto.PostedFile.FileName), System.IO.Path.GetExtension(tb_AdministradorFoto.PostedFile.FileName), tb_AdministradorFoto.ToString(), Server.MapPath("~/FotosUser"), int.Parse(Session["idioma"].ToString()));
        try
        {
            ClientScriptManager cm = this.ClientScript;
          //  cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);
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

    protected void B_InsMap_Click(object sender, EventArgs e)
    {
        //Usuario user = new Usuario();
        //user.Nombre = tb_AdministradorAdministradorNombre.Text;
        //user.Rol = "1";
        //user.UserName = tb_AdministradorUsuario.Text;
        //user.Clave = tb_AdministradorContrasenia.Text;
        //user.Correo = tb_AdministradorAdministradorCorreo.Text;
        //user.Estado = "true";
        //user.Apellido = tb_AdministradorAdministradorApellido.Text;
        //user.Direccion = tb_AdministradorAdministradorDireccion.Text;
        //user.Telefono = tb_AdministradorTelefono.Text;
        //user.Documento = tb_AministradorAdministradorId.Text;
        //user.Foto = cargarImagen();
        //user.fecha_nacimiento = fechanac.Text;
        //user.Departamento = ddt_lugarnacimDep.SelectedValue;
        //user.Ciudad = DDT_Ciudad.SelectedValue;
        //user.Sesion = Session.SessionID;

        //LMUser logica = new LMUser();
        //logica.insertarUserMapeo(user);
        /*
         ,
            int.Parse(),
            ,
            ,
            ,
            ,
            ,
            ,
            foto,
            int.Parse(),
            ,
            1,
            ,
            ,
            int.Parse(Session["idioma"].ToString()) 
         */
    }
}