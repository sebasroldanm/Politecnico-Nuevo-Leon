using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using Utilitarios.MEncSeguridad;
using Utilitarios.MSeguridad;
using Utilitarios.MVistasUsuario;
using Utilitarios.Mregistro;
using Newtonsoft.Json;
using System.Security.Cryptography;

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

        public UUser insertaradmin(Usuario admin, int selIdioma, string sesion)
        {

    

            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DMSeguridad dmseg = new DMSeguridad();
            MencUsuario encusua = new MencUsuario();
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
                    admon.InsertaTablaSesion(admin.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
                    usua.B_Botones1 = true;
                    usua.L_Aceptar1 = false;
                    encusua.apellido_usua_nuevo = admin.apellido_usua;
                    encusua.ciu_nacimiento_nuevo = admin.ciu_nacimiento;
                    encusua.clave_nuevo = admin.clave;
                    encusua.correo_nuevo = admin.correo;
                    encusua.dep_nacimiento_nuevo = admin.dep_nacimiento;
                    encusua.direccion_nuevo = admin.direccion;
                    encusua.estado_nuevo = admin.estado;
                    encusua.fecha_nac_nuevo = admin.fecha_nac;
                    encusua.foto_usua_nuevo = admin.foto_usua;
                    encusua.nombre_usua_nuevo = admin.nombre_usua;
                    encusua.num_documento_nuevo = admin.num_documento;
                    encusua.rol_id_nuevo = admin.rol_id;
                    encusua.sesion_nuevo = admin.sesion;
                    encusua.telefono_nuevo = admin.telefono;
                    encusua.user_name_nuevo = admin.user_name;
                    dmseg.fiel_auditoria_agrega_usuario("INSERT", sesion, encusua);


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
        
        public UUser editarBuscarUser(int documento, int selIdioma)
        {
            UUser usua = new UUser();
            UUser uuser = new UUser();
            DMUser dat = new DMUser();
            UUser us = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            List<Usuario> lusua = new List<Usuario>();
            Int32 FORMULARIO = 16;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            us.Documento = documento.ToString();

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
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            DMSeguridad dmseg = new DMSeguridad();
            MencUsuario encusua = new MencUsuario();
            MEncAcudiente encacudi = new MEncAcudiente();
        
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
                    encusua.apellido_usua_nuevo = usua.Apellido;
                    encusua.ciu_nacimiento_nuevo = int.Parse(usua.Ciudad);
                    encusua.clave_nuevo = usua.Clave;
                    encusua.correo_nuevo = usua.Correo;
                    encusua.dep_nacimiento_nuevo = int.Parse(usua.Departamento);
                    encusua.direccion_nuevo = usua.Direccion;
                    encusua.estado_nuevo = true;
                    encusua.fecha_nac_nuevo = usua.fecha_nacimiento;
                    encusua.foto_usua_nuevo = usua.Foto;
                    encusua.nombre_usua_nuevo = usua.Nombre;
                    encusua.num_documento_nuevo = int.Parse(usua.Documento);
                    encusua.rol_id_nuevo = int.Parse(usua.Rol);
                    encusua.sesion_nuevo = usua.Session;
                    encusua.telefono_nuevo = usua.Telefono;
                    encusua.user_name_nuevo = usua.UserName;
                    dmseg.fiel_auditoria_agrega_usuario("INSERT", session, encusua);

                    dat.insertarEstudiante(usua);
                    dat.InsertaTablaSesion(usuario);
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>"; // ("<script language='JavaScript'>window.alert('Estudiante Insertado con Exito');</script>");

                    usua.L_Aceptar1 = false;
                    usua.B_Botones1 = true;
                 


                }
            }
            return usua;
        }


        public UUser editarAdmin(Usuario admin, int selIdioma, string est, string fotoSesion)
        {

            DMUser admon = new DMUser();
            UUser usua = new UUser();
            
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
        
        public UUser buscarAcudiete(int departamento, int ciudad, String documento, int selIdioma)
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 8;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Documento = documento.ToString();

            List<Usuario> registros = dat.obtenerAcudiente(usua);

            if (departamento == 0 || ciudad == 0)
            {
                usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_Seleccione"].ToString(); //"Debe seleccionar una opcion";
            }

            if (registros.Count > 0)
            {
                foreach (Usuario acudi in registros)
                {
                    usua.Nombre = Convert.ToString(acudi.nombre_usua.ToString());
                    usua.Apellido = Convert.ToString(acudi.apellido_usua.ToString());
                    usua.id_Acudiente = Convert.ToString(acudi.id_usua.ToString());
                }
                usua.L_Aceptar1 = true;
                usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_acudiente_ok"].ToString() + "');</script>";// ("<script language='JavaScript'>window.alert('Acudiente Seleccionado');</script>");

            }
            else
            {
                usua.MensajeAcudiente = encId.CompIdioma["L_ErrorAcudiente"].ToString();// "El Acudiente No se encuentra en la base de Datos";
            }
            return usua;
        }
      
        public UUser insertarprofe(Usuario profe, int selIdioma, string sesion)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            DMSeguridad dmseg = new DMSeguridad();
            MencUsuario encusua = new MencUsuario();
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
                    admon.InsertaTablaSesion(profe.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
                    usua.B_Botones1 = true;
                    usua.L_Aceptar1 = false;
                    encusua.apellido_usua_nuevo = profe.apellido_usua;
                    encusua.ciu_nacimiento_nuevo = profe.ciu_nacimiento;
                    encusua.clave_nuevo = profe.clave;
                    encusua.correo_nuevo = profe.correo;
                    encusua.dep_nacimiento_nuevo = profe.dep_nacimiento;
                    encusua.direccion_nuevo = profe.direccion;
                    encusua.estado_nuevo = profe.estado;
                    encusua.fecha_nac_nuevo = profe.fecha_nac;
                    encusua.foto_usua_nuevo = profe.foto_usua;
                    encusua.nombre_usua_nuevo = profe.nombre_usua;
                    encusua.num_documento_nuevo = profe.num_documento;
                    encusua.rol_id_nuevo = profe.rol_id;
                    encusua.sesion_nuevo = profe.sesion;
                    encusua.telefono_nuevo = profe.telefono;
                    encusua.user_name_nuevo = profe.user_name;
                    dmseg.fiel_auditoria_agrega_usuario("INSERT", sesion, encusua);

                }
                else
                {
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Error al Seleccionar la Foto');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_error_foto"].ToString() + "');</script>";
                }
            }

            return usua;



        }
   
        public UUser insertaracudiente(Usuario acudi, int selIdioma, string sesion)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            DMSeguridad dmseg = new DMSeguridad();
            Acudiente encacudi = new Acudiente();
            MencUsuario encusua = new MencUsuario();
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
                    admon.InsertaTablaSesion(acudi.user_name);
                    //usua.Notificacion = "<script language='JavaScript'>window.alert('Usuario Insertado con Exito');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_insertado"].ToString() + "');</script>";
                    usua.B_Botones1 = true;
                    usua.L_Aceptar1 = false;
                    encusua.apellido_usua_nuevo = acudi.apellido_usua;
                    encusua.ciu_nacimiento_nuevo = acudi.ciu_nacimiento;
                    encusua.clave_nuevo = acudi.clave;
                    encusua.correo_nuevo = acudi.correo;
                    encusua.dep_nacimiento_nuevo = acudi.dep_nacimiento;
                    encusua.direccion_nuevo = acudi.direccion;
                    encusua.estado_nuevo = acudi.estado;
                    encusua.fecha_nac_nuevo = acudi.fecha_nac;
                    encusua.foto_usua_nuevo = acudi.foto_usua;
                    encusua.nombre_usua_nuevo = acudi.nombre_usua;
                    encusua.num_documento_nuevo = acudi.num_documento;
                    encusua.rol_id_nuevo = acudi.rol_id;
                    encusua.sesion_nuevo = acudi.sesion;
                    encusua.telefono_nuevo = acudi.telefono;
                    encusua.user_name_nuevo = acudi.user_name;
                    dmseg.fiel_auditoria_agrega_usuario("INSERT", sesion, encusua);

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

        public InfReporte reporteProfe(String urlCarpeta)
        {
            DataRow fila;

            DataTable informacion = new DataTable();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["Profesor"];

            DMUser profe = new DMUser();
            List<Usuario> acu = profe.listarProfesores();
            foreach (Usuario u in acu)
            {
                fila = informacion.NewRow();
                string foto = Path.GetFileName(u.foto_usua);
                fila["Apellido"] = u.apellido_usua;
                fila["Nombre"] = u.nombre_usua;
                fila["Documento"] = u.num_documento;
                fila["Telefono"] = u.telefono;
                fila["Correo"] = u.correo;
                fila["Foto"] = streamFile(urlCarpeta + foto);
                informacion.Rows.Add(fila);

            }
            return datos;
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

            usuaok.num_documento = int.Parse(documento);
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
        
        public InfReporte reporteDiploma(string urlCarpeta, UUser documento)
         {
            DataRow fila;
            DMUser muser = new DMUser();
            DataTable informacion = new DataTable();
            List<Usuario> diplomaper = new List<Usuario>();
            InfReporte datos = new InfReporte();

            informacion = datos.Tables["EstudianteDiploma"];
            string docest = documento.Documento;
            diplomaper = muser.listadiploma(docest);

            DMUser diploma = new DMUser();
            UUser Intermedio = diploma.obtenerUsuarioMod(documento);


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
        //Maldito Token Duser
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
                    int fechasesion = muser.Capturafechaintentosesion(userName);
                    if (fechasesion == 0)
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
                            int valida = muser.evaluaSesiones(userName);
                            int idUsuario = valida;
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
                                user.MensajeIntentoErroneos = "<script language='JavaScript'>window.alert('Ha exedido el numero de Sesiones Permitidas');</script>";

                            }
                            muser.LimpiaIntentosErroneos(userName);


                        }
                        else
                        {
                            user.Mensaje = encId.CompIdioma["L_Error_Inactivo"].ToString();
                            user.SUserId = null;
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
                    
                    user.SUserId = null;

                    int erroneos = muser.sumaIntentosErroneos(userName);
                    muser.actualizaFechaSesionErronea(userName);
                    //int IntentosErroneos = int.Parse(erroneos.Rows[0][0].ToString());
                    int IntentosErroneos = erroneos;
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

        public UUser ModificarPaginaInicio(string nosotros, string mision, string vision, string session, int selIdioma, MEncInicio enc)
        {

            UUser usua = new UUser();
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            DMSeguridad s = new DMSeguridad();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 19;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            usua.Inicio = nosotros;
            usua.Mision = mision;
            usua.Vision = vision;

            usua.Session = session;


            dat.editarInicio(usua);
            usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_datos_modificados"].ToString() + "');</script>";
            //usua.Notificacion = "<script language='JavaScript'>window.alert('Datos Modificados');</script>";
            s.fiel_auditoria_inicio("UPDATE", session, enc);
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
            
            UUser usua = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
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

        public void logicaGuardarSesion(int id, string ip, string mac, string sesion)
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();
            Autenticacion aut = new Autenticacion();
            //Mac datosConexion = new MAC();

            //usua.UserId = id;
            //usua.Ip = ip;
            //usua.Mac = mac;
            //usua.Session = sesion;
            aut.user_id = id;
            aut.ip = ip;
            aut.mac = mac;
            aut.session= sesion;
            aut.fecha_inicio = (DateTime.Now.ToShortDateString() +" "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

            dat.guardadoSession(aut);
        }

        public void limpiaSesionActiva(string usuario)
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();

            dat.LimpiaSesionesActivas(usuario);

        }

        public void cerrarSession(string sesion)
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();

            usua.Session = sesion;

            dat.cerrarSession(usua);
        }

        public UUser PL_AcudienteObservador(string estudiante)
        {
            UUser usua = new UUser();
            DMReg datos = new DMReg();
            DateTime fecha = DateTime.Now;
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            List<Anio> re = datos.obtenerAniodeCurso(año);
            foreach (Anio a in re)
            {
                usua.Año = a.id_anio.ToString();
                usua.Id_estudiante = estudiante;
            }

            List<CursoDeEstudianteVista> registros = datos.obtenerCursoEst(usua);
            if (registros.Count > 0)
            {
                foreach (CursoDeEstudianteVista cev in registros)
                {
                    usua.SAño = cev.id_ancu.ToString();
                    usua.SEstudiante = estudiante;
                }
                //Session["anio"] = registros.Rows[0]["id_ancu"].ToString();
                //Session["est"] = DDT_estudiante.SelectedValue;
            }
            else
            {
                usua.SAño = "0";
                usua.SEstudiante = estudiante;
                //Session["anio"] = "0";
                //Session["est"] = DDT_estudiante.SelectedValue;
            }
            return usua;
        }

        public UUser recuperarContra(string userName, int selIdioma)
        {
            UUser usua = new UUser();
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 41;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            List<Usuario> validez = dat.generarToken(userName);
            foreach (Usuario u in validez) {
                if (int.Parse(u.id_usua.ToString()) > 0)
                {
                    UToken token = new UToken();
                    //EUserToken token = new EUserToken();
                    token.Id = int.Parse(u.id_usua.ToString());
                    token.Nombre =u.nombre_usua.ToString();
                    token.User_name = u.user_name.ToString();
                    token.Estado = int.Parse(u.state_t.ToString());

                    token.Correo = u.correo.ToString();
                    token.Fecha = DateTime.Now.ToFileTimeUtc();


                    String userToken = encriptar(JsonConvert.SerializeObject(token));
                    dat.almacenarToken(userToken, token.Id);

                    DCorreo correo = new DCorreo();

                    String mensaje = "Su link de acceso es: " + "http://colegioleon.ddns.net/View/Contrasenia.aspx?" + userToken;
                    correo.enviarCorreo(token.Correo, userToken, mensaje);

                    usua.Mensaje = encId.CompIdioma["L_Verificar_ver_correo"].ToString(); //"Revisar su correo para recuperar contraseña";
                }
                else if (int.Parse(u.id_usua.ToString()) == -2)
                {
                    usua.Mensaje = encId.CompIdioma["L_Verificar_ver_link"].ToString(); //"Ya extsite un link de recuperación, por favor verifique su correo.";
                }
                else
                {
                    usua.Mensaje = encId.CompIdioma["L_Verificar_no_existe"].ToString(); //"El usuario digitado no existe";
                }
                //if (int.Parse(validez.Rows[0]["id_usua"].ToString()) > 0)
                //{
                //    UToken token = new UToken();
                //    //EUserToken token = new EUserToken();
                //    token.Id = int.Parse(validez.Rows[0]["id_usua"].ToString());
                //    token.Nombre = validez.Rows[0]["nombre_usua"].ToString();
                //    token.User_name = validez.Rows[0]["user_name"].ToString();
                //    token.Estado = int.Parse(validez.Rows[0]["state_t"].ToString());

                //    token.Correo = validez.Rows[0]["correo"].ToString();
                //    token.Fecha = DateTime.Now.ToFileTimeUtc();


                //    String userToken = encriptar(JsonConvert.SerializeObject(token));
                //    dat.almacenarToken(userToken, token.Id);

                //    DCorreo correo = new DCorreo();

                //    String mensaje = "Su link de acceso es: " + "http://localhost:58629/View/Contrasenia.aspx?" + userToken;
                //    correo.enviarCorreo(token.Correo, userToken, mensaje);

                //    usua.Mensaje = encId.CompIdioma["L_Verificar_ver_correo"].ToString(); //"Revisar su correo para recuperar contraseña";
                //}
                //else if (int.Parse(validez.Rows[0]["id_usua"].ToString()) == -2)
                //{
                //    usua.Mensaje = encId.CompIdioma["L_Verificar_ver_link"].ToString(); //"Ya extsite un link de recuperación, por favor verifique su correo.";
                //}
                //else
                //{
                //    usua.Mensaje = encId.CompIdioma["L_Verificar_no_existe"].ToString(); //"El usuario digitado no existe";
                //}
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
            DMUser dat = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 42;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (QueryString > 0)
            {
                int info = dat.obtenerUsusarioToken(Query);

                if (int.Parse(info.ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token es invalido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");

                    //usua.Notificacion = "<script language='JavaScript'>window.alert('El Token es invalido. Genere uno nuevo');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_invalido"].ToString() + "');</script>";
                    usua.Url = "~/View/Loggin.aspx";
                }
                else if (int.Parse(info.ToString()) == -1)
                {
                    //this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El Token esta vencido. Genere uno nuevo');window.location=\"Loggin.aspx\"</script>");

                    //usua.Notificacion = "<script language='JavaScript'>window.alert('El Token esta vencido. Genere uno nuevo');</script>";
                    usua.Notificacion = "<script language='JavaScript'>window.alert('" + encId.CompIdioma["script_vencido"].ToString() + "');</script>";
                    usua.Url = "~/View/Loggin.aspx";
                }
                else
                    usua.SUserId = ((info.ToString()));
            }
            else
                //Response.Redirect("~/View/Loggin.aspx");
                usua.Url = "~/View/Loggin.aspx";

            return usua;
        }

        public UContrasenia ContraseñaBEnviar(string NuevamenteClave, string userId)
        {
            DMUser datos = new DMUser();
            UContrasenia usua = new UContrasenia();

            usua.UserId = int.Parse(userId);
            usua.Clave = NuevamenteClave;
            datos.actualziarContrasena(usua);
            return usua;
        }

    }
}
