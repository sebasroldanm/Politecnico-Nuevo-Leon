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
            Session.SessionID
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

        usua = logica.validarUser(tb_DocenteUsuario.Text, tb_DocenteId.Text);
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