using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LMUser
    {
        public void insertarUserMapeo(Usuario text)
        {
            DMUser dao = new DMUser();
            dao.insertarUserMapeo(text);
        }


        public UUser insertaradmin(Usuario admin, int selIdioma)
        {
            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
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



        public UUser editarAdmin(Usuario admin, int selIdioma, string est, string fotoSesion)
        {

            DMUser admon = new DMUser();
            UUser usua = new UUser();
            DUser dat = new DUser();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
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
            LIdioma idioma = new LIdioma();
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
            LIdioma idioma = new LIdioma();
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
            LIdioma idioma = new LIdioma();
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
            LIdioma idioma = new LIdioma();
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
            LIdioma idioma = new LIdioma();
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


        //public UUser validarUsuario(string usuario, string documento, int selIdioma)
        //{
            


        //    UUser usua = new UUser();
        //    DMUser dat = new DMUser();
        //    UIdioma encId = new UIdioma();
        //    LIdioma idioma = new LIdioma();
        //    Int32 FORMULARIO = 6;

        //    encId = idioma.obtIdioma(FORMULARIO, selIdioma);

        //    usua.Documento = documento.ToString();
        //    usua.UserName = usuario.ToString();
           

          
        //    usua = dat.validarUser(documento,usuario)
        //    if (registros.Rows.Count > 0)
        //    {

        //        //tb_Vusuario.Text = Convert.ToString(registros.Rows[0]["user_name"].ToString());
        //        //tb_Vdocumento.Text = Convert.ToString(registros.Rows[0]["num_documento"].ToString());
        //        //usua.Mensaje = "El Usuario ya existe";
        //        usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_usuario_noexiste"].ToString();
        //        usua.L_Aceptar1 = false;
        //        usua.B_Botones1 = true;

        //    }
        //    else
        //    {
        //        //L_ErrorUsuario.Text = "";

        //        //usua.Mensaje = "Usuario Disponible";
        //        usua.Mensaje = encId.CompIdioma["L_ErrorUsuario_usuario_existe"].ToString();
        //        //btn_DocenteAceptar.Visible = true;
        //        //btn_DocenteNuevo.Visible = true;
        //        //btn_validar.Visible = false;
        //        //tb_DocenteUsuario.ReadOnly = true;
        //        //tb_DocenteId.ReadOnly = true;
        //        usua.L_Aceptar1 = true;
        //        usua.B_Botones1 = false;

        //    }

        //    return usua;



        //}


    }


}
