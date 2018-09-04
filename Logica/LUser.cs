using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Utilitarios;
using System.Data;
using System.IO;

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
                //user.Url = "~/View/Loggin.aspx";
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
                usua.Foto = cargarImagen(foto);


                if (usua.Foto != null)
                {
                    dat.insertarUsuarios(usua);
                    usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.B_Botones1 = true;
                    usua.L_Aceptar1 = false;

                }
                else
                {
                    usua.Notificacion = "<script language='JavaScript'>window.alert('Error al Seleccionar la Foto');</script>";
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

        public UUser agregarEstudiante(
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
            string session,
            int id_acu
            )
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
                usua.Foto = cargarImagen(foto);
                usua.id_Acudiente = Convert.ToString(id_acu);

                if (usua.Foto != null)
                {
                    dat.insertarEstudiante(usua);
                    usua.Notificacion = ("<script language='JavaScript'>window.alert('Estudiante Insertado con Exito');</script>");

                    usua.L_Aceptar1 = false;
                    usua.B_Botones1 = true;

                }
            }
            return usua;
        }

        protected String cargarImagen(FileUpload foto)
        {

            string sDia = Convert.ToString(DateTime.Now.Day);
            string sMes = Convert.ToString(DateTime.Now.Month);
            string sAgno = Convert.ToString(DateTime.Now.Year);
            string sHora = Convert.ToString(DateTime.Now.Hour);
            string sMinu = Convert.ToString(DateTime.Now.Minute);
            string sSeco = Convert.ToString(DateTime.Now.Second);
            string sFecha = sDia + sMes + sAgno + sHora + sMinu + sSeco;

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

            saveLocation = Server.MapPath("~/FotosUser") + "/" + sFecha + sMinu + nombreArchivo;

            if (System.IO.File.Exists(saveLocation))
            {
                cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
                return null;
            }

            foto.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

            return "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;

        //ClientScriptManager cm = this.ClientScript;
        //String nombreArchivo = System.IO.Path.GetFileName(foto.PostedFile.FileName);
        //String extension = System.IO.Path.GetExtension(foto.PostedFile.FileName);
        //String saveLocation = "";

        //if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
        //{
        //    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
        //    //btnigm_calendar.Visible = true;
        //    return null;
        //}

        //saveLocation = Server.MapPath("~/FotosUser") + "/" + nombreArchivo;

        //if (System.IO.File.Exists(saveLocation))
        //{
        //    cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
        //    return null;
        //}

        //foto.PostedFile.SaveAs(saveLocation);
        //cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");

        //return "~/FotosUser" + "/" + nombreArchivo;
        }

        public UUser buscarAcudiete(int departamento, int ciudad, String documento)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Documento = documento.ToString();

            DataTable registros = dat.obtenerAcudiente(usua);

            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = "Debe seleccionar una opcion";
            }

            if (registros.Rows.Count > 0)
            {
                usua.Nombre = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
                usua.Apellido = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
                usua.id_Acudiente = Convert.ToString(registros.Rows[0]["id_usua"].ToString());

                usua.L_Aceptar1 = true;
                usua.Notificacion = ("<script language='JavaScript'>window.alert('Acudiente Seleccionado');</script>");
                //tb_AcudienteNombre.ReadOnly = true;
                //tb_AcudienteId.ReadOnly = true;
                //tb_AcudienteApellido.ReadOnly = true;
                //L_ErrorAcudiente.Text = "";

                //tb_EstudianteNombre.ReadOnly = false;
                //tb_EstudianteApellido.ReadOnly = false;
                //tb_EstudianteId.ReadOnly = false;
                //tb_EstudianteDireccion.ReadOnly = false;
                //tb_EstudianteTelefono.ReadOnly = false;
                //tb_EstudianteUsuario.ReadOnly = false;
                //tb_EstudianteContrasenia.ReadOnly = false;
                //btnigm_calendar.Visible = true;
                //tb_EstudianteCorreo.ReadOnly = false;
            }
            else
            {
                usua.MensajeAcudiente = "El Acudiente No se encuentra en la base de Datos";
            }
            return usua;
        }

        public UUser editarBuscarUser(int documento)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Documento = documento.ToString();

            DataTable registros = dat.obtenerUsuarioMod(usua);

            if (registros.Rows.Count > 0)
            {
                usua.Nombre = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
                usua.Apellido = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
                usua.Correo = Convert.ToString(registros.Rows[0]["correo"].ToString());
                usua.Direccion = Convert.ToString(registros.Rows[0]["direccion"].ToString());
                usua.Telefono = Convert.ToString(registros.Rows[0]["telefono"].ToString());
                usua.UserName = Convert.ToString(registros.Rows[0]["user_name"].ToString());
                usua.Clave = Convert.ToString(registros.Rows[0]["clave"].ToString());
                usua.fecha_nacimiento = Convert.ToString(registros.Rows[0]["fecha_nac"].ToString());
                usua.Foto = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());

                Session["fotosinedit"] = Convert.ToString(registros.Rows[0]["foto_usua"].ToString());

                usua.Departamento = Convert.ToString(registros.Rows[0]["dep_nacimiento"].ToString());

                //DDT_Ciudad.DataBind();

                usua.Ciudad = Convert.ToString(registros.Rows[0]["ciu_nacimiento"].ToString());

                string ddl = registros.Rows[0]["estado"].ToString();

                if (registros.Rows[0]["estado"].ToString() == "True")
                {
                    usua.Estado = "Activo";
                }
                else
                {
                    usua.Estado = "Inactivo";
                }
                usua.L_Aceptar1 = false;
                usua.B_Botones1 = true;
            }
            else
            {
                usua.Mensaje = "Sin Registros";
            }

            return usua;
        }

        public UUser editarAdmin(
            string nombre,
            string userName,
            string clave,
            string correo,
            string apellido,
            string direccion,
            string telefono,
            int documento,
            string estado,
            string fechanac,
            int departamento,
            int ciudad,
            string session,
            FileUpload fotoup,
            string foto
            )
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            int rol = 1;


            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = "Debe seleccionar una opcion";
            }
            else
            {
                String est;

                if (estado == "Activo")
                {
                    est = "true";
                }
                else
                {
                    est = "false";
                }


                if (fotoup.FileName == "")
                {

                    usua.Nombre = nombre;
                    usua.Rol = rol.ToString();
                    usua.UserName = userName;
                    usua.Clave = clave;
                    usua.Correo = correo;
                    usua.Apellido = apellido;
                    usua.Direccion = direccion;
                    usua.Telefono = telefono;
                    usua.Documento = documento.ToString();
                    usua.Estado = est;
                    usua.fecha_nacimiento = fechanac;
                    usua.Departamento = departamento.ToString();
                    usua.Ciudad = ciudad.ToString();
                    usua.Session = Session.SessionID;
                    usua.Foto = foto;

                    if (foto != null)
                    {
                        DataTable registros = dat.EditarUsuario(usua);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }

                }
                else
                {

                    usua.Nombre = nombre;
                    usua.Rol = rol.ToString();
                    usua.UserName = userName;
                    usua.Clave = clave;
                    usua.Correo = correo;
                    usua.Apellido = apellido;
                    usua.Direccion = direccion;
                    usua.Telefono = telefono;
                    usua.Documento = documento.ToString();
                    usua.Estado = est;
                    usua.fecha_nacimiento = fechanac;
                    usua.Departamento = departamento.ToString();
                    usua.Ciudad = ciudad.ToString();
                    usua.Session = Session.SessionID;
                    usua.Foto = cargarImagen(fotoup);
                    
                    if (usua.Foto != null)
                    {
                        DataTable registros = dat.EditarUsuario(usua);
                        usua.Notificacion = " <script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }
                
            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;
        }



        public void reporteAdmin(DataTable informacion)
        {
            DUser administrador = new DUser();
            DataRow fila;
            DataTable Intermedio = administrador.obtenerAdministradores();
            for (int i = 0; i < Intermedio.Rows.Count; i++)
            {

                fila = informacion.NewRow();
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Telefono"] = Intermedio.Rows[i]["telefono"].ToString();
                fila["Correo"] = Intermedio.Rows[i]["correo"].ToString();
                fila["Foto"] = streamFile(Intermedio.Rows[i]["foto_usua"].ToString());

                informacion.Rows.Add(fila);
            }
        }

        public void reporteAcudiente(DataTable informacion)
        {
            DUser administrador = new DUser();
            DataRow fila;
            DataTable Intermedio = administrador.obteneracudientes();
            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Telefono"] = Intermedio.Rows[i]["telefono"].ToString();
                fila["Correo"] = Intermedio.Rows[i]["correo"].ToString();
                informacion.Rows.Add(fila);
            }
        }

        public void reporteProfe(DataTable informacion)
        {
            DUser profe = new DUser();
            DataRow fila;
            DataTable Intermedio = profe.obtenerprofesores();
            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Telefono"] = Intermedio.Rows[i]["telefono"].ToString();
                fila["Correo"] = Intermedio.Rows[i]["correo"].ToString();
                fila["Foto"] = streamFile(Intermedio.Rows[i]["foto_usua"].ToString());
                informacion.Rows.Add(fila);
            }
        }

        public void reporteEstudiante(DataTable informacion, int curso)
        {
            DUser estudiante = new DUser();
            DataRow fila;

            DataTable Intermedio = estudiante.gEstudiante(curso);


            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                informacion.Rows.Add(fila);
            }
        }

        public void reporteDiploma(DataTable informacion, UUser documento)
        {
            DUser diploma = new DUser();
            DataRow fila;

            DataTable Intermedio = diploma.obtenerUsuarioMod(documento);
            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Foto"] = streamFile(Intermedio.Rows[i]["foto_usua"].ToString());
                informacion.Rows.Add(fila);
            }
        }

        public void reporteCertificadoTrabajoProfe(DataTable informacion, string documento)
        {
            DUser estudiante = new DUser();
            DataRow fila;

            DataTable Intermedio = estudiante.obtenerCertificadoProf(documento.ToString());

            for (int i = 0; i < Intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                informacion.Rows.Add(fila);
            }
        }

        public void reporteCertidicadoEstudiante(DataTable informacion, string docuemtno)
        {
            DUser estudiante = new DUser();
            DataRow fila;

            DataTable Intermedio = estudiante.obtenerCertificadoEst(docuemtno.ToString());

            for (int i = 0; i < Intermedio.Rows.Count; i++)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                informacion.Rows.Add(fila);
            }
        }

        private byte[] streamFile(string filename)
        {
            FileStream fs;

            if (!filename.Equals(""))
            {
                fs = new FileStream(Server.MapPath(filename), FileMode.Open, FileAccess.Read);
            }

            else
            {
                fs = new FileStream(Server.MapPath("~/FotosUser/Useruser.png"), FileMode.Open, FileAccess.Read);

            }


            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }

        public UUser verificarCorreo(
            string userId,
            string persona,
            string apePersona,
            string correo_l,
            string destinatario,
            string asunto,
            string mensaje
            )
        {
            DUser dat = new DUser();
            UUser usua = new UUser();

            usua.Correo = destinatario;
            DataTable resultado = dat.verificarCorreo(usua);

            if (resultado.Rows.Count > 0)
            {
                mensaje = mensaje + "<br><br>Atentamente: " + persona + " " + apePersona + "<br>Correo para responder: " + correo_l + "";
                string cadena = mensaje;
                DCorreoEnviar correo = new DCorreoEnviar();
                correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                usua.Url = "AdministradorMensaje.aspx";
                usua.Mensaje = "";
            }
            else
            {
                usua.Mensaje = "El correo digitado no existe";
                usua.CDestinatario = "";
            }


            return usua;
        }

        public UUser acudienteBoletin(string anio, int idEstudiante)
        {
            DUser dat = new DUser();
            UUser usua = new UUser();

            DataTable re = dat.obtenerAniodeCurso(anio);
            usua.Año = re.Rows[0]["id_anio"].ToString();
            usua.Id_estudiante = idEstudiante.ToString();

            DataTable registros = dat.obtenerCursoEst(usua);
            if (registros.Rows.Count > 0)
            {
                Session["anio"] = registros.Rows[0]["id_ancu"].ToString();
                Session["est"] = idEstudiante;
            }
            else
            {
                Session["anio"] = "0";
                Session["est"] = idEstudiante;
            }

            return usua;
        }

        public UUser acudienteObservador(string anio, int estudiante)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            DataTable re = dat.obtenerAniodeCurso(anio);
            usua.Año = re.Rows[0]["id_anio"].ToString();
            usua.Id_estudiante = estudiante.ToString();

            DataTable registros = dat.obtenerCursoEst(usua);
            if (registros.Rows.Count > 0)
            {
                Session["anio"] = registros.Rows[0]["id_ancu"].ToString();
                Session["est"] = estudiante.ToString();
            }
            else
            {
                Session["anio"] = "0";
                Session["est"] = estudiante.ToString();
            }

            return usua;
        }

        public UUser ModifConfiguracion(
                        FileUpload fotoName,
                        string userName,
                        string contraseña,
                        string correo,
                        string sesion,
                        string SuserId,
                        string Sfoto,
                        string Suser,
                        string Sclave,
                        string Scorreo)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();

            String foto = System.IO.Path.GetFileName(fotoName.PostedFile.FileName);

            if (fotoName.FileName == "")
            {
                enc.Id_estudiante = SuserId;
                enc.UserName = userName;
                enc.Clave = contraseña;
                enc.Correo = correo;
                enc.Session = sesion;
                enc.Foto = Sfoto;

            }
            else
            {
                foto = "~/FotosUser/" + fotoName.FileName;
                enc.Id_estudiante = SuserId;
                enc.UserName = userName;
                enc.Clave = contraseña;
                enc.Correo = correo;
                enc.Foto = cargarImagen(fotoName);
                enc.Session = Session.SessionID;
            }

            DataTable resultado = datos.editarConfig(enc);

            return enc;
        }

        ///////////////////////CONFIGURACION DE PAGINA//////////////////////

        public UUser ModificarPaginaInicio(string nosotros, string mision, string vision, string sesion)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Inicio = nosotros;
            usua.Mision = mision;
            usua.Vision = vision;
            usua.Session = Session.SessionID;

            DataTable registros = dat.editarInicio(usua);
            usua.Notificacion = "<script language='JavaScript'>window.alert('Datos Modificados');</script>";
            return usua;



        }

        public UUser TraerDatosPagina()
        {

            UUser usua = new UUser();
            DUser dat = new DUser();





            DataTable registros = dat.incio();

            if (registros.Rows.Count > 0)
            {
                usua.Mision = Convert.ToString(registros.Rows[0]["mision_inicio"].ToString());
                usua.Vision = Convert.ToString(registros.Rows[0]["vision_inicio"].ToString());
                usua.Nosotros = Convert.ToString(registros.Rows[0]["inicio_cont"].ToString());

            }

            return usua;

        }

        public UUser insertarfechafin(string fechater)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Año = fechater;
            dat.editaFinaño(usua);
            bool ok = true;
            dat.editaBool(ok);
            usua.Notificacion = "<script language='JavaScript'>window.alert('Insertado con Exito');</script>";

            return usua;
        }


        ////////////////////////FIN CONFIGURACION PAGINA//////////////////     




    }
}
