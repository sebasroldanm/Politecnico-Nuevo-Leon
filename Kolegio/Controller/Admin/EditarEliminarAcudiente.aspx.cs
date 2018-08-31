using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Admin_EditarEliminarAcudiente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            tb_AcudienteId.Text = (string)Session["documentoa"];
            tb_AcudienteNombre.ReadOnly = true;
            tb_AcudienteApellido.ReadOnly = true;
            tb_AcudienteCorreo.ReadOnly = true;
            tb_AcudienteDireccion.ReadOnly = true;
            tb_AcudienteTelefono.ReadOnly = true;
            tb_AcudienteUsuario.ReadOnly = true;
            tb_AcudienteContrasenia.ReadOnly = true;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
        
    }

    protected void btn_AdministradorEstudianteEditar_Click(object sender, EventArgs e)
    {

    }

    protected void btn_AcudienteAceptar_Click(object sender, EventArgs e)
    {
        EUser usua = new EUser();
        DaoUser dat = new DaoUser();

        usua.Documento = tb_AcudienteId.Text;

        DataTable registros = dat.obtenerUsuarioMod(usua);

        

        if (registros.Rows.Count > 0)
        {
            tb_AcudienteNombre.Text = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
            tb_AcudienteApellido.Text = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
            tb_AcudienteCorreo.Text = Convert.ToString(registros.Rows[0]["correo"].ToString());
            tb_AcudienteDireccion.Text = Convert.ToString(registros.Rows[0]["direccion"].ToString());
            tb_AcudienteTelefono.Text = Convert.ToString(registros.Rows[0]["telefono"].ToString());
            tb_AcudienteUsuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
            tb_AcudienteContrasenia.Text = Convert.ToString(registros.Rows[0]["clave"].ToString());
            fechanac.Text = Convert.ToString(registros.Rows[0]["fecha_nac"].ToString());
            ImagenEst.ImageUrl = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());

            Session["fotosinedit"] = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());



            if (Convert.ToString(registros.Rows[0]["estado"].ToString()) == "True")
            {
                DDL_Estado.SelectedValue = "Activo";
            }
            else
            {
                DDL_Estado.SelectedValue = "Inactivo";
            }

            ddt_lugarnacimDep.SelectedValue = Convert.ToString(registros.Rows[0]["dep_nacimiento"].ToString());

            DDT_Ciudad.DataBind();

            DDT_Ciudad.SelectedValue = Convert.ToString(registros.Rows[0]["ciu_nacimiento"].ToString());





            tb_AcudienteId.ReadOnly = true;
            tb_AcudienteNombre.ReadOnly = false;
            tb_AcudienteApellido.ReadOnly = false;
            tb_AcudienteCorreo.ReadOnly = false;
            tb_AcudienteDireccion.ReadOnly = false;
            tb_AcudienteTelefono.ReadOnly = false;
            tb_AcudienteUsuario.ReadOnly = false;
            tb_AcudienteContrasenia.ReadOnly = false;
            fechanac.ReadOnly = false;
            L_ErrorAdmin.Text = "";
            btn_AcudienteEditar.Visible = true;
            btn_AcudienteNuevo.Visible = true;
            btn_AcudienteAceptar.Visible = false;

        }
        else
        {

            L_ErrorAdmin.Text = "Sin Registros";

        }
    }

    protected void btn_AcudienteEditar_Click(object sender, EventArgs e)
    {
        {
            EUser Edusua = new EUser();
            DaoUser datos = new DaoUser();
            int rol = 4;

            if (ddt_lugarnacimDep.SelectedValue == "0" || DDT_Ciudad.SelectedValue == "0")
            {
                L_Error.Text = "Debe seleccionar una opcion";
            }




            else
            {


                String est;

                if (DDL_Estado.SelectedValue == "Activo")
                {
                    est = "true";
                }
                else
                {
                    est = "false";
                }



                if (FileUpload1.FileName == "")
                {



                    Edusua.Nombre = tb_AcudienteNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_AcudienteUsuario.Text;
                    Edusua.Clave = tb_AcudienteContrasenia.Text;
                    Edusua.Correo = tb_AcudienteCorreo.Text;
                    Edusua.Apellido = tb_AcudienteApellido.Text;
                    Edusua.Direccion = tb_AcudienteDireccion.Text;
                    Edusua.Telefono = tb_AcudienteTelefono.Text;
                    Edusua.Documento = tb_AcudienteId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = Session["fotosinedit"].ToString();



                    if (Edusua.Foto != null)
                    {
                        DataTable reg = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Acudiente Editado con Exito');</script>");
                        btn_AcudienteAceptar.Visible = false;

                    }

                }


                else
                {

                    Edusua.Nombre = tb_AcudienteNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_AcudienteUsuario.Text;
                    Edusua.Clave = tb_AcudienteContrasenia.Text;
                    Edusua.Correo = tb_AcudienteCorreo.Text;
                    Edusua.Apellido = tb_AcudienteApellido.Text;
                    Edusua.Direccion = tb_AcudienteDireccion.Text;
                    Edusua.Telefono = tb_AcudienteTelefono.Text;
                    Edusua.Documento = tb_AcudienteId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = cargarImagen();





                    if (Edusua.Foto != null)
                    {
                        DataTable reg = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Acudiente Editado con Exito');</script>");
                        btn_AcudienteAceptar.Visible = false;

                    }



                }



            }
        }

        tb_AcudienteId.ReadOnly = true;
        tb_AcudienteNombre.ReadOnly = false;
        tb_AcudienteApellido.ReadOnly = false;
        tb_AcudienteCorreo.ReadOnly = false;
        tb_AcudienteDireccion.ReadOnly = false;
        tb_AcudienteTelefono.ReadOnly = false;
        tb_AcudienteUsuario.ReadOnly = false;
        tb_AcudienteContrasenia.ReadOnly = false;
        btn_AcudienteEditar.Visible = false;
        btn_AcudienteNuevo.Visible = true;
        btn_AcudienteAceptar.Visible = false;
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


    protected String cargarImagen()
    {


        string sDia = Convert.ToString(DateTime.Now.Day);
        string sMes = Convert.ToString(DateTime.Now.Month);
        string sAgno = Convert.ToString(DateTime.Now.Year);
        string sHora = Convert.ToString(DateTime.Now.Hour);
        string sMinu = Convert.ToString(DateTime.Now.Minute);
        string sSeco = Convert.ToString(DateTime.Now.Second);
        string sFecha = sDia + sMes + sAgno + sHora + sMinu + sSeco;




        ClientScriptManager cm = this.ClientScript;
        String nombreArchivo = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
        String saveLocation = "";

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");



            return null;
        }

        saveLocation = Server.MapPath("~/FotosUser") + "/" + sFecha + sMinu + nombreArchivo;

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return null;
        }

        FileUpload1.PostedFile.SaveAs(saveLocation);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
    }



}