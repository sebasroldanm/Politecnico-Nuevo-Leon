using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarProfesor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documento"].ToString());
            tb_DocenteId.Text = (string)Session["documento"];
            tb_DocenteNombre.ReadOnly = usua.BotonTrue;
            tb_DocenteApellido.ReadOnly = usua.BotonTrue;
            tb_DocenteCorreo.ReadOnly = usua.BotonTrue;
            tb_DocenteDireccion.ReadOnly = usua.BotonTrue;
            tb_DocenteTelefono.ReadOnly = usua.BotonTrue;
            tb_DocenteUsuario.ReadOnly = usua.BotonTrue;
            tb_DocenteContrasenia.ReadOnly = usua.BotonTrue;
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
        Int32 FORMULARIO = 18;
        //<asp:Label ID="" runat="server"></asp:Label>
        encId = idioma.obtIdioma(FORMULARIO, int.Parse(Session["idioma"].ToString()));

        Page.Title = encId.CompIdioma["Title"].ToString();
        L_AdminEditProTitulo.Text = encId.CompIdioma["L_AdminEditProTitulo"].ToString();
        L_AdminEditProDocumento.Text = encId.CompIdioma["L_AdminEditProDocumento"].ToString();
        tb_DocenteId.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteId"].ToString());
        REV_DocenteId.ErrorMessage = encId.CompIdioma["REV_DocenteId"].ToString();
        L_AdminEditProNombre.Text = encId.CompIdioma["L_AdminEditProNombre"].ToString();
        tb_DocenteNombre.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteNombre"].ToString());
        REV_DocenteNombre.ErrorMessage = encId.CompIdioma["REV_DocenteNombre"].ToString();
        L_AdminEditProApellido.Text = encId.CompIdioma["L_AdminEditProApellido"].ToString();
        tb_DocenteApellido.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteApellido"].ToString());
        REV_DocenteApellido.ErrorMessage = encId.CompIdioma["REV_DocenteApellido"].ToString();
        L_AdminEditProDep.Text = encId.CompIdioma["L_AdminEditProDep"].ToString();
        L_AdminEditProFoto.Text = encId.CompIdioma["L_AdminEditProFoto"].ToString();
        L_AdminEditProFechanac.Text = encId.CompIdioma["L_AdminEditProFechanac"].ToString();
        fechanac.Attributes.Add("placeholder", encId.CompIdioma["fechanac"].ToString());
        L_AdminEditProCorreo.Text = encId.CompIdioma["L_AdminEditProCorreo"].ToString();
        tb_DocenteCorreo.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteCorreo"].ToString());
        REV_DocenteCorreo.ErrorMessage = encId.CompIdioma["REV_DocenteCorreo"].ToString();
        L_ADminEditProDir.Text = encId.CompIdioma["L_ADminEditProDir"].ToString();
        tb_DocenteDireccion.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteDireccion"].ToString());
        REV_DocenteDireccion.ErrorMessage = encId.CompIdioma["REV_DocenteDireccion"].ToString();
        L_AdminEditProTel.Text = encId.CompIdioma["L_AdminEditProTel"].ToString();
        tb_DocenteTelefono.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteTelefono"].ToString());
        REV_DocenteTelefono.ErrorMessage = encId.CompIdioma["REV_DocenteTelefono"].ToString();
        L_AdminEditProUser.Text = encId.CompIdioma["L_AdminEditProUser"].ToString();
        tb_DocenteUsuario.Attributes.Add("placeholder", encId.CompIdioma["tb_DocenteUsuario"].ToString());
        REV_DocenteUsuario.ErrorMessage = encId.CompIdioma["REV_DocenteUsuario"].ToString();
        L_AdminEditProContra.Text = encId.CompIdioma["L_AdminEditProContra"].ToString();
        tb_DocenteContrasenia.Attributes.Add(" placeholder", encId.CompIdioma["tb_DocenteContrasenia"].ToString());
        REV_DocenteContrasenia.ErrorMessage = encId.CompIdioma["REV_DocenteContrasenia"].ToString();
        btn_DocenteAceptar.Text = encId.CompIdioma["btn_DocenteAceptar"].ToString();
        btn_DocenteEditar.Text = encId.CompIdioma["btn_DocenteEditar"].ToString();
        btn_DocenteNuevo.Text = encId.CompIdioma["btn_DocenteNuevo"].ToString();


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




        //DDL_Estado
        //item1="Activo";
        //item2="Inactivo";
        if (IsPostBack == false)
        {
            DDL_Estado.Items.Clear();
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado"].ToString());
            DDL_Estado.Items.Add(encId.CompIdioma["DDL_Estado2"].ToString());
        }

        
    }
    protected void btn_DocenteAceptar_Click(object sender, EventArgs e)
    {
        LMUser logica = new LMUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_DocenteId.Text), int.Parse(Session["idioma"].ToString()));
        tb_DocenteId.ReadOnly = usua.B_Botones1;
        tb_DocenteNombre.ReadOnly = usua.L_Aceptar1;
        tb_DocenteNombre.Text = usua.Nombre;
        tb_DocenteApellido.ReadOnly = usua.L_Aceptar1;
        tb_DocenteApellido.Text = usua.Apellido;
        tb_DocenteCorreo.ReadOnly = usua.L_Aceptar1;
        tb_DocenteCorreo.Text = usua.Correo;
        tb_DocenteDireccion.ReadOnly = usua.L_Aceptar1;
        tb_DocenteDireccion.Text = usua.Direccion;
        tb_DocenteTelefono.ReadOnly = usua.L_Aceptar1;
        tb_DocenteTelefono.Text = usua.Telefono;
        tb_DocenteUsuario.ReadOnly = true;
        tb_DocenteUsuario.Text = usua.UserName;
        tb_DocenteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_DocenteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        DDL_Estado.SelectedValue = usua.Estado;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        Session["fotosinedit"] = usua.Foto;
        L_ErrorAdmin.Text = "";

        btn_DocenteEditar.Visible = usua.B_Botones1;
        btn_DocenteNuevo.Visible = usua.B_Botones1;
        btn_DocenteAceptar.Visible = usua.L_Aceptar1;
        L_ErrorAdmin.Text = usua.Mensaje;

    }

    protected void btn_DocenteEditar_Click(object sender, EventArgs e)
    {
        //LUser logica = new LUser();
        //UUser usua = new UUser();
        //string foto = cargarImagen();
        //int rol = 2;
        //usua = logica.editarAdmin(
        //    tb_DocenteNombre.Text,
        //    tb_DocenteUsuario.Text,
        //    tb_DocenteContrasenia.Text,
        //    tb_DocenteCorreo.Text,
        //    tb_DocenteApellido.Text,
        //    tb_DocenteDireccion.Text,
        //    tb_DocenteTelefono.Text,
        //    int.Parse(tb_DocenteId.Text),
        //    DDL_Estado.SelectedValue,
        //    fechanac.Text,
        //    int.Parse(ddt_lugarnacimDep.SelectedValue),
        //    int.Parse(DDT_Ciudad.SelectedValue),
        //    Session.SessionID,
        //    foto,
        //    Session["fotosinedit"].ToString(),
        //    int.Parse(Session["idioma"].ToString()),
        //    rol
        //    );

        //this.Page.Response.Write(usua.Notificacion);

        //tb_DocenteId.ReadOnly = usua.BotonTrue;
        //tb_DocenteNombre.ReadOnly = usua.BotonFalse;
        //tb_DocenteApellido.ReadOnly = usua.BotonFalse;
        //tb_DocenteCorreo.ReadOnly = usua.BotonFalse;
        //tb_DocenteDireccion.ReadOnly = usua.BotonFalse;
        //tb_DocenteTelefono.ReadOnly = usua.BotonFalse;
        //tb_DocenteUsuario.ReadOnly = usua.BotonFalse;
        //tb_DocenteContrasenia.ReadOnly = usua.BotonFalse;
        //btn_DocenteEditar.Visible = usua.BotonFalse;
        //btn_DocenteNuevo.Visible = usua.BotonTrue;
        //btn_DocenteAceptar.Visible = usua.BotonFalse;


        LMUser logica = new LMUser();
        Usuario user = new Usuario();
        UUser usu = new UUser();

        user.num_documento = (tb_DocenteId.Text);
        user.nombre_usua = tb_DocenteNombre.Text;
        user.clave = tb_DocenteContrasenia.Text;
        user.correo = tb_DocenteCorreo.Text;
        user.apellido_usua = tb_DocenteApellido.Text;
        user.direccion = tb_DocenteDireccion.Text;
        user.telefono = tb_DocenteTelefono.Text;
        user.foto_usua = cargarImagen();
        user.fecha_nac = fechanac.Text;
        user.dep_nacimiento = (ddt_lugarnacimDep.SelectedValue.ToString());
        user.ciu_nacimiento = (DDT_Ciudad.SelectedValue.ToString());
        user.sesion = Session.SessionID;
        user.rol_id = "2";
        user.user_name = tb_DocenteUsuario.Text;

        int h = int.Parse(Session["idioma"].ToString());
        string es = DDL_Estado.SelectedValue;
        string s = Session["fotosinedit"].ToString();

        usu = logica.editarProfesor(user, int.Parse(Session["idioma"].ToString()), DDL_Estado.SelectedValue, Session["fotosinedit"].ToString());

        this.Page.Response.Write(usu.Notificacion);

        tb_DocenteId.ReadOnly = usu.BotonTrue;
        tb_DocenteNombre.ReadOnly = usu.BotonFalse;
        tb_DocenteApellido.ReadOnly = usu.BotonFalse;
        tb_DocenteCorreo.ReadOnly = usu.BotonFalse;
        tb_DocenteDireccion.ReadOnly = usu.BotonFalse;
        tb_DocenteTelefono.ReadOnly = usu.BotonFalse;
        tb_DocenteUsuario.ReadOnly = usu.BotonFalse;
        tb_DocenteContrasenia.ReadOnly = usu.BotonFalse;
        btn_DocenteEditar.Visible = usu.BotonFalse;
        btn_DocenteNuevo.Visible = usu.BotonTrue;
        btn_DocenteAceptar.Visible = usu.BotonFalse;



    }

    protected void btn_DocenteNuevo_Click(object sender, EventArgs e)
    {

        tb_DocenteId.Enabled = true;
        tb_DocenteNombre.Text = "";
        tb_DocenteUsuario.Text = "";
        tb_DocenteContrasenia.Text = "";
        tb_DocenteCorreo.Text = "";
        tb_DocenteApellido.Text = "";
        tb_DocenteDireccion.Text = "";
        tb_DocenteTelefono.Text = "";
        tb_DocenteId.Text = "";
        L_ErrorAdmin.Text = "";
        L_Error.Text = "";
        fechanac.Text = "";

        ImagenEst.ImageUrl = "";
        tb_DocenteNombre.ReadOnly = true;
        tb_DocenteApellido.ReadOnly = true;
        tb_DocenteCorreo.ReadOnly = true;
        tb_DocenteDireccion.ReadOnly = true;
        tb_DocenteTelefono.ReadOnly = true;
        tb_DocenteUsuario.ReadOnly = true;
        tb_DocenteContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_DocenteId.ReadOnly = false;

        tb_DocenteId.Focus();
        btn_DocenteEditar.Visible = false;
        btn_DocenteNuevo.Visible = false;
        btn_DocenteAceptar.Visible = true;

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