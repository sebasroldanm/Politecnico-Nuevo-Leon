using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Admin_AgregarEstudiante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logAgregaEstudiante(Session["userId"].ToString());
            int year;
            year = int.Parse(DateTime.Now.ToString("yyyy"));
            year = year - 4;
            CalendarExtender1.EndDate = Convert.ToDateTime("31/12/" + year);
            //fechanac.ReadOnly = usua.BotonTrue;
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
        Int32 FORMULARIO = 8;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreEstuTitulo.Text = encId.CompIdioma["L_AdminAgreEstuTitulo"].ToString();
        L_AdminAgreEstuNumAcu.Text = encId.CompIdioma["L_AdminAgreEstuNumAcu"].ToString();
        tb_AcudienteId.Attributes.Add("placeholder", encId.CompIdioma["tb_AcudienteId"].ToString());
        btn_buscarAcudiente.Text = encId.CompIdioma["btn_buscarAcudiente"].ToString();
        L_AdminAgreEstuAcuNombre.Text = encId.CompIdioma["L_AdminAgreEstuAcuNombre"].ToString();
        L_AdminAgreEstuAcuApellido.Text = encId.CompIdioma["L_AdminAgreEstuAcuApellido"].ToString();
        L_AdminAgreEstuDocumento.Text = encId.CompIdioma["L_AdminAgreEstuDocumento"].ToString();
        tb_EstudianteId.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteId"].ToString());
        REV_EstudianteId.ErrorMessage = encId.CompIdioma["REV_EstudianteId"].ToString();
        L_AdminAgreEstuNombre.Text = encId.CompIdioma["L_AdminAgreEstuNombre"].ToString();
        tb_EstudianteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteNombre"].ToString());
        REV_EstudianteNombre.ErrorMessage = encId.CompIdioma["REV_EstudianteNombre"].ToString();
        L_AdminAgreEstuApellido.Text = encId.CompIdioma["L_AdminAgreEstuApellido"].ToString();
        tb_EstudianteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteApellido"].ToString());
        REV_EstudianteApellido.ErrorMessage = encId.CompIdioma["REV_EstudianteApellido"].ToString();
        L_AdminAgreEstuDep.Text = encId.CompIdioma["L_AdminAgreEstuDep"].ToString();
        L_AdminAgreEstuFoto.Text = encId.CompIdioma["L_AdminAgreEstuFoto"].ToString();
        L_AdminAgreEstuFechanac.Text = encId.CompIdioma["L_AdminAgreEstuFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminAgreEstuCorreo.Text = encId.CompIdioma["L_AdminAgreEstuCorreo"].ToString();
        tb_EstudianteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteCorreo"].ToString());
        REV_EstudianteCorreo.ErrorMessage = encId.CompIdioma["REV_EstudianteCorreo"].ToString();
        L_ADminAgreEstuDir.Text = encId.CompIdioma["L_ADminAgreEstuDir"].ToString();
        tb_EstudianteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteDireccion"].ToString());
        REV_EstudianteDireccion.ErrorMessage = encId.CompIdioma["REV_EstudianteDireccion"].ToString();
        L_AdminAgreEstuTel.Text = encId.CompIdioma["L_AdminAgreEstuTel"].ToString();
        tb_EstudianteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteTelefono"].ToString());
        REV_EstudianteTelefono.ErrorMessage = encId.CompIdioma["REV_EstudianteTelefono"].ToString();
        L_AdminAgreEstuUser.Text = encId.CompIdioma["L_AdminAgreEstuUser"].ToString();
        tb_EstudianteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_EstudianteUsuario"].ToString());
        REV_EstudianteUsuario.ErrorMessage = encId.CompIdioma["REV_EstudianteUsuario"].ToString();
        L_AdminAgreEstuContra.Text = encId.CompIdioma["L_AdminAgreEstuContra"].ToString();
        tb_EstudianteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_EstudianteContrasenia"].ToString());
        REV_EstudianteContrasenia.ErrorMessage = encId.CompIdioma["REV_EstudianteContrasenia"].ToString();
        btn_validar.Text = encId.CompIdioma["btn_validar"].ToString();
        btn_EstudianteAceptar.Text = encId.CompIdioma["btn_EstudianteAceptar"].ToString();
        btn_EstudianteNuevo.Text = encId.CompIdioma["btn_EstudianteNuevo"].ToString();

        RV_id_estudiante.ErrorMessage = encId.CompIdioma["RV_id_Acudiente"].ToString();
        RV_ID_Acudiente_Buscar.ErrorMessage = encId.CompIdioma["RV_id_Acudiente"].ToString();

        //agregarEstudiante
        //L_ErrorUsuario_Seleccione.Text="Debe seleccionar una opcion";
        //script_insertado = "Usuario Insertado con Exito";


        //validarUser
        //L_ErrorUser_existe="El Usuario ya existe";
        //L_ErrorUser_disponible="Usuario Disponible";


        //buscarAcudiete
        //L_ErrorAcudiente.Text = "El Acudiente No se encuentra en la base de Datos";
        //script_acudiente_ok="Acudiente Seleccionado";



        //cargarFoto
        //script_error_formato="Solo se admiten imagenes en formato Jpeg o Gif";
        //script_error_foto_repite="Ya existe una imagen en el servidor con ese nombre";
        //script_foto_cargada="El archivo de imagen ha sido cargado";

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

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {
        LMUser logica = new LMUser();
        UUser usua = new UUser();
        string foto = cargarImagen();
        usua = logica.agregarEstudiante(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_EstudianteNombre.Text,
            tb_EstudianteApellido.Text,
            tb_EstudianteDireccion.Text,
            tb_EstudianteTelefono.Text,
            tb_EstudianteContrasenia.Text,
            tb_EstudianteCorreo.Text,
            foto,
            int.Parse(tb_EstudianteId.Text),
            tb_EstudianteUsuario.Text,
            3,
            fechanac.Text,
            Session.SessionID,
            Convert.ToInt32(Session["id_acu"]),
            int.Parse(Session["idioma"].ToString())
            );
        this.Page.Response.Write(usua.Notificacion);
        btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        L_ErrorUser.Visible = usua.L_Aceptar1;
        btn_EstudianteNuevo.Visible = usua.B_Botones1;


    }

    protected void btn_EstudianteNuevo_Click(object sender, EventArgs e)
    {
        fechanac.Text = "";
        tb_EstudianteNombre.Text = "";
        tb_EstudianteApellido.Text = "";
        tb_EstudianteDireccion.Text = "";
        tb_EstudianteCorreo.Text = "";
        tb_EstudianteContrasenia.Text = "";
        tb_EstudianteUsuario.Text = "";
        tb_EstudianteTelefono.Text = "";
        tb_EstudianteId.Text = "";
        tb_EstudianteId.ReadOnly = false;
        tb_EstudianteUsuario.ReadOnly = false;
        btn_validar.Visible = true;
        btn_EstudianteNuevo.Visible = false;
        btn_EstudianteAceptar.Visible = false;
        tb_EstudianteId.Focus();
        L_ErrorUsuario.Text = "";
        L_ErrorUser.Text = "";


    }

    protected void btn_validar_Click(object sender, EventArgs e)
    {

        //LUser logica = new LUser();
        //UUser usua = new UUser();

        //usua = logica.validarUser(tb_EstudianteUsuario.Text, tb_EstudianteId.Text, int.Parse(Session["idioma"].ToString()));
        //L_ErrorUser.Text = usua.Mensaje;
        //btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        //btn_EstudianteNuevo.Visible = usua.L_Aceptar1;
        //tb_EstudianteId.ReadOnly = usua.L_Aceptar1;
        //tb_EstudianteUsuario.ReadOnly = usua.L_Aceptar1;
        //btn_validar.Visible = false;



        LMUser logica = new LMUser();
        Usuario usuario = new Usuario();
        UUser usua = new UUser();

        usua = logica.validarUsuario(tb_EstudianteUsuario.Text, tb_EstudianteId.Text, int.Parse(Session["idioma"].ToString()));
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        tb_EstudianteId.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteUsuario.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;



    }

    protected void btn_buscarAcudiente_Click(object sender, EventArgs e)
    {

        //LUser logica = new LUser();
        //UUser usua = new UUser();

        //usua = logica.buscarAcudiete(
        //    int.Parse(ddt_lugarnacimDep.SelectedValue),
        //    int.Parse(DDT_Ciudad.SelectedValue),
        //    tb_AcudienteId.Text,
        //    int.Parse(Session["idioma"].ToString()));

        //L_ErrorAcudiente.Text = usua.MensajeAcudiente;
        //tb_AcudienteNombre.ReadOnly = usua.L_Aceptar1;
        //tb_AcudienteNombre.Text = usua.Nombre;
        //tb_AcudienteApellido.ReadOnly = usua.L_Aceptar1;
        //tb_AcudienteApellido.Text = usua.Apellido;
        //tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        //Session["id_acu"] = usua.id_Acudiente;
        //this.Page.Response.Write(usua.Notificacion);

        LMUser logica = new LMUser();
        UUser usua = new UUser();

        usua = logica.buscarAcudiete(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_AcudienteId.Text,
            int.Parse(Session["idioma"].ToString()));

        L_ErrorAcudiente.Text = usua.MensajeAcudiente;
        tb_AcudienteNombre.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteNombre.Text = usua.Nombre;
        tb_AcudienteApellido.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteApellido.Text = usua.Apellido;
        tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        Session["id_acu"] = usua.id_Acudiente;
        this.Page.Response.Write(usua.Notificacion);



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