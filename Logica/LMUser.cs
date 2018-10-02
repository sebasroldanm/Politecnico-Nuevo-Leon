using System;
using System.Collections.Generic;
using System.Data;
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



    }
}
