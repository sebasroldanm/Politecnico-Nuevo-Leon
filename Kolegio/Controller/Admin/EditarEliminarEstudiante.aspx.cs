using System;
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
        UIdioma encId = new UIdioma();
        LIdioma idioma = new LIdioma();
        Int32 FORMULARIO = 17;
        //<asp:Label ID="" runat="server"></asp:Label>
        Page.Title = "Editar Estudiante";
        L_AdminEditEstuId.Text = "Numero de Documento ";
        tb_EstudianteId.Attributes.Add("placeholder", "Numero de Documento");
        REV_EstudianteId.ErrorMessage = "Digitar solo números";
        L_AdminEditEstuNombre.Text = "Nombres :";
        tb_EstudianteNombre.Attributes.Add("placeholder", "Nombres   Estudiante");
        REV_EstudianteNombre.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuApellido.Text = "Apellido :";
        tb_EstudianteApellido.Attributes.Add("placeholder", "Apellidos Estudiante ");
        REV_EstudianteApellido.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuDep.Text = "Lugar Nacimiento.:";
        L_AdminEditEstuFoto.Text = "Foto :";
        L_AdminEditEstuFechanac.Text = "Fecha Nacimiento:";
        fechanac.Attributes.Add("placeholder", "Fecha de Nacimiento");
        L_AdminEditEstuCorreo.Text = "Correo :";
        tb_EstudianteCorreo.Attributes.Add("placeholder", "Email");
        REV_EstudianteCorreo.ErrorMessage = "No se aceptan caracteres especiales";
        L_ADminEditEstuDir.Text = "Direccion :";
        tb_EstudianteDireccion.Attributes.Add("placeholder", "Dirección");
        REV_EstudianteDireccion.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuTel.Text = "Telefono :";
        tb_EstudianteTelefono.Attributes.Add("placeholder", "Teléfono");
        REV_EstudianteTelefono.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuUser.Text = "Usuario :";
        tb_EstudianteUsuario.Attributes.Add("placeholder", "Usuario");
        REV_EstudianteUsuario.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuContra.Text = "Contraseña:";
        tb_EstudianteContrasenia.Attributes.Add(" placeholder", "Contraseña");
        REV_EstudianteContrasenia.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminEditEstuEstado.Text = "Estado : ";
        //L_ErrorUsuario.Text;   
        btn_EstudianteAceptar.Text = "Aceptar";
        btn_EstudianteEditar.Text = "Editar";
        btn_EstudianteNuevo.Text = "Nuevo";

        L_ErrorEstudiante.Text = "Debe seleccionar una opcion";
        L_Error.Text = "Sin Registros";
        // script Usuario Editado con Exito
        // script Usuario Editado con Exito


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
        

    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       
    }

    protected void tb_AministradorEstudiantefechanac_TextChanged(object sender, EventArgs e)
    {
       
    }

    protected void btn_AdministradorAceptar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_EstudianteId.Text));


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

            LUser logica = new LUser();
            UUser usua = new UUser();
        string foto = cargarImagen();
            usua = logica.editarAdmin(
                tb_EstudianteNombre.Text,
                tb_EstudianteUsuario.Text,
                tb_EstudianteContrasenia.Text,
                tb_EstudianteCorreo.Text,
                tb_EstudianteApellido.Text,
                tb_EstudianteDireccion.Text,
                tb_EstudianteTelefono.Text,
                int.Parse(tb_EstudianteId.Text),
                DDL_Estado.SelectedValue,
                fechanac.Text,
                int.Parse(ddt_lugarnacimDep.SelectedValue),
                int.Parse(DDT_Ciudad.SelectedValue),
                Session.SessionID,
                foto,
                Session["fotosinedit"].ToString()
                );
        this.Page.Response.Write(usua.Notificacion);



        tb_EstudianteId.ReadOnly = usua.BotonTrue;
        tb_EstudianteNombre.ReadOnly = usua.BotonFalse;
        tb_EstudianteApellido.ReadOnly = usua.BotonFalse;
        tb_EstudianteCorreo.ReadOnly = usua.BotonFalse;
        tb_EstudianteDireccion.ReadOnly = usua.BotonFalse;
        tb_EstudianteTelefono.ReadOnly = usua.BotonFalse;
        tb_EstudianteUsuario.ReadOnly = usua.BotonFalse;
        tb_EstudianteContrasenia.ReadOnly = usua.BotonFalse;
        btn_EstudianteEditar.Visible = usua.BotonFalse;
        btn_EstudianteNuevo.Visible = usua.BotonTrue;
        btn_EstudianteAceptar.Visible = usua.BotonFalse;

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
