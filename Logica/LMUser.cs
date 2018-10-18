using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Utilitarios.MVistasUsuario;
using Utilitarios.Mregistro;

namespace Logica
{
    public class LMUser
    {
        public void insertarUserMapeo(Usuario text)
        {
            DMUser dao = new DMUser();
            dao.insertarUserMapeo(text);
        }





        /////////ENVIAR CORREO A PROFESOR//////////////////////

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
            DMUser dat = new DMUser();
            UUser usua = new UUser();

            usua.Correo = destinatario;
            List<Usuario> resultado = dat.verificarCorreo(usua) ;
         //   DataTable resultado = dat.verificarCorreo(usua);
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 5;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (resultado.Count > 0)
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




        ////////FIN ENVIAR CORREO A PROFESOR////////////////

        public UUser insertaradmin(Usuario admin, int selIdioma)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 7;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);



            int dep;
            dep = int.Parse(admin.dep_nacimiento.ToString());


            int ciu;
            ciu = int.Parse(admin.ciu_nacimiento.ToString());

            usua.Mensaje = "";
            if (dep == 0 || ciu == 0)
            {
                //usua.Mensaje = "Debe seleccionar una opcion";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString();
            }
            else
            {

                if (admin.foto_usua != null)
                {
                    admon.insertarAdmin(admin);
                    dat.InsertaTablaSesion(admin.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
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


        ///LISTAR PARA EDITAR////
        ///
        public UUser editarBuscarUser(int documento, int selIdioma)
        {
            UUser usua = new UUser();
            UUser uuser = new UUser();
            DMUser dat = new DMUser();
            Usuario us = new Usuario();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 16;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            us.num_documento = documento.ToString();

            usua = dat.obtenerUsuarioMod(us);



            if (usua.Estado.ToString() == "True")
            {
                usua.Estado = encId.CompIdioma["DDL_Estado"].ToString();
            }
            else
            {
                usua.Estado = encId.CompIdioma["DDL_Estado2"].ToString();
            }
            usua.L_Aceptar1 = false;
            usua.B_Botones1 = true;


            //else
            //usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_registro"].ToString(); //"Sin Registros";

            return usua;
        }



        public UUser editarAdmin(Usuario admin, int selIdioma, string est, string fotoSesion)
        {

            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 16;



            int dep;
            dep = int.Parse(admin.dep_nacimiento.ToString());

            int ciu;
            ciu = int.Parse(admin.ciu_nacimiento.ToString());


            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (dep == 0 || ciu == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_selecionar"].ToString();
                //"Debe seleccionar una opcion";
            }
            else
            {
                

                if (est == "Activo" || est == encId.CompIdioma["DDL_Estado"].ToString())
                {
                    admin.estado = true;
                }
                else
                {
                    admin.estado = false;
                }

                if (admin.foto_usua == null)
                {
                    admin.foto_usua = fotoSesion;
                    
                    if (admin.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = admon.editarAdmin(admin);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }

                }
                else
                {
                    if (admin.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = admon.editarAdmin(admin);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }

            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;




        }


        public UUser insertarprofe(Usuario profe, int selIdioma)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 11;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);



            int dep;
            dep = int.Parse(profe.dep_nacimiento.ToString());


            int ciu;
            ciu = int.Parse(profe.ciu_nacimiento.ToString());

            usua.Mensaje = "";
            if (dep == 0 || ciu == 0)
            {
                //usua.Mensaje = "Debe seleccionar una opcion";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString();
            }
            else
            {

                if (profe.foto_usua != null)
                {
                    admon.insertarProfe(profe);
                    dat.InsertaTablaSesion(profe.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
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


        public UUser insertaracudiente(Usuario acudi, int selIdioma)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 6;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);



            int dep;
            dep = int.Parse(acudi.dep_nacimiento.ToString());


            int ciu;
            ciu = int.Parse(acudi.ciu_nacimiento.ToString());

            usua.Mensaje = "";
            if (dep == 0 || ciu == 0)
            {
                //usua.Mensaje = "Debe seleccionar una opcion";
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString();
            }
            else
            {

                if (acudi.foto_usua != null)
                {
                    admon.insertarAcudiente(acudi);
                    dat.InsertaTablaSesion(acudi.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
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

        public UUser editarProfesor(Usuario profe, int selIdioma, string est, string fotoSesion)
        {

            DMUser profo = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 18;



            int dep;
            dep = int.Parse(profe.dep_nacimiento.ToString());

            int ciu;
            ciu = int.Parse(profe.ciu_nacimiento.ToString());


            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (dep == 0 || ciu == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_selecionar"].ToString();
                //"Debe seleccionar una opcion";
            }
            else
            {


                if (est == "Activo" || est == encId.CompIdioma["DDL_Estado"].ToString())
                {
                    profe.estado = true;
                }
                else
                {
                    profe.estado = false;
                }

                if (profe.foto_usua == null)
                {
                    profe.foto_usua = fotoSesion;

                    if (profe.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = profo.editarProfesor(profe);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }

                }
                else
                {
                    if (profe.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = profo.editarProfesor(profe);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }

            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;




        }



        public UUser editarEstudiante(Usuario estudi, int selIdioma, string est, string fotoSesion)
        {

            DMUser estudo = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 17;



            int dep;
            dep = int.Parse(estudi.dep_nacimiento.ToString());

            int ciu;
            ciu = int.Parse(estudi.ciu_nacimiento.ToString());


            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (dep == 0 || ciu == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_selecionar"].ToString();
                //"Debe seleccionar una opcion";
            }
            else
            {


                if (est == "Activo" || est == encId.CompIdioma["DDL_Estado"].ToString())
                {
                    estudi.estado = true;
                }
                else
                {
                    estudi.estado = false;
                }

                if (estudi.foto_usua == null)
                {
                    estudi.foto_usua = fotoSesion;

                    if (estudi.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = estudo.editarEstudiante(estudi);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }

                }
                else
                {
                    if (estudi.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = estudo.editarEstudiante(estudi);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }

            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;




        }


        public UUser editarAcudiente(Usuario acudi, int selIdioma, string est, string fotoSesion)
        {

            DMUser acudo = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 15;



            int dep;
            dep = int.Parse(acudi.dep_nacimiento.ToString());

            int ciu;
            ciu = int.Parse(acudi.ciu_nacimiento.ToString());


            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (dep == 0 || ciu == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_selecionar"].ToString();
                //"Debe seleccionar una opcion";
            }
            else
            {


                if (est == "Activo" || est == encId.CompIdioma["DDL_Estado"].ToString())
                {
                    acudi.estado = true;
                }
                else
                {
                    acudi.estado = false;
                }

                if (acudi.foto_usua == null)
                {
                    acudi.foto_usua = fotoSesion;

                    if (acudi.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = acudo.editarAcudiente(acudi);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }

                }
                else
                {
                    if (acudi.foto_usua != null)
                    {
                        //DataTable registros = dat.EditarUsuario(usua);
                        usua = acudo.editarAcudiente(acudi);
                        usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_foto"].ToString() + "');</script>";
                        //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Editado con Éxito');</script>";
                        usua.B_Botones1 = false;
                        //btn_AdministradorAceptar.Visible = false;

                    }
                }

            }
            usua.BotonFalse = false;
            usua.BotonTrue = true;

            return usua;

        }

        public UUser ModifConfiguracionMapeo(Usuario admin, string fotoSesion)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();
            DMUser mdat = new DMUser();

            if (admin.foto_usua == null)
            {
                admin.foto_usua = fotoSesion;

                enc.UserName = admin.user_name;
                enc.Clave = admin.clave;
                enc.Correo = admin.correo;
                enc.Session = admin.sesion;
                enc.Foto = admin.foto_usua;
                
                mdat.editarConfiguracionAdmin(admin);

            }
            else
            {

                enc.UserName = admin.user_name;
                enc.Clave = admin.clave;
                enc.Correo = admin.correo;
                enc.Session = admin.sesion;
                enc.Foto = admin.foto_usua;

                mdat.editarConfiguracionAdmin(admin);


            }
            
            return enc;
        }

        private byte[] streamFile(String filefoto)
        {
            FileStream fs = new FileStream(filefoto, FileMode.Open, FileAccess.Read);
            byte[] imagenData = new byte[fs.Length];
            fs.Read(imagenData, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return imagenData;
        }

        public void reporteAcudiente(DataTable informacion)
        {
            DUser administrador = new DUser();
            DMUser muser = new DMUser();
            DataRow fila;
           // DataTable Intermedio = administrador.obteneracudientes();
            List<Usuario> acu = muser.listarAcudientes();

            foreach (Usuario u in acu)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = u.apellido_usua;
                fila["Nombre"] = u.nombre_usua;
                fila["Documento"] = u.num_documento;
                fila["Telefono"] = u.telefono;
                fila["Correo"] = u.correo;
                informacion.Rows.Add(fila);

            }
        }


        public InfReporte reporteAdmin(String urlCarpeta)
        {
            DataRow fila;

            DataTable informacion = new DataTable();
            InfReporte datos = new InfReporte();
            DMUser muser = new DMUser();

            informacion = datos.Tables["Administrador"];

            DUser administrador = new DUser();
            //DataTable Intermedio = administrador.obtenerAdministradores();
            List<Usuario> admin = muser.listarAdministradores();

            foreach(Usuario ad in admin)
            {
                fila = informacion.NewRow();
                string foto = Path.GetFileName(ad.foto_usua);
                fila["Apellido"] = ad.apellido_usua;
                fila["Nombre"] = ad.nombre_usua;
                fila["Documento"] = ad.num_documento;
                fila["Telefono"] = ad.telefono;
                fila["Correo"] = ad.correo;
                fila["Foto"] = streamFile(urlCarpeta + foto);

                informacion.Rows.Add(fila);

            }
            return datos;
        }



        public void reporteDocente(DataTable informacion)
        {
            DUser docente = new DUser();
            DMUser muser = new DMUser();
            DataRow fila;
            // DataTable Intermedio = administrador.obteneracudientes();
            List<Usuario> acu = muser.listarProfesores();

            foreach (Usuario u in acu)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = u.apellido_usua;
                fila["Nombre"] = u.nombre_usua;
                fila["Documento"] = u.num_documento;
                fila["Telefono"] = u.telefono;
                fila["Correo"] = u.correo;
                informacion.Rows.Add(fila);

            }
        }


        public UUser validarUsuario(string usuario, string documento, int selIdioma)
        {


            Usuario usuaok = new Usuario();
            UUser usua = new UUser();
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 6;
            bool usuariook;
            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usuaok.num_documento = documento.ToString();
            usuaok.user_name = usuario.ToString();



            usuariook = dat.validarUser(usuaok);
            if (usuariook == true)
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



      public InfReporte reporteDiplomaper(string urlCarpeta, UUser documento)
         {
            DataRow fila;
            DMUser muser = new DMUser();
            DataTable informacion = new DataTable();
            List<Usuario> diplomaper = new List<Usuario>();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["EstudianteDiploma"];
            string docest = documento.Documento;
            diplomaper = muser.listadiploma(docest);

            DUser diploma = new DUser();
            DataTable Intermedio = diploma.obtenerUsuarioMod(documento);
            //for (int i = 0; i < Intermedio.Rows.Count; i++) // for para llenar la lista con cada usurario
            //                                                //// si es solo un dato como con el certificado de estudio, no se hace el for
            //{

            foreach (Usuario usrio in diplomaper)
            {
                fila = informacion.NewRow();
                string foto = Path.GetFileName(usrio.foto_usua);
                ///El primero [""]  es como se llama el campo de la tabla de crystal y el segundo [""] el campo de la tabla en postgres
                fila["Apellido"] = usrio.apellido_usua;
                fila["Nombre"] = usrio.nombre_usua;
                fila["Documento"] = usrio.num_documento;
                fila["Foto"] = streamFile(urlCarpeta + foto);
                informacion.Rows.Add(fila);

            }
               
            return datos;
        }



        public void reporteEstudiante(DataTable informacion, int curso)
        {

            DMUser muser = new DMUser();
            List<Usuario> estcurper = new List<Usuario>();
           
            DataRow fila;
            estcurper = muser.listaEstcurso(curso);
            foreach (Usuario aniocurest in estcurper)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = aniocurest.apellido_usua;
                fila["Nombre"] = aniocurest.nombre_usua;
                informacion.Rows.Add(fila);
            }

        }


        public UUser loggear(string userName, string clave, int selIdioma, Boolean bot)
        {
            UUser user = new UUser();
            DUser datos = new DUser();
            DMUser muser = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 40;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            string estadolist = "";
            string rollist = "";
            user.UserName = userName;
            user.Clave = clave;

            user.Mensaje = "";

            //DataTable resultado = datos.loggin(user);
            List<Usuario> listuser = muser.loggin(user);

            if (bot == true)
            {
                if (listuser.Count > 0)
                {
                    DataTable fechasesion = datos.Capturafechaintentosesion(userName);
                    if (int.Parse(fechasesion.Rows[0][0].ToString()) == 0)
                    {
                        foreach (Usuario d in listuser)
                        {
                            user.SUserId = d.id_usua.ToString();
                            user.SUserName = d.user_name.ToString();
                            user.SNombre = d.nombre_usua.ToString();
                            user.SApellido = d.apellido_usua.ToString();
                            user.SClave = d.clave.ToString();
                            user.SCorreo = d.correo.ToString();
                            user.SDocumento = d.num_documento.ToString();
                            user.SFoto = d.foto_usua.ToString();
                            estadolist = d.estado.ToString();
                            rollist = d.rol_id.ToString();
                        }
                        if (estadolist == "True")
                        {
                            DataTable valida = datos.evaluaSesiones(userName);
                            int idUsuario = int.Parse(valida.Rows[0][0].ToString());
                            if (idUsuario == 1)
                            {

                                user.Mensaje = " ";
                                switch (int.Parse(rollist))
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
                        user.MensajeIntentoErroneos = "<script language='JavaScript'>window.alert('No ha cumplido los 30 minutos de suspencion');</script>";
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
            else
            {
                user.Mensaje = encId.CompIdioma["L_Error_Bot"].ToString();
            }


            return user;
        }

        public UUser CargaFotoM(string fotoIO, string fotExten, string foto, string server, int selIdioma)
        {
            UUser enc = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
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
            DMUser dat = new DMUser();
            UUser usua = new UUser();

            usua.Correo = destinatario;
            //DataTable resultado = dat.verificarCorreo(usua);
            List<Usuario> resultado = dat.verificarCorreo(usua);
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 28;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);


            if (materia == "0")
            {
                usua.Mensaje = encId.CompIdioma["L_Verificar"].ToString(); //"Debe seleccionar una opcion";
            }
            else
            {
                if (resultado.Count > 0)
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


        public UUser PL_EstudianteVerNotas(string userId)
        {
            DMUser datos = new DMUser();
            UUser enc = new UUser();
            DateTime fecha = DateTime.Now;
            DMReg dato = new DMReg();
            enc.SAño = "0";
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            //DataTable re = datos.obtenerAniodeCurso(año);
            List<Anio> re = dato.obtenerAniodeCurso(año);
            foreach (Anio an in re)
            {
                enc.Año = an.id_anio.ToString();
                //enc.Año = re.Rows[0]["id_anio"].ToString();
            }
            enc.Id_estudiante = userId;

            List<CursoDeEstudianteVista> registros = new List<CursoDeEstudianteVista>();
            registros = dato.obtenerCursoEst(enc);
            foreach (CursoDeEstudianteVista ce in registros)
            {
                if (registros.Count > 0)
                {
                    enc.SAño = ce.id_ancu.ToString();
                }
                else
                {
                    enc.SAño = "0";
                }
            }
            return enc;
        }


        public void reporteCertidicadoEstudiante(DataTable informacion, string docuemtno)
        {
            DMUser estudiante = new DMUser();
            DataRow fila;

            //DataTable Intermedio = estudiante.obtenerCertificadoEst(docuemtno.ToString());
            List<Usuario> Intermedio = estudiante.obtenerCertificadoEst(docuemtno.ToString());

            
            foreach(Usuario u in Intermedio)
            {
                fila = informacion.NewRow();
                fila["Apellido"] = u.apellido_usua.ToString();
                fila["Nombre"] = u.nombre_usua.ToString();
                fila["Documento"] = int.Parse(u.num_documento.ToString());
                informacion.Rows.Add(fila);
            }
        }


        public UUser TraerDatosPagina()
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();

            usua = dat.inicio();

            return usua;
        }

        public UUser ModificarPaginaInicio(string nosotros, string mision, string vision, string session, int selIdioma)
        {

            UUser usua = new UUser();
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 19;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Inicio = nosotros;
            usua.Mision = mision;
            usua.Vision = vision;

            usua.Session = session;


            dat.editarInicio(usua);
            usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_datos_modificados"].ToString() + "');</script>";
            //usua.Notificacion = "<script language='JavaScript'>window.alert('Datos Modificados');</script>";
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

            mensaje = mensaje + "<br><br>Atentamente: " + nombres + "<br>" + apellidos + "<br>Correo para responder: " + correo_l + "<br>Telefono: " + telefono + "";
            string cadena = mensaje;
            DCorreoEnviar correo = new DCorreoEnviar();
            correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
            //usua.Notificacion = "<script language='JavaScript'>window.alert('Se ha enviado su mensaje con éxito');</script>";
            usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_men_enviado"].ToString() + "');</script>";
            usua.Url = "InicioNosotros.aspx";

            return usua;

        }




    }
}
