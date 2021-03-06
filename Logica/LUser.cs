﻿using System;
using System.Text;
using Datos;
using Utilitarios;
using Logica;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography;


namespace Logica 
{
    public class LUser
    {
        public UUser loggear(string userName, string clave, int selIdioma, Boolean bot)
        {
            UUser user = new UUser();
            DUser datos = new DUser();

            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 40;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);
            
            user.UserName = userName;
            user.Clave = clave;

            user.Mensaje = "";

            DataTable resultado = datos.loggin(user);

            if(bot == true)
            {
                DataTable fechasesion = datos.Capturafechaintentosesion(userName);

                if (int.Parse(fechasesion.Rows[0][0].ToString()) == 0)
                {


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
                            DataTable valida = datos.evaluaSesiones(userName);
                            int idUsuario = int.Parse(valida.Rows[0][0].ToString());
                            if (idUsuario == 1)
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
                                user.MensajeIntentoErroneos = "<script language='JavaScript'>window.alert('Ha exedido el numero de Sesiones Permitidas');</script>";

                            }
                            datos.LimpiaIntentosErroneos(userName);


                        }
                        else
                        {
                            System.Data.DataTable validez = datos.generarToken(userName);
                            if (int.Parse(validez.Rows[0]["id_usua"].ToString()) > 0)
                            {

                                //suma contador id_usua

                                user.Mensaje = encId.CompIdioma["L_Error_Inactivo"].ToString();
                                //user.Mensaje = "Usuario Se Encuentra Inactivo";
                                //Session["userId"] = null;
                                user.SUserId = null;
                                //user.Url = "~/View/Loggin.aspx";
                            }
                            else
                            {
                                user.Mensaje = encId.CompIdioma["L_Error_Inactivo"].ToString();
                                //user.Mensaje = "Usuario Se Encuentra Inactivo";
                                //Session["userId"] = null;
                                user.SUserId = null;
                                //user.Url = "~/View/Loggin.aspx";
                            }

                        }
                    }
                    else
                    {
                        user.Mensaje = encId.CompIdioma["L_Error_Incorrecto"].ToString();

                        //user.Mensaje = "Usuario Y/o Clave Incorrecto";
                        //Session["userId"] = null;
                        user.SUserId = null;
                        //user.Url = "~/View/Loggin.aspx";

                        DataTable erroneos = datos.sumaIntentosErroneos(userName);
                        datos.actualizaFechaSesionErronea(userName);
                        int IntentosErroneos = int.Parse(erroneos.Rows[0][0].ToString());
                        if (IntentosErroneos == 0)
                        {
                            //user.Notificacion = "Ha exedido el numero de intentos erroneos";
                            user.MensajeIntentoErroneos = "<script language='JavaScript'>window.alert('Ha exedido el numero de intentos erroneos');</script>";

                        }
                        
                    }
                }
                else {
                    user.MensajeIntentoErroneos = "<script language='JavaScript'>window.alert('No ha cumplido los 30 minutos de suspencion');</script>";

                }
            }
            else
            {
                user.Mensaje = encId.CompIdioma["L_Error_Bot"].ToString();
            }

            
            return user;
        }

        public void limpiaSesionActiva(string usuario)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            dat.LimpiaSesionesActivas(usuario);
   
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
               string session,
               int selIdioma)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 6;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);


            int dep;
            dep = (departamento);

            int ciu;
            ciu = (ciudad);
            usua.Mensaje = "";
            if (departamento == 0 || ciudad == 0)
            {
                //usua.Mensaje = "Debe seleccionar una opcion";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString(); 
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
                    dat.InsertaTablaSesion(usuario);
                     //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                     usua.Notificacion = "<script language='JavaScript'>window.alert('"+ encId.CompIdioma["script_insertado"].ToString()+"');</script>";
                    usua.B_Botones1 = true;
                    usua.L_Aceptar1 = false;

                }
                else
                {
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Error al Seleccionar la Foto');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_error_foto"].ToString() + "');</script>";
                }
            }
           
            return usua;
        }




        public UUser validarUser(string usuario, string documento, int selIdioma)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 6;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.UserName = usuario;
            usua.Documento = documento.ToString();

            DataTable registros = dat.validar_usuarioadmin(usua);

            if (registros.Rows.Count > 0)
            {

                //tb_Vusuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
                //tb_Vdocumento.Text = Convert.ToString(registros.Rows[0]["num_documento"].ToString());
                //usua.Mensaje = "El Usuario ya existe";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_usuario_noexiste"].ToString();
                usua.L_Aceptar1 = false;
                usua.B_Botones1 = true;

            }
            else
            {
                //L_ErrorUsuario.Text = "";

                //usua.Mensaje = "Usuario Disponible";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_usuario_existe"].ToString();
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
            int id_acu, 
            int selIdioma
            )
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 8;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            int dep;
            dep = (departamento);

            int ciu;
            ciu = (ciudad);
            usua.Mensaje = "";
            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString();// "Debe seleccionar una opcion";
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
                    dat.InsertaTablaSesion(usuario);
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>"; // ("<script language='JavaScript'>window.alert('Estudiante Insertado con Exito');</script>");

                    usua.L_Aceptar1 = false;
                    usua.B_Botones1 = true;

                }
            }
            return usua;
        }
        

        public UUser CargaFotoM(string fotoIO, string fotExten, string foto, string server, int selIdioma)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 6;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

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
                enc.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_error_formato"].ToString() + "');</script>";
                //enc.Notificacion = "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>";
                return enc;
            }

            saveLocation = server + "/" + sFecha + sMinu + nombreArchivo;

            if (System.IO.File.Exists(saveLocation))
            {
                enc.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_error_foto_repite"].ToString() + "');</script>";
                //enc.Notificacion = "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>";
                return enc;
            }
            string h = encId.CompIdioma["script_foto_cargada"].ToString();
            enc.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto_cargada"].ToString() + "');</script>";
            //enc.Notificacion = "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>";
            enc.SaveLocation = saveLocation;
            enc.FotoCargada = "~/FotosUser" + "/" + sFecha + sMinu + nombreArchivo;
            return enc;
        }




        public UUser buscarAcudiete(int departamento, int ciudad, String documento, int selIdioma)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 8;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Documento = documento.ToString();

            DataTable registros = dat.obtenerAcudiente(usua);

            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString(); //"Debe seleccionar una opcion";
            }

            if (registros.Rows.Count > 0)
            {
                usua.Nombre = Convert.ToString(registros.Rows[0]["nombre_usua"].ToString());
                usua.Apellido = Convert.ToString(registros.Rows[0]["apellido_usua"].ToString());
                usua.id_Acudiente = Convert.ToString(registros.Rows[0]["id_usua"].ToString());

                usua.L_Aceptar1 = true;
                usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_acudiente_ok"].ToString() + "');</script>";// ("<script language='JavaScript'>window.alert('Acudiente Seleccionado');</script>");

            }
            else
            {
                usua.MensajeAcudiente = encId.CompIdioma["L_ErrorAcudiente"].ToString();// "El Acudiente No se encuentra en la base de Datos";
            }
            return usua;
        }

        public UUser editarBuscarUser(int documento, int selIdioma)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 16;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

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
                    usua.Estado = encId.CompIdioma["DDL_Estado"].ToString();
                }
                else
                {
                    usua.Estado = encId.CompIdioma["DDL_Estado2"].ToString();
                }
                usua.L_Aceptar1 = false;
                usua.B_Botones1 = true;
            }
            else
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_registro"].ToString(); //"Sin Registros";
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
            string fotoup,
            string foto,
            int selIdioma, 
            int rol
            )
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 16;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_selecionar"].ToString();
                //"Debe seleccionar una opcion";
            }
            else
            {
                String est;

                if (estado == "Activo" || estado == encId.CompIdioma["DDL_Estado"].ToString())
                {
                    est = "true";
                }
                else
                {
                    est = "false";
                }


                if (fotoup == null)
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

                    if (usua.Foto != null)
                    {
                        DataTable registros = dat.EditarUsuario(usua);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
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
                    usua.Foto = fotoup;
                    
                    if (usua.Foto != null)
                    {
                        DataTable registros = dat.EditarUsuario(usua);
                        //usua.Notificacion = " <script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto_null"].ToString() + "');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }
                
            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;
        }

        //**************REPORTES**************REPORTES**************REPORTES**************REPORTES**************REPORTES**************REPORTES

        public InfReporte reporteAdmin(String urlCarpeta)
        {
            DataRow fila;

            DataTable informacion = new DataTable();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["Administrador"];

            DUser administrador = new DUser();
            DataTable Intermedio = administrador.obtenerAdministradores();

            for (int i = 0; i < Intermedio.Rows.Count; i++)
            {

                fila = informacion.NewRow();
                string foto = Path.GetFileName(Intermedio.Rows[i]["foto_usua"].ToString());
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Telefono"] = Intermedio.Rows[i]["telefono"].ToString();
                fila["Correo"] = Intermedio.Rows[i]["correo"].ToString();
                fila["Foto"] = streamFile(urlCarpeta + foto);

                informacion.Rows.Add(fila);
            }
            return datos;
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

        public InfReporte reporteProfe(String urlCarpeta)
        {
            DataRow fila;

            DataTable informacion = new DataTable();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["Profesor"];

            DUser profe = new DUser();
            DataTable Intermedio = profe.obtenerprofesores();
            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                string foto = Path.GetFileName(Intermedio.Rows[i]["foto_usua"].ToString());
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Telefono"] = Intermedio.Rows[i]["telefono"].ToString();
                fila["Correo"] = Intermedio.Rows[i]["correo"].ToString();
                fila["Foto"] = streamFile(urlCarpeta + foto);
                informacion.Rows.Add(fila);
            }
            return datos;
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

        public InfReporte reporteDiploma(string urlCarpeta, UUser documento)
        {
            DataRow fila;

            DataTable informacion = new DataTable();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["EstudianteDiploma"];

            DUser diploma = new DUser();
            DataTable Intermedio = diploma.obtenerUsuarioMod(documento);
            for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
                                                            //// si es solo un dato como con el certificado de estudio, no se hace el for
            {
                fila = informacion.NewRow();
                string foto = Path.GetFileName(Intermedio.Rows[i]["foto_usua"].ToString());
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = Intermedio.Rows[i]["apellido_usua"].ToString();
                fila["Nombre"] = Intermedio.Rows[i]["nombre_usua"].ToString();
                fila["Documento"] = int.Parse(Intermedio.Rows[i]["num_documento"].ToString());
                fila["Foto"] = streamFile(urlCarpeta + foto);
                informacion.Rows.Add(fila);
            }
            return datos;
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

        private byte[] streamFile(String filefoto)
        {
            FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read);
            byte[] imagenData = new byte[fs.Length];
            fs.Read(imagenData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return imagenData;
        }


        public UUser verificarCorreo(
            string userId,
            string persona,
            string apePersona,
            string correo_l,
            string destinatario,
            string asunto,
            string mensaje,
            int selIdioma
            )
        {
            DUser dat = new DUser();
            UUser usua = new UUser();

            usua.Correo = destinatario;
            DataTable resultado = dat.verificarCorreo(usua);
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 5;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (resultado.Rows.Count > 0)
            {
                mensaje = mensaje + "<br><br>Atentamente: " + persona + " " + apePersona + "<br>Correo para responder: " + correo_l + "";
                string cadena = mensaje;
                DCorreoEnviar correo = new DCorreoEnviar();
                correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                //usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["scrip_msm_enviado"].ToString() + "');</script>";
                usua.Url = "AdministradorMensaje.aspx";
                usua.Mensaje = "";
            }
            else
            {
                usua.Mensaje = encId.CompIdioma["L_Verificar"].ToString();
                //"El correo digitado no existe";
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
            string mensaje,
            int selIdioma
            )
        {
            DUser dat = new DUser();
            UUser usua = new UUser();

            usua.Correo = destinatario;
            DataTable resultado = dat.verificarCorreo(usua);
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 28;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);


            if (materia == "0")
            {
                usua.Mensaje = encId.CompIdioma["L_Verificar"].ToString(); //"Debe seleccionar una opcion";
            }
            else
            {
                if (resultado.Rows.Count > 0)
                {
                    mensaje = mensaje + "<br><br>Atentamente: " + persona + " " + apePersona + "<br>Correo para responder: " + correo_l + "";
                    string cadena = mensaje;
                    DCorreoEnviar correo = new DCorreoEnviar();
                    correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_msm_enviado"].ToString() + "');</script>";
                    usua.Url = "EstudianteProfesor.aspx";
                    usua.Mensaje = "";
                }
                else
                {
                    usua.Mensaje = encId.CompIdioma["L_Error_correo"].ToString();

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
            string mensaje,
            int selIdioma
            )
        {
            DUser dat = new DUser();
            UUser usua = new UUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 30;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

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
                //usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
                usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_men_enviado"].ToString() + "');</script>";
                usua.Url = "InicioNosotros.aspx";
            }
            else
            {
                //usua.Notificacion = "<script language='JavaScript'>window.alert('Ha ocurrido un problema.');</script>";
                usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_problema"].ToString() + "');</script>";
            }
            return usua;
        }

        
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
                        string fotoName,
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

            //String foto = System.IO.Path.GetFileName(fotoName.PostedFile.FileName);

            if (fotoName == null)
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
                //foto = "~/FotosUser/" + fotoName;
                enc.Id_estudiante = SuserId;
                enc.UserName = userName;
                enc.Clave = contraseña;
                enc.Correo = correo;
                enc.Foto = fotoName;
                enc.Session = sesion;
              

   
            }

            DataTable resultado = datos.editarConfig(enc);

            return enc;
        }

        ///////////////////////CONFIGURACION DE PAGINA//////////////////////

        public UUser ModificarPaginaInicio(string nosotros, string mision, string vision, string session, int selIdioma)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 19;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Inicio = nosotros;
            usua.Mision = mision;
            usua.Vision = vision;
            
            usua.Session = session;


            DataTable registros = dat.editarInicio(usua);
            usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_datos_modificados"].ToString() + "');</script>";
            //usua.Notificacion = "<script language='JavaScript'>window.alert('Datos Modificados');</script>";
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

        public UUser insertarfechafin(string fechater, int selIdioma)
        {

            UUser usua = new UUser();
            DUser dat = new DUser();

            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 19;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Año = fechater;
            dat.editaFinaño(usua);
            bool ok = true;
            dat.editaBool(ok);
            usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_datos_insertado"].ToString() + "');</script>";
            //usua.Notificacion = "<script language='JavaScript'>window.alert('Insertado con Exito');</script>";

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

        public UUser recuperarContra(string userName, int selIdioma)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 41;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

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

                usua.Mensaje = encId.CompIdioma["L_Verificar_ver_correo"].ToString(); //"Revisar su correo para recuperar contraseña";
            }
            else if (int.Parse(validez.Rows[0]["id_usua"].ToString()) == -2)
            {
                usua.Mensaje = encId.CompIdioma["L_Verificar_ver_link"].ToString(); //"Ya extsite un link de recuperación, por favor verifique su correo.";
            }
            else
            {
                usua.Mensaje = encId.CompIdioma["L_Verificar_no_existe"].ToString(); //"El usuario digitado no existe";
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

        public UUser cambiarContra(int QueryString, string Query, string session, int selIdioma)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 42;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (QueryString > 0)
            {
                DataTable info = dat.obtenerUsusarioToken(Query);

                if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");
                    
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('El Token es invalido. Genere uno nuevo');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_invalido"].ToString() + "');</script>";
                    usua.Url = "~/View/Loggin.aspx";
                }
                else if (int.Parse(info.Rows[0][0].ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");
                    
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('El Token esta vencido. Genere uno nuevo');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_vencido"].ToString() + "');</script>";
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
