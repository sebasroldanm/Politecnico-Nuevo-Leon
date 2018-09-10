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