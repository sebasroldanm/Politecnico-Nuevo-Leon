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
        try
        {
            LLogin logica = new LLogin();
            UUser usua = new UUser();

            usua = logica.logEditarAcudienteAdmin(Session["userId"].ToString(), Session["documentoa"].ToString());
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

        }
    }
    protected void btn_DocenteAceptar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_DocenteId.Text));
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
        tb_DocenteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_DocenteUsuario.Text = usua.UserName;
        tb_DocenteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_DocenteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        L_ErrorAdmin.Text = "";

        btn_DocenteEditar.Visible = usua.B_Botones1;
        btn_DocenteNuevo.Visible = usua.B_Botones1;
        btn_DocenteAceptar.Visible = usua.L_Aceptar1;
        L_ErrorAdmin.Text = usua.Mensaje;

    }

    protected void btn_DocenteEditar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarAdmin(
            tb_DocenteNombre.Text,
            tb_DocenteUsuario.Text,
            tb_DocenteContrasenia.Text,
            tb_DocenteCorreo.Text,
            tb_DocenteApellido.Text,
            tb_DocenteDireccion.Text,
            tb_DocenteTelefono.Text,
            int.Parse(tb_DocenteId.Text),
            DDL_Estado.SelectedValue,
            fechanac.Text,
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            Session.SessionID,
            FileUpload1,
            Session["fotosinedit"].ToString()
            );

        this.Page.Response.Write(usua.Notificacion);

        tb_DocenteId.ReadOnly = usua.BotonTrue;
        tb_DocenteNombre.ReadOnly = usua.BotonFalse;
        tb_DocenteApellido.ReadOnly = usua.BotonFalse;
        tb_DocenteCorreo.ReadOnly = usua.BotonFalse;
        tb_DocenteDireccion.ReadOnly = usua.BotonFalse;
        tb_DocenteTelefono.ReadOnly = usua.BotonFalse;
        tb_DocenteUsuario.ReadOnly = usua.BotonFalse;
        tb_DocenteContrasenia.ReadOnly = usua.BotonFalse;
        btn_DocenteEditar.Visible = usua.BotonFalse;
        btn_DocenteNuevo.Visible = usua.BotonTrue;
        btn_DocenteAceptar.Visible = usua.BotonFalse;

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


}