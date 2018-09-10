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
using Newtonsoft.Json;
using System.Security.Cryptography;

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
                            user.Url = "~/View/Acudiente/AcudienteObservador.aspx";
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

        public void logicaGuardarSesion(int id, string ip, string mac, string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            //Mac datosConexion = new MAC();

            usua.UserId = id;
            usua.Ip = ip;
            usua.Mac = mac;
            usua.Session = sesion;

            dat.guardadoSession(usua);
        }

        public void cerrarSession(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Session = sesion;

            dat.cerrarSession(usua);
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
               string foto,
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
                usua.Foto = foto;


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
            string foto,
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
                usua.Foto = foto;
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
        }

        public UUser CargaFotoM(string fotoIO, string fotExten, string foto, string server)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();
            string sDia = Convert.ToString(DateTime.Now.Day);
            string sMes = Convert.ToString(DateTime.Now.Month);
            string sAgno = Convert.ToString(DateTime.Now.Year);
            string sHora = Convert.ToString(DateTime.Now.Hour);
            string sMinu = Convert.ToString(DateTime.Now.Minute);
            string sSeco = Convert.ToString(DateTime.Now.Second);
            string sFecha = sDia + sMes + sAgno + sHora + sMinu + sSeco;

            String nombreArchivo = fotoIO;
            String extension = fotExten;
            String saveLocation = "";
            string ext = extension;
            if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpg", true) == 0))
            {
                enc.Notificacion = "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>";
                return enc;
            }

            saveLocation = server + "/" + sFecha + sMinu + nombreArchivo;

            if (System.IO.File.Exists(saveLocation))
            {
                enc.Notificacion = "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>";
                return enc;
            }
            enc.Notificacion = "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>";
            enc.SaveLocation = saveLocation;
            enc.FotoCargada = "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
            return enc;
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

            }
            else
            {
                usua.MensajeAcudiente = "El Acudiente No se encuentra en la base de Datos";
            }
            return usua;
        }

        public UUser editarBuscarUser(int documento )
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
                    usua.Session = session;
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
                    usua.Session = session;
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

        public UUser profeMensaje()
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            DateTime fecha = DateTime.Now;
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            DataTable re = dat.obtenerAniodeCurso(año);
            usua.Año = re.Rows[0]["id_anio"].ToString();
            usua.BotonFalse = false;

            return usua;
        }

        public UUser verificarCorreoEstudoiante(
            string materia,
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
            if (materia == "0")
            {
                usua.Mensaje = "Debe seleccionar una opcion";
            }
            else
            {
                if (resultado.Rows.Count > 0)
                {
                    mensaje = mensaje + "<br><br>Atentamente: " + persona + " " + apePersona + "<br>Correo para responder: " + correo_l + "";
                    string cadena = mensaje;
                    DCorreoEnviar correo = new DCorreoEnviar();
                    correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                    usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                    usua.Url = "EstudianteProfesor.aspx";
                    usua.Mensaje = "";
                }
                else
                {
                    usua.Mensaje = "El correo digitado no existe";
                    usua.CDestinatario = "";
                }
            }
            return usua;
        }

        public UUser verificarCorreoContactenos(
            string nombres,
            string apellidos,
            string correo_l,
            string telefono,
            string mensaje
            )
        {
            DUser dat = new DUser();
            UUser usua = new UUser();

            string destinatario = "colegiorespuesta@gmail.com";
            string asunto = "**¡¡CONTACTENOS!!**";


            usua.Correo = destinatario;
            DataTable resultado = dat.verificarCorreo(usua);

            if (resultado.Rows.Count > 0)
            {
                mensaje = mensaje + "<br><br>Atentamente: " + nombres + "<br>" + apellidos + "<br>Correo para responder: " + correo_l + "<br>Telefono: " + telefono + "";
                string cadena = mensaje;
                DCorreoEnviar correo = new DCorreoEnviar();
                correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                usua.Url = "InicioNosotros.aspx";
            }
            else
            {
                usua.Notificacion = "<script language='JavaScript'>window.alert('Ha ocurrido un problema.');</script>";
            }
            return usua;
        }

        //public UUser acudienteBoletin(string anio, int idEstudiante)
        //{
        //    DUser dat = new DUser();
        //    UUser usua = new UUser();

        //    DataTable re = dat.obtenerAniodeCurso(anio);
        //    usua.Año = re.Rows[0]["id_anio"].ToString();
        //    usua.Id_estudiante = idEstudiante.ToString();

        //    DataTable registros = dat.obtenerCursoEst(usua);
        //    if (registros.Rows.Count > 0)
        //    {
        //        Session["anio"] = registros.Rows[0]["id_ancu"].ToString();
        //        Session["est"] = idEstudiante;
        //    }
        //    else
        //    {
        //        Session["anio"] = "0";
        //        Session["est"] = idEstudiante;
        //    }

        //    return usua;
        //}

        public UUser PL_AcudienteObservador(string estudiante)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            DateTime fecha = DateTime.Now;
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            DataTable re = datos.obtenerAniodeCurso(año);
            enc.Año = re.Rows[0]["id_anio"].ToString();
            enc.Id_estudiante = estudiante;

            DataTable registros = datos.obtenerCursoEst(enc);
            if (registros.Rows.Count > 0)
            {
                enc.SAño = registros.Rows[0]["id_ancu"].ToString();
                enc.SEstudiante = estudiante;
            }
            else
            {
                enc.SAño = "0";
                enc.SEstudiante = estudiante;
            }
            return enc;
        }

        public UUser PL_EstudianteVerNotas(string userId)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            DateTime fecha = DateTime.Now;
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            DataTable re = datos.obtenerAniodeCurso(año);
            enc.Año = re.Rows[0]["id_anio"].ToString();
            enc.Id_estudiante = userId;

            DataTable registros = datos.obtenerCursoEst(enc);
            if (registros.Rows.Count > 0)
            {
                enc.SAño = registros.Rows[0]["id_ancu"].ToString();
            }
            else
            {
                enc.SAño = "0";
            }
            return enc;
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
                        string Scorreo
                       )
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
                enc.Session = sesion;
              

   
            }

            DataTable resultado = datos.editarConfig(enc);

            return enc;
        }

        ///////////////////////CONFIGURACION DE PAGINA//////////////////////

        public UUser ModificarPaginaInicio(string nosotros, string mision, string vision, string session)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();

            usua.Inicio = nosotros;
            usua.Mision = mision;
            usua.Vision = vision;
            
            usua.Session = session;


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

        public UContrasenia ContraseñaBEnviar(string NuevamenteClave, string userId)
        {
            DUser datos = new DUser();
            UContrasenia usua = new UContrasenia();

            usua.UserId = int.Parse(userId);
            usua.Clave = NuevamenteClave;
            datos.actualziarContrasena(usua);
            return usua;
        }

        ////////////////////////FIN CONFIGURACION PAGINA//////////////////     

        public UUser recuperarContra(string userName)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            System.Data.DataTable validez = dat.generarToken(userName);
            if (int.Parse(validez.Rows[0]["id_usua"].ToString()) > 0)
            {
                UToken token = new UToken();
                //EUserToken token = new EUserToken();
                token.Id = int.Parse(validez.Rows[0]["id_usua"].ToString());
                token.Nombre = validez.Rows[0]["nombre_usua"].ToString();
                token.User_name = validez.Rows[0]["user_name"].ToString();
                token.Estado = int.Parse(validez.Rows[0]["state_t"].ToString());

                token.Correo = validez.Rows[0]["correo"].ToString();
                token.Fecha = DateTime.Now.ToFileTimeUtc();


                String userToken = encriptar(JsonConvert.SerializeObject(token));
                dat.almacenarToken(userToken, token.Id);

                DCorreo correo = new DCorreo();

                String mensaje = "Su link de acceso es: " + "http://localhost:58629/View/Contrasenia.aspx?" + userToken;
                correo.enviarCorreo(token.Correo, userToken, mensaje);

                usua.Mensaje = "Revisar su correo para recuperar contraseña";
            }
            else if (int.Parse(validez.Rows[0]["id_usua"].ToString()) == -2)
            {
                usua.Mensaje = "Ya extsite un link de recuperación, por favor verifique su correo.";
            }
            else
            {
                usua.Mensaje = "El usuario digitado no existe";
            }

            return usua;
        }

        private string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        public UUser cambiarContra(int QueryString, string Query, string session)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
           
            if (QueryString > 0)
            {
                DataTable info = dat.obtenerUsusarioToken(Query);

                if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");
                    usua.Notificacion = "<script language='JavaScript'>window.alert('El Token es invalido. Genere uno nuevo');</script>";
                    usua.Url = "~/View/Loggin.aspx";
                }
                else if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");
                    usua.Notificacion = "<script language='JavaScript'>window.alert('El Token esta vencido. Genere uno nuevo');</script>";
                    usua.Url = "~/View/Loggin.aspx";
                }
                else
                    usua.UserId = int.Parse((info.Rows[0][0].ToString()));
            }
            else
                //Response.Redirect("~/View/Loggin.aspx");
                usua.Url = "~/View/Loggin.aspx";

            return usua;
        }



    }
}
