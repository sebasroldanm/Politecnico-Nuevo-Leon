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
            fechanac.ReadOnly = usua.BotonTrue;
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
            Convert.ToInt32(Session["id_acu"])
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

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.validarUser(tb_EstudianteUsuario.Text, tb_EstudianteId.Text);
        L_ErrorUser.Text = usua.Mensaje;
        btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        btn_EstudianteNuevo.Visible = usua.L_Aceptar1;
        tb_EstudianteId.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteUsuario.ReadOnly = usua.L_Aceptar1;
        btn_validar.Visible = false;

    }

    protected void btn_buscarAcudiente_Click(object sender, EventArgs e)
    {

        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.buscarAcudiete(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_AcudienteId.Text);

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