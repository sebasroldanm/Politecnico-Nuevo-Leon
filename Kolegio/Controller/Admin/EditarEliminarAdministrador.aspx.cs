using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using Utilitarios;

public partial class View_Admin_EditarEliminarAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["userId"] != null)
        {
            tb_AministradorAdministradorId.Text = (string)Session["documento"];
            tb_AdministradorAdministradorNombre.ReadOnly = true;
            tb_AdministradorAdministradorApellido.ReadOnly = true;
            tb_AdministradorAdministradorCorreo.ReadOnly = true;
            tb_AdministradorAdministradorDireccion.ReadOnly = true;
            tb_AdministradorTelefono.ReadOnly = true;
            tb_AdministradorUsuario.ReadOnly = true;
            tb_AdministradorContrasenia.ReadOnly = true;
        }
        else
            Response.Redirect("AccesoDenegado.aspx");
        
    }

    protected void btn_AdministradorAceptar_Click(object sender, EventArgs e)
    {
        LUser logica = new LUser();
        UUser usua = new UUser();

        usua = logica.editarBuscarUser(int.Parse(tb_AministradorAdministradorId.Text));




        //EUser usua = new EUser();
        //DaoUser dat = new DaoUser();


        //usua.Documento = tb_AministradorAdministradorId.Text;

        //DataTable registros = dat.obtenerUsuarioMod(usua);

        //if (registros.Rows.Count > 0)
        //{
        //    tb_AdministradorAdministradorNombre.Text = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
        //    tb_AdministradorAdministradorApellido.Text = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
        //    tb_AdministradorAdministradorCorreo.Text = Convert.ToString(registros.Rows[0]["correo"].ToString());
        //    tb_AdministradorAdministradorDireccion.Text = Convert.ToString(registros.Rows[0]["direccion"].ToString());
        //    tb_AdministradorTelefono.Text = Convert.ToString(registros.Rows[0]["telefono"].ToString());
        //    tb_AdministradorUsuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //    tb_AdministradorContrasenia.Text = Convert.ToString(registros.Rows[0]["clave"].ToString());
        //    fechanac.Text = Convert.ToString(registros.Rows[0]["fecha_nac"].ToString());
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


        tb_AministradorAdministradorId.ReadOnly = usua.B_Botones1;
        tb_AdministradorAdministradorNombre.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorNombre.Text = usua.Nombre;
        tb_AdministradorAdministradorApellido.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorApellido.Text = usua.Apellido;
        tb_AdministradorAdministradorCorreo.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorCorreo.Text = usua.Correo;
        tb_AdministradorAdministradorDireccion.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorAdministradorDireccion.Text = usua.Direccion;
        tb_AdministradorTelefono.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorTelefono.Text = usua.Telefono;
        tb_AdministradorUsuario.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorUsuario.Text = usua.UserName;
        tb_AdministradorContrasenia.ReadOnly = usua.L_Aceptar1;
        tb_AdministradorContrasenia.Text = usua.Clave;
        ddt_lugarnacimDep.SelectedValue = usua.Departamento;
        DDT_Ciudad.DataBind();
        DDT_Ciudad.SelectedValue = usua.Ciudad;
        fechanac.ReadOnly = usua.L_Aceptar1;
        fechanac.Text = usua.fecha_nacimiento;
        ImagenEst.ImageUrl = usua.Foto;
        L_ErrorAdmin.Text = "";

        btn_AdministradorEditar.Visible = usua.B_Botones1;
        btn_AdministradorNuevo.Visible = usua.B_Botones1;
        btn_AdministradorAceptar.Visible = usua.L_Aceptar1;
        //}    
        //else
        //{
        L_ErrorAdmin.Text = usua.Mensaje;
        //}

    }

    protected void btn_AdministradorEdditar_Click(object sender, EventArgs e)
    {

        {
            EUser Edusua = new EUser();
            DaoUser datos = new DaoUser();
            int rol = 1;


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
                else {
                    est = "false";
                }


                if (tb_AdministradorFoto.FileName == "")
                {

                    Edusua.Nombre = tb_AdministradorAdministradorNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_AdministradorUsuario.Text;
                    Edusua.Clave = tb_AdministradorContrasenia.Text;
                    Edusua.Correo = tb_AdministradorAdministradorCorreo.Text;
                    Edusua.Apellido = tb_AdministradorAdministradorApellido.Text;
                    Edusua.Direccion = tb_AdministradorAdministradorDireccion.Text;
                    Edusua.Telefono = tb_AdministradorTelefono.Text;
                    Edusua.Documento = tb_AministradorAdministradorId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = Session["fotosinedit"].ToString();





                    if (Edusua.Foto != null)
                    {
                        DataTable registros = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Administrador Editado con Exito');</script>");
                        btn_AdministradorAceptar.Visible = false;

                    }

                }
                else {

                    Edusua.Nombre = tb_AdministradorAdministradorNombre.Text;
                    Edusua.Rol = Convert.ToString(rol);
                    Edusua.UserName = tb_AdministradorUsuario.Text;
                    Edusua.Clave = tb_AdministradorContrasenia.Text;
                    Edusua.Correo = tb_AdministradorAdministradorCorreo.Text;
                    Edusua.Apellido = tb_AdministradorAdministradorApellido.Text;
                    Edusua.Direccion = tb_AdministradorAdministradorDireccion.Text;
                    Edusua.Telefono = tb_AdministradorTelefono.Text;
                    Edusua.Documento = tb_AministradorAdministradorId.Text;
                    Edusua.Estado = est;
                    Edusua.fecha_nacimiento = fechanac.Text;
                    Edusua.Departamento = ddt_lugarnacimDep.SelectedValue;
                    Edusua.Ciudad = DDT_Ciudad.SelectedValue;
                    Edusua.Session = Session.SessionID;
                    Edusua.Foto = cargarImagen();





                    if (Edusua.Foto != null)
                    {
                        DataTable registros = datos.EditarUsuario(Edusua);
                        this.Page.Response.Write("<script language='JavaScript'>window.alert('Administrador Editado con Exito');</script>");
                        btn_AdministradorAceptar.Visible = false;

                    }
                }

                


            }

            


          
        }

        tb_AministradorAdministradorId.ReadOnly = true;
        tb_AdministradorAdministradorNombre.ReadOnly = false;
        tb_AdministradorAdministradorApellido.ReadOnly = false;
        tb_AdministradorAdministradorCorreo.ReadOnly = false;
        tb_AdministradorAdministradorDireccion.ReadOnly = false;
        tb_AdministradorTelefono.ReadOnly = false;
        tb_AdministradorUsuario.ReadOnly = false;
        tb_AdministradorContrasenia.ReadOnly = false;
        btn_AdministradorEditar.Visible = false;
        btn_AdministradorNuevo.Visible = true;
        btn_AdministradorAceptar.Visible = false;

    }

    protected void btn_AdministradorNuevo_Click(object sender, EventArgs e)
    {
        tb_AministradorAdministradorId.Enabled = true;
        tb_AdministradorAdministradorNombre.Text = "";
        tb_AdministradorUsuario.Text = "";
        tb_AdministradorContrasenia.Text = "";
        tb_AdministradorAdministradorCorreo.Text = "";
        tb_AdministradorAdministradorApellido.Text = "";
        tb_AdministradorAdministradorDireccion.Text = "";
        tb_AdministradorTelefono.Text = "";
        tb_AministradorAdministradorId.Text = "";
        fechanac.Text = "";

        L_ErrorAdmin.Text = "";

        L_Error.Text = "";

        ImagenEst.ImageUrl = "";

        tb_AdministradorAdministradorNombre.ReadOnly = true;
        tb_AdministradorAdministradorApellido.ReadOnly = true;
        tb_AdministradorAdministradorCorreo.ReadOnly = true;
        tb_AdministradorAdministradorDireccion.ReadOnly = true;
        tb_AdministradorTelefono.ReadOnly = true;
        tb_AdministradorUsuario.ReadOnly = true;
        tb_AdministradorContrasenia.ReadOnly = true;
        fechanac.ReadOnly = true;
        tb_AministradorAdministradorId.ReadOnly = false;
        
        tb_AministradorAdministradorId.Focus();
        btn_AdministradorEditar.Visible = false;
        btn_AdministradorNuevo.Visible = false;
        btn_AdministradorAceptar.Visible = true;

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
        String nombreArchivo = System.IO.Path.GetFileName(tb_AdministradorFoto.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(tb_AdministradorFoto.PostedFile.FileName);
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

        tb_AdministradorFoto.PostedFile.SaveAs(saveLocation);
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
    }




}