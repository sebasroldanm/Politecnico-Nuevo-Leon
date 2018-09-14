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
        Page.Title = "Agregar Acudiente";
        L_AdminAgreAcuTitulo.Text = "Agregar Acudiente";
        L_AdminAgreAcuDocumento.Text = "Número de Documento :";
        tb_AcudienteId.Attributes.Add("placeholder", "Número de Documento");
        REV_AcudienteId.ErrorMessage = "Digitar solo números";
        L_AdminAgreAcuNombre.Text = "Nombres :";
        tb_AcudienteNombre.Attributes.Add("placeholder", "Nombres   Acudiente");
        REV_AcudienteNombre.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAcuApellido.Text = "Apellido :";
        tb_AcudienteApellido.Attributes.Add("placeholder", "Apellidos Acudiente ");
        REV_AcudienteApellido.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAcuDep.Text = "Lugar Nacimiento.:";
        L_AdminAgreAcuFoto.Text = "Foto :";
        L_AdminAgreAcuFechanac.Text = "Fecha Nacimiento:";
        fechanac.Attributes.Add("placeholder", "Fecha de Nacimiento");
        L_AdminAgreAcuCorreo.Text = "Correo :";
        tb_AcudienteCorreo.Attributes.Add("placeholder", "Email");
        REV_AcudienteCorreo.ErrorMessage = "No se aceptan caracteres especiales";
        L_ADminAgreAcuDir.Text = "Direccion :";
        tb_AcudienteDireccion.Attributes.Add("placeholder", "Dirección");
        REV_AcudienteDireccion.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAcuTel.Text = "Telefono :";
        tb_AcudienteTelefono.Attributes.Add("placeholder", "Teléfono");
        REV_AcudienteTelefono.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAcuUser.Text = "Usuario :";
        tb_AcudienteUsuario.Attributes.Add("placeholder", "Usuario");
        REV_AcudienteUsuario.ErrorMessage = "No se aceptan caracteres especiales";
        L_AdminAgreAcuContra.Text = "Contraseña:";
        tb_AcudienteContrasenia.Attributes.Add(" placeholder","Contraseña");
        REV_AcudienteContrasenia.ErrorMessage = "No se aceptan caracteres especiales";
        btn_validar.Text = "Validar Usuario";

        //L_ErrorUsuario.Text;   
        btn_AcudienteAceptar.Text = "Agregar";
        btn_AcudienteNuevo.Text = "Nuevo";

        L_ErrorUsuario.Text = "Debe seleccionar una opcion";
        // script Usuario Insertado con Exito //Error al Seleccionar la Foto

        //
        L_ErrorUsuario.Text = "El Usuario ya existe";
        L_ErrorUsuario.Text = "Usuario Disponible";


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




    protected void btn_AcudienteAceptar_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();
        string foto = cargarImagen();
        usua = logica.AgregarAdmin(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_AcudienteNombre.Text,
            tb_AcudienteApellido.Text,
            tb_AcudienteDireccion.Text,
            tb_AcudienteTelefono.Text,
            tb_AcudienteContrasenia.Text,
            tb_AcudienteCorreo.Text,
            foto,
            int.Parse(tb_AcudienteId.Text),
            tb_AcudienteUsuario.Text,
            4,
            fechanac.Text,
            Session.SessionID
            );

        L_ErrorUsuario.Text = usua.Mensaje;
        btn_AcudienteAceptar.Visible = false;
        this.Page.Response.Write(usua.Notificacion);

        
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

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.validarUser(tb_AcudienteUsuario.Text, tb_AcudienteId.Text);
        L_ErrorUsuario.Text = usua.Mensaje;

        btn_AcudienteAceptar.Visible = usua.L_Aceptar1;
        btn_AcudienteNuevo.Visible = usua.L_Aceptar1;

        tb_AcudienteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_AcudienteId.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = usua.B_Botones1;

    }

    protected string cargarImagen()
    {
        LUser logic = new LUser();
        UUser enc = new UUser();
        enc = logic.CargaFotoM(System.IO.Path.GetFileName(tb_Foto.PostedFile.FileName), System.IO.Path.GetExtension(tb_Foto.PostedFile.FileName), tb_Foto.ToString(), Server.MapPath("~/FotosUser"));
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