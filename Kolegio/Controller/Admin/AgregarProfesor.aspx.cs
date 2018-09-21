using System;
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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 11;

        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminAgreProTitulo.Text = encId.CompIdioma["L_AdminAgreProTitulo"].ToString();
        L_AdminAgreProDocumento.Text = encId.CompIdioma["L_AdminAgreProDocumento"].ToString();
        tb_DocenteId.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteId"].ToString());
        REV_DocenteId.ErrorMessage = encId.CompIdioma["REV_DocenteId"].ToString();
        L_AdminAgreProNombre.Text = encId.CompIdioma["L_AdminAgreProNombre"].ToString();
        tb_DocenteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteNombre"].ToString());
        REV_DocenteNombre.ErrorMessage = encId.CompIdioma["REV_DocenteNombre"].ToString();
        L_AdminAgreProApellido.Text = encId.CompIdioma["L_AdminAgreProApellido"].ToString();
        tb_DocenteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteApellido"].ToString());
        REV_DocenteApellido.ErrorMessage = encId.CompIdioma["REV_DocenteApellido"].ToString();
        L_AdminAgreProDep.Text = encId.CompIdioma["L_AdminAgreProDep"].ToString();
        L_AdminAgreProFoto.Text = encId.CompIdioma["L_AdminAgreProFoto"].ToString();
        L_AdminAgreProFechanac.Text = encId.CompIdioma["L_AdminAgreProFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminAgreProCorreo.Text = encId.CompIdioma["L_AdminAgreProCorreo"].ToString();
        tb_DocenteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteCorreo"].ToString());
        REV_DocenteCorreo.ErrorMessage = encId.CompIdioma["REV_DocenteCorreo"].ToString();
        L_ADminAgreProDir.Text = encId.CompIdioma["L_ADminAgreProDir"].ToString();
        tb_DocenteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteDireccion"].ToString());
        REV_DocenteDireccion.ErrorMessage = encId.CompIdioma["REV_DocenteDireccion"].ToString();
        L_AdminAgreProTel.Text = encId.CompIdioma["L_AdminAgreProTel"].ToString();
        tb_DocenteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteTelefono"].ToString());
        REV_DocenteTelefono.ErrorMessage = encId.CompIdioma["REV_DocenteTelefono"].ToString();
        L_AdminAgreProUser.Text = encId.CompIdioma["L_AdminAgreProUser"].ToString();
        tb_DocenteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteUsuario"].ToString());
        REV_DocenteUsuario.ErrorMessage = encId.CompIdioma["REV_DocenteUsuario"].ToString();
        L_AdminAgreProContra.Text = encId.CompIdioma["L_AdminAgreProContra"].ToString();
        tb_DocenteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_DocenteContrasenia"].ToString());
        REV_DocenteContrasenia.ErrorMessage = encId.CompIdioma["REV_DocenteContrasenia"].ToString();
        btn_validar.Text = encId.CompIdioma["btn_validar"].ToString();
        btn_DocenteAceptar.Text = encId.CompIdioma["btn_DocenteAceptar"].ToString();
        btn_DocenteNuevo.Text = encId.CompIdioma["btn_DocenteNuevo"].ToString();


        //falta
        RV_id_profesor.ErrorMessage = encId.CompIdioma["RV_id_Acudiente"].ToString();


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
    }

    protected void btn_AdministradorAceptar_Click2(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();
        string foto = cargarImagen();

        usua = logica.AgregarAdmin(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_DocenteNombre.Text,
            tb_DocenteApellido.Text,
            tb_DocenteDireccion.Text,
            tb_DocenteTelefono.Text,
            tb_DocenteContrasenia.Text,
            tb_DocenteCorreo.Text,
            foto,
            int.Parse(tb_DocenteId.Text),
            tb_DocenteUsuario.Text,
            2,
            fechanac.Text,
            Session.SessionID,
            int.Parse(Session["idioma"].ToString())
            );

        L_ErrorUsuario.Text = usua.Mensaje;
        btn_DocenteAceptar.Visible = false;
        this.Page.Response.Write(usua.Notificacion);


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

        usua = logica.validarUser(tb_DocenteUsuario.Text, tb_DocenteId.Text, int.Parse(Session["idioma"].ToString()));
        L_ErrorUsuario.Text = usua.Mensaje;
        btn_DocenteAceptar.Visible = usua.L_Aceptar1;
        btn_DocenteNuevo.Visible = usua.L_Aceptar1;
        tb_DocenteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_DocenteId.ReadOnly = usua.L_Aceptar1;
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