using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;
using System.Data;

namespace Logica
{
    public class LUser : System.Web.UI.Page
    {
        public UUser loggear(string userName, string clave)
        {
            UUser user = new UUser();
            DUser datos = new DUser();

            user.UserName = userName;
            user.Clave = clave;

            user.Mensaje = "";

            DataTable resultado = datos.loggin(user);

            if (resultado.Rows.Count > 0)
            {
                user.SUserId = resultado.Rows[0]["id_usua"].ToString();
                user.SUserName = resultado.Rows[0]["user_name"].ToString();
                user.SNombre = resultado.Rows[0]["nombre_usua"].ToString();
                user.SApellido = resultado.Rows[0]["apellido_usua"].ToString();
                user.SClave = resultado.Rows[0]["clave"].ToString();
                user.SCorreo = resultado.Rows[0]["correo"].ToString();
                user.SDocumento = resultado.Rows[0]["num_documento"].ToString();
                user.SFoto = resultado.Rows[0]["foto_usua"].ToString();

                if ((resultado.Rows[0]["estado"].ToString()) == "True")
                {
                    user.Mensaje = " ";
                    switch (int.Parse(resultado.Rows[0]["rol_id"].ToString()))
                    {
                        case 1:
                            //Response.Redirect("Admin/AgregarAdministrador.aspx");
                            user.Url = "~/View/Admin/AgregarAdministrador.aspx";
                            break;

                        case 2:
                            //Response.Redirect("Profesor/ProfesorSubirNota.aspx");
                            user.Url = "~/View/Profesor/ProfesorSubirNota.aspx";
                            break;

                        case 3:
                            //Response.Redirect("Estudiante/EstudianteHorario.aspx");
                            user.Url = "~/View/Estudiante/EstudianteHorario.aspx";
                            break;

                        case 4:
                            //Response.Redirect("Acudiente/AcudienteBoletin.aspx");
                            user.Url = "~/View/Acudiente/AcudienteBoletin.aspx";
                            break;

                        default:
                            //Response.Redirect("Loggin.aspx");
                            user.Url = "~/View/Loggin.aspx";
                            break;
                    }

                }
                else
                {
                    //L_Error.Text = "Usuario Se Encuentra Inactivo";
                    user.Mensaje = "Usuario Se Encuentra Inactivo";
                    //Session["userId"] = null;
                    user.SUserId = null;
                    //user.Url = "~/View/Loggin.aspx";
                }
            }
            else
            {
                //L_Error.Text = "Usuario Y/o Clave Incorrecto";
                user.Mensaje = "Usuario Y/o Clave Incorrecto";
                //Session["userId"] = null;
                user.SUserId = null;
                user.Url = "~/View/Loggin.aspx";
            }
            return user;
        }

        public UUser AgregarAdmin(
              int departamento,
              int ciudad,
              string nombre,
              string apellido,
              string direccion,
              string telefono,
              string clave,
              string correo,
              FileUpload foto,
              int documento,
              string usuario,
              int rol,
              string fechanac,
              string session)
        {



            UUser usua = new UUser();
            DUser dat = new DUser();


            int dep;
            dep = (departamento);

            int ciu;
            ciu = (ciudad);
            usua.Mensaje = "";
            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = "Debe seleccionar una opcion";
            }
            else
            {
                usua.Nombre = nombre;
                usua.Rol = Convert.ToString(rol);
                usua.UserName = usuario;
                usua.Clave = clave;
                usua.Correo = correo;
                usua.Apellido = apellido;
                usua.Direccion = direccion;
                usua.Telefono = telefono;
                usua.Documento = documento.ToString();
                usua.fecha_nacimiento = fechanac;
                usua.Departamento = Convert.ToString(dep);
                usua.Ciudad = Convert.ToString(ciu);
                usua.Session = session;
                usua.Foto = "jasdfvjasdbfsjadb.png";//cargarImagen(foto);


                if (usua.Foto != null)
                {
                    dat.insertarUsuarios(usua);
                    usua.Notificacion = "<script language='JavaScript'>window.alert('Administrador Insertado con Exito');</script>";

                    usua.L_Aceptar1 = false;

                }
            }
            return usua;
        }

        public UUser validarUser(string usuario, string documento)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.UserName = usuario;
            usua.Documento = documento.ToString();

            DataTable registros = dat.validar_usuarioadmin(usua);

            if (registros.Rows.Count > 0)
            {

                //tb_Vusuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
                //tb_Vdocumento.Text = Convert.ToString(registros.Rows[0]["num_documento"].ToString());
                usua.Mensaje = "El Usuario ya existe";
                usua.L_Aceptar1 = false;
                usua.B_Botones1 = true;

            }
            else
            {
                //L_ErrorUsuario.Text = "";
                usua.Mensaje = "Usuario Disponible";
                //btn_DocenteAceptar.Visible = true;
                //btn_DocenteNuevo.Visible = true;
                //btn_validar.Visible = false;
                //tb_DocenteUsuario.ReadOnly = true;
                //tb_DocenteId.ReadOnly = true;
                usua.L_Aceptar1 = true;
                usua.B_Botones1 = false;

            }

            return usua;
        }



        protected String cargarImagen(FileUpload foto)
        {
            ClientScriptManager cm = this.ClientScript;
            String nombreArchivo = System.IO.Path.GetFileName(foto.PostedFile.FileName);
            String extension = System.IO.Path.GetExtension(foto.PostedFile.FileName);
            String saveLocation = "";

            if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
                //btnigm_calendar.Visible = true;
                return null;
            }

            saveLocation = Server.MapPath("~/FotosUser") + "/" + nombreArchivo;

            if (System.IO.File.Exists(saveLocation))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
                return null;
            }

            foto.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

            return "~/FotosUser" + "/" + nombreArchivo;
        }
    }
}
