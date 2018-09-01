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
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            tb_EstudianteId.Text = (string)Session["documentoe"];

            tb_EstudianteNombre.ReadOnly = true;
            tb_EstudianteApellido.ReadOnly = true;
            tb_EstudianteCorreo.ReadOnly = true;
            tb_EstudianteDireccion.ReadOnly = true;
            tb_EstudianteTelefono.ReadOnly = true;
            tb_EstudianteUsuario.ReadOnly = true;
            tb_EstudianteContrasenia.ReadOnly = true;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");

        

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

        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();

        //usua.Documento = tb_EstudianteId.Text;

        //DataTable registros = dat.obtenerUsuarioMod(usua);

        //if (registros.Rows.Count > 0)
        //{
        //    tb_EstudianteNombre.Text = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
        //    tb_EstudianteApellido.Text = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
        //    tb_EstudianteCorreo.Text = Convert.ToString(registros.Rows[0]["correo"].ToString());
        //    tb_EstudianteDireccion.Text = Convert.ToString(registros.Rows[0]["direccion"].ToString());
        //    tb_EstudianteTelefono.Text = Convert.ToString(registros.Rows[0]["telefono"].ToString());
        //    tb_EstudianteUsuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //    tb_EstudianteContrasenia.Text = Convert.ToString(registros.Rows[0]["clave"].ToString());
        //    fechanac.Text= Convert.ToString(registros.Rows[0]["fecha_nac"].ToString());
        //    ImagenEst.ImageUrl = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());


        //    Session["fotosinedit"] = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());







        //    ddt_lugarnacimDep.SelectedValue = Convert.ToString(registros.Rows[0]["dep_nacimiento"].ToString());

        //    DDT_Ciudad.DataBind();

        //    DDT_Ciudad.SelectedValue = Convert.ToString(registros.Rows[0]["ciu_nacimiento"].ToString());

        //    string ddl = registros.Rows[0]["estado"].ToString();

        //    if (registros.Rows[0]["estado"].ToString() == "True")
        //    {
        //        DDL_Estado.SelectedValue = "Activo";
        //    }
        //    else
        //    {
        //        DDL_Estado.SelectedValue = "Inactivo";
        //    }

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
        tb_EstudianteUsuario.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteUsuario.Text = usua.UserName;
        tb_EstudianteContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_EstudianteContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        L_ErrorEstudiante.Text = "";

        btn_EstudianteEditar.Visible = usua.B_Botones1;
        btn_EstudianteNuevo.Visible = usua.B_Botones1;
        btn_EstudianteAceptar.Visible = usua.L_Aceptar1;
        //}    
        //else
        //{
        L_ErrorEstudiante.Text = usua.Mensaje;
        //}
    }

    protected void btn_AdministradorEdditar_Click(object sender, EventArgs e)
    {
        {
            EUser Edusua = new EUser();
            DaoUser datos = new DaoUser();
            int rol = 3;

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

                    Edusua.Nombre = tb_EstudianteNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_EstudianteUsuario.Text;
                    Edusua.Clave = tb_EstudianteContrasenia.Text;
                    Edusua.Correo = tb_EstudianteCorreo.Text;
                    Edusua.Apellido = tb_EstudianteApellido.Text;
                    Edusua.Direccion = tb_EstudianteDireccion.Text;
                    Edusua.Telefono = tb_EstudianteTelefono.Text;
                    Edusua.Documento = tb_EstudianteId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = Session["fotosinedit"].ToString();



                    if (Edusua.Foto != null)
                    {
                        DataTable registros = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Estudiante Editado con Exito');</script>");
                        btn_EstudianteAceptar.Visible = false;

                    }

                }
                else
                {

                    Edusua.Nombre = tb_EstudianteNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_EstudianteUsuario.Text;
                    Edusua.Clave = tb_EstudianteContrasenia.Text;
                    Edusua.Correo = tb_EstudianteCorreo.Text;
                    Edusua.Apellido = tb_EstudianteApellido.Text;
                    Edusua.Direccion = tb_EstudianteDireccion.Text;
                    Edusua.Telefono = tb_EstudianteTelefono.Text;
                    Edusua.Documento = tb_EstudianteId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = cargarImagen();
                    if (Edusua.Foto != null)
                    {
                        DataTable registros = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Estudiante Editado con Exito');</script>");
                        btn_EstudianteAceptar.Visible = false;

                    }
                }




            }
        }

        tb_EstudianteId.ReadOnly = true;
        tb_EstudianteNombre.ReadOnly = false;
        tb_EstudianteApellido.ReadOnly = false;
        tb_EstudianteCorreo.ReadOnly = false;
        tb_EstudianteDireccion.ReadOnly = false;
        tb_EstudianteTelefono.ReadOnly = false;
        tb_EstudianteUsuario.ReadOnly = false;
        tb_EstudianteContrasenia.ReadOnly = false;
        btn_EstudianteEditar.Visible = false;
        btn_EstudianteNuevo.Visible = true;
        btn_EstudianteAceptar.Visible = false;

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
        L_ErrorEstudiante.Text = "";
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
