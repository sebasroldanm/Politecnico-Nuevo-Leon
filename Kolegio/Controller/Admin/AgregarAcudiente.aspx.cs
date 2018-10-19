using System;
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
        LLogin Logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = Logica.logAgregarAdmin(Session["userId"].ToString());
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
        Int32 FORMULARIO = 6;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreAcuTitulo.Text = encId.CompIdioma["L_AdminAgreAcuTitulo"].ToString();
        L_AdminAgreAcuDocumento.Text = encId.CompIdioma["L_AdminAgreAcuDocumento"].ToString();
        tb_AcudienteId.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteId"].ToString());
        REV_AcudienteId.ErrorMessage = encId.CompIdioma["REV_AcudienteId"].ToString();
        L_AdminAgreAcuNombre.Text = encId.CompIdioma["L_AdminAgreAcuNombre"].ToString();
        tb_AcudienteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteNombre"].ToString());
        REV_AcudienteNombre.ErrorMessage = encId.CompIdioma["REV_AcudienteNombre"].ToString();
        L_AdminAgreAcuApellido.Text = encId.CompIdioma["L_AdminAgreAcuApellido"].ToString();
        tb_AcudienteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteApellido"].ToString());
        REV_AcudienteApellido.ErrorMessage = encId.CompIdioma["REV_AcudienteApellido"].ToString();
        L_AdminAgreAcuDep.Text = encId.CompIdioma["L_AdminAgreAcuDep"].ToString();
        L_AdminAgreAcuFoto.Text = encId.CompIdioma["L_AdminAgreAcuFoto"].ToString();
        L_AdminAgreAcuFechanac.Text = encId.CompIdioma["L_AdminAgreAcuFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminAgreAcuCorreo.Text = encId.CompIdioma["L_AdminAgreAcuCorreo"].ToString();
        tb_AcudienteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteCorreo"].ToString());
        REV_AcudienteCorreo.ErrorMessage = encId.CompIdioma["REV_AcudienteCorreo"].ToString();
        L_ADminAgreAcuDir.Text = encId.CompIdioma["L_ADminAgreAcuDir"].ToString();
        tb_AcudienteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteDireccion"].ToString());
        REV_AcudienteDireccion.ErrorMessage = encId.CompIdioma["REV_AcudienteDireccion"].ToString();
        L_AdminAgreAcuTel.Text = encId.CompIdioma["L_AdminAgreAcuTel"].ToString();
        tb_AcudienteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteTelefono"].ToString());
        REV_AcudienteTelefono.ErrorMessage = encId.CompIdioma["REV_AcudienteTelefono"].ToString();
        L_AdminAgreAcuUser.Text = encId.CompIdioma["L_AdminAgreAcuUser"].ToString();
        tb_AcudienteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteUsuario"].ToString());
        REV_AcudienteUsuario.ErrorMessage = encId.CompIdioma["REV_AcudienteUsuario"].ToString();
        L_AdminAgreAcuContra.Text = encId.CompIdioma["L_AdminAgreAcuContra"].ToString();
        tb_AcudienteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_AcudienteContrasenia"].ToString());
        REV_AcudienteContrasenia.ErrorMessage = encId.CompIdioma["REV_AcudienteContrasenia"].ToString();
        btn_validar.Text = encId.CompIdioma["btn_validar"].ToString();
        btn_AcudienteAceptar.Text = encId.CompIdioma["btn_AcudienteAceptar"].ToString();
        btn_AcudienteNuevo.Text = encId.CompIdioma["btn_AcudienteNuevo"].ToString();


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



        btn_AcudienteAceptar.Text = encId.CompIdioma["btn_AcudienteAceptar"].ToString();
        btn_AcudienteNuevo.Text = encId.CompIdioma["btn_AcudienteNuevo"].ToString();

        // script Usuario Insertado con Exito //Error al Seleccionar la Foto

        //
        
    }

    protected void descartar_idioma_Click(object sender, EventArgs e)
    {
        LMIdioma logica = new LMIdioma();
        UIdioma enc = new UIdioma();

        int idioma = Convert.ToInt32(Session["nombreIdioma"]);

        enc = logica.eliminarIdiomaCompleto(idioma);

        Session["empezar"] = null;

    }

    protected void volver_idioma_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditarPaginaInicio.aspx");
    }


    protected void btn_AcudienteAceptar_Click(object sender, EventArgs e)
    {

        /////**************************Aqui Inicia la Migracion***********************************

        //LUser logica = new LUser();
        //UUser usua = new UUser();
        //string foto = cargarImagen();
        //usua = logica.AgregarAdmin(
        //    int.Parse(ddt_lugarnacimDep.SelectedValue),
        //    int.Parse(DDT_Ciudad.SelectedValue),
        //    tb_AcudienteNombre.Text,
        //    tb_AcudienteApellido.Text,
        //    tb_AcudienteDireccion.Text,
        //    tb_AcudienteTelefono.Text,
        //    tb_AcudienteContrasenia.Text,
        //    tb_AcudienteCorreo.Text,
        //    foto,
        //    int.Parse(tb_AcudienteId.Text),
        //    tb_AcudienteUsuario.Text,
        //    4,
        //    fechanac.Text,
        //    Session.SessionID,
        //    int.Parse(Session["idioma"].ToString())
        //    );

        //L_ErrorUsuario.Text = usua.Mensaje;
        //btn_AcudienteAceptar.Visible = false;
        //this.Page.Response.Write(usua.Notificacion);
        /////**************************Aqui Termina la Migracion***********************************

        /////**************************Aqui Inicia el Mapeo***********************************

        LMUser logicaM = new LMUser();
        Usuario usua = new Usuario();
        UUser usu = new UUser();


        usua.nombre_usua = tb_AcudienteNombre.Text;
        usua.user_name = tb_AcudienteUsuario.Text;
        usua.rol_id = "4";
        usua.clave = tb_AcudienteContrasenia.Text;
        usua.correo = tb_AcudienteCorreo.Text;
        usua.estado = true;
        usua.apellido_usua = tb_AcudienteApellido.Text;
        usua.direccion = tb_AcudienteDireccion.Text;
        usua.telefono = tb_AcudienteTelefono.Text;
        usua.num_documento = tb_AcudienteId.Text;
        usua.foto_usua = cargarImagen();
        usua.fecha_nac = fechanac.Text;
        usua.dep_nacimiento = ddt_lugarnacimDep.SelectedValue;
        usua.ciu_nacimiento = DDT_Ciudad.SelectedValue;
        usua.sesion = Session.SessionID;
        usua.ultima_modificacion = DateTime.Now.ToShortDateString();
        usua.state_t = "1";

        usu = logicaM.insertaracudiente(usua, int.Parse(Session["idioma"].ToString()));

        L_ErrorUsuario.Text = usu.Mensaje;
        this.Page.Response.Write(usu.Notificacion);
        btn_AcudienteAceptar.Visible = usu.L_Aceptar1;
        btn_AcudienteNuevo.Visible = usu.B_Botones1;

        /////**************************Aqui Termina el Mapeo***********************************


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

        //LUser logica = new LUser();
        //UUser usua = new UUser();

        //usua = logica.validarUser(tb_AcudienteUsuario.Text, tb_AcudienteId.Text, int.Parse(Session["idioma"].ToString()));
        //L_ErrorUsuario.Text = usua.Mensaje;

        //btn_AcudienteAceptar.Visible = usua.L_Aceptar1;
        //btn_AcudienteNuevo.Visible = usua.L_Aceptar1;

        //tb_AcudienteUsuario.ReadOnly = usua.L_Aceptar1;
        //tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        //btn_validar.Visible = usua.B_Botones1;


        LMUser logica = new LMUser();
        Usuario usuario = new Usuario();
        UUser usua = new UUser();

        usua = logica.validarUsuario(tb_AcudienteUsuario.Text, tb_AcudienteId.Text, int.Parse(Session["idioma"].ToString()));
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_AcudienteAceptar.Visible = usua.L_Aceptar1;
        tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteUsuario.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;


    }

    protected string cargarImagen()
    {
        LUser logic = new LUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName), System.IO.Path.GetExtension(tb_Foto.PostedFile.FileName), tb_Foto.ToString(), Server.MapPath("~/FotosUser"), int.Parse(Session["idioma"].ToString()));
        try
        {
            ClientScriptManager cm = this.ClientScript;
            cm.RegisterClientScriptBlock(this.GetType(), "", enc.Notificacion);
            btnigm_calendar.Visible = true;

            tb_Foto.PostedFile.SaveAs(enc.SaveLocation);
            return enc.FotoCargada;
        }
        catch
        {
            return null;
        }
    }



}