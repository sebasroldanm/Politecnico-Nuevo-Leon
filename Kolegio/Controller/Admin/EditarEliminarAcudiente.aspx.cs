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
        Response.Cache.SetNoStore();
        LLogin logica = new LLogin();
        UUser usua = new UUser();
        try
        {
    
            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documentoa"].ToString());
            Response.Redirect(usua.Url);
            tb_AcudienteId.Text = (string)Session["documentoa"];
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
        tb_AcudienteUsuario.ReadOnly = usua.L_Aceptar1;
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
            FileUpload1,
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
}