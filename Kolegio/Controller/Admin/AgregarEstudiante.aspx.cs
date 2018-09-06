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
            Response.Redirect(usua.Url);
            fechanac.ReadOnly = usua.BotonTrue;
            btnigm_calendar.Visible = usua.BotonFalse;
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

        usua = logica.agregarEstudiante(
            int.Parse(ddt_lugarnacimDep.SelectedValue),
            int.Parse(DDT_Ciudad.SelectedValue),
            tb_EstudianteNombre.Text,
            tb_EstudianteApellido.Text,
            tb_EstudianteDireccion.Text,
            tb_EstudianteTelefono.Text,
            tb_EstudianteContrasenia.Text,
            tb_EstudianteCorreo.Text,
            tb_Foto,
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


        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();
        //int rol = 3;
        //int ciu;
        //int dep;

        //ciu = int.Parse(DDT_Ciudad.SelectedValue);
        //dep = int.Parse(ddt_lugarnacimDep.SelectedValue);


        //usua.Nombre = tb_EstudianteNombre.Text;
        //usua.Apellido = tb_EstudianteApellido.Text;
        //usua.Rol = Convert.ToString(rol);
        //usua.UserName = tb_EstudianteUsuario.Text;
        //usua.Clave = tb_EstudianteContrasenia.Text;
        //usua.Correo = tb_EstudianteCorreo.Text;
        //usua.Direccion = tb_EstudianteDireccion.Text;
        //usua.Telefono = tb_EstudianteTelefono.Text;
        //usua.Documento = tb_EstudianteId.Text;
        //usua.fecha_nacimiento = fechanac.Text;
        //usua.Departamento = Convert.ToString(dep);
        //usua.Ciudad = Convert.ToString(ciu);
        //usua.Foto = cargarImagen();
        //usua.id_Acudiente = tb_id_estacu.Text;
        //usua.Session = Session.SessionID;

        //if (usua.Foto != null)
        //{
        //    dat.insertarEstudiante(usua);
        //    this.Page.Response.Write("<script language='JavaScript'>window.alert('Estudiante Insertado con Exito');</script>");

        //    btn_EstudianteAceptar.Visible = false;

        //}

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


        //    EUser usua = new EUser();
        //    DaoUser dat = new DaoUser();

        //    usua.UserName = tb_EstudianteUsuario.Text;
        //    usua.Documento = tb_EstudianteId.Text;

        //    DataTable registros = dat.validar_usuarioadmin(usua);

        //    if (registros.Rows.Count > 0)
        //    {
        //        tb_Vusuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //        tb_Vdocumento.Text = Convert.ToString(registros.Rows[0]["num_documento"].ToString());
        //        L_ErrorUsuario.Text = "El Usuario ya existe";
        //    }
        //    else
        //    {
        //        L_ErrorUsuario.Text = "Usuario Disponible";
        //        btn_EstudianteAceptar.Visible = true;
        //        btn_EstudianteNuevo.Visible = true;
        //        btn_validar.Visible = false;
        //        tb_EstudianteUsuario.ReadOnly = true;
        //        tb_EstudianteId.ReadOnly = true;

        //    }
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

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();

        //usua.Documento = tb_AcudienteId.Text;

        //DataTable registros = dat.obtenerAcudiente(usua);

        //if (registros.Rows.Count > 0)
        //{
        //    tb_AcudienteNombre.Text = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
        //    tb_AcudienteApellido.Text = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
        //    tb_id_estacu.Text = Convert.ToString(registros.Rows[0]["id_usua"].ToString());

        //    tb_AcudienteNombre.ReadOnly = true;
        //    tb_AcudienteId.ReadOnly = true;
        //    tb_AcudienteApellido.ReadOnly = true;
        //    L_ErrorAcudiente.Text = "";

        //    tb_EstudianteNombre.ReadOnly = false;
        //    tb_EstudianteApellido.ReadOnly = false;
        //    tb_EstudianteId.ReadOnly = false;
        //    tb_EstudianteDireccion.ReadOnly = false;
        //    tb_EstudianteTelefono.ReadOnly = false;
        //    tb_EstudianteUsuario.ReadOnly = false;
        //    tb_EstudianteContrasenia.ReadOnly = false;
        //    btnigm_calendar.Visible = true;
        //    tb_EstudianteCorreo.ReadOnly = false;
        //}
        //else
        //{
        //    L_ErrorAcudiente.Text = "El Acudiente No se encuentra en la base de Datos";
        //}
    }


}