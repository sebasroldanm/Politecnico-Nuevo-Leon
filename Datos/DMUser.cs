using System;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Configuration;
using System.Collections.Generic;


namespace Datos
{
   public class DMUser
    {

        public void insertarUserMapeo(Usuario user)
        {
            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(user);
                db.SaveChanges();
            }


        }
        ///Lista con Mapeo//////////////////////////////////////////////////////////////////////////////
        public List<Usuario> listarAdministradores()
        {
            using (var db = new Mapeo("public"))
            {

                var admin = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains("1"));
                return admin.ToList<Usuario>();

            }

        }

        public List<Usuario> listarProfesores()
        {

            using (var db = new Mapeo("public"))
                {
                var profe = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains("2"));
                return profe.ToList<Usuario>();
            }
        }

        
        public List<Usuario> listarEstudiantes()
        {

            using (var db = new Mapeo("public"))
            {
                var estudiante = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains("3"));
                return estudiante.ToList<Usuario>();
            }
        }

        public List<Usuario> listarAcudientes()
        {
            using (var db = new Mapeo("public"))
            {
                var estudiante = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains("4"));
                return estudiante.ToList<Usuario>();
            }
        }
        ///Insertar con Mapeo///////////////////////////////////////////

        public void insertarAdmin(Usuario admin)
        {

            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(admin);
                db.SaveChanges();
            }

        }

        public void insertarProfe(Usuario profe)
        {

            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(profe);
                db.SaveChanges();
            }

        }

        public void insertarAcudiente(Usuario acudi)
        {

            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(acudi);
                db.SaveChanges();
            }

        }

        ///Edita con Mapeo////////////////

        public UUser editarAdmin(Usuario admin)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == admin.num_documento);
                if (result != null)
                {
                    result.nombre_usua = admin.nombre_usua;
                    result.rol_id = admin.rol_id;
                    result.user_name = admin.user_name;
                    result.clave = admin.clave;
                    result.correo = admin.correo;
                    result.estado = admin.estado;
                    result.apellido_usua = admin.apellido_usua;
                    result.direccion = admin.direccion;
                    result.telefono = admin.telefono;
                    result.num_documento = admin.num_documento;
                    result.foto_usua = admin.foto_usua;
                    result.fecha_nac = admin.fecha_nac;
                    result.dep_nacimiento = admin.dep_nacimiento;
                    result.ciu_nacimiento = admin.ciu_nacimiento;
                    result.sesion = admin.sesion;
                    result.ultima_modificacion = DateTime.Now.ToShortDateString();
                    db.SaveChanges();
                   
                }
            }
            return uuser;

        }
        public void editarConfiguracionAdmin(Usuario admin)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == admin.num_documento);
                if (result != null)
                {
                    result.clave = admin.clave;
                    result.correo = admin.correo;
                    result.num_documento = admin.num_documento;
                    result.foto_usua = admin.foto_usua;
                    result.sesion = admin.sesion;
                    result.ultima_modificacion = DateTime.Now.ToShortDateString();
                    db.SaveChanges();

                }
            }
            

        }

        public UUser editarAcudiente(Usuario acudi)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == acudi.num_documento);
                if (result != null)
                {
                    result.nombre_usua = acudi.nombre_usua;
                    result.rol_id = acudi.rol_id;
                    result.user_name = acudi.user_name;
                    result.clave = acudi.clave;
                    result.correo = acudi.correo;
                    result.estado = acudi.estado;
                    result.apellido_usua = acudi.apellido_usua;
                    result.direccion = acudi.direccion;
                    result.telefono = acudi.telefono;
                    result.num_documento = acudi.num_documento;
                    result.foto_usua = acudi.foto_usua;
                    result.fecha_nac = acudi.fecha_nac;
                    result.dep_nacimiento = acudi.dep_nacimiento;
                    result.ciu_nacimiento = acudi.ciu_nacimiento;
                    result.sesion = acudi.sesion;
                    result.ultima_modificacion = DateTime.Now.ToShortDateString();
                    db.SaveChanges();

                }
            }
            return uuser;

        }


        public UUser editarEstudiante(Usuario estudi)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == estudi.num_documento);
                if (result != null)
                {
                    result.nombre_usua = estudi.nombre_usua;
                    result.rol_id = estudi.rol_id;
                    result.user_name = estudi.user_name;
                    result.clave = estudi.clave;
                    result.correo = estudi.correo;
                    result.estado = estudi.estado;
                    result.apellido_usua = estudi.apellido_usua;
                    result.direccion = estudi.direccion;
                    result.telefono = estudi.telefono;
                    result.num_documento = estudi.num_documento;
                    result.foto_usua = estudi.foto_usua;
                    result.fecha_nac = estudi.fecha_nac;
                    result.dep_nacimiento = estudi.dep_nacimiento;
                    result.ciu_nacimiento = estudi.ciu_nacimiento;
                    result.sesion = estudi.sesion;
                    result.ultima_modificacion = DateTime.Now.ToShortDateString();
                    db.SaveChanges();

                }
            }
            return uuser;

        }

        public UUser editarProfesor(Usuario profe)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == profe.num_documento);
                if (result != null)
                {
                    result.nombre_usua = profe.nombre_usua;
                    result.rol_id = profe.rol_id;
                    result.user_name = profe.user_name;
                    result.clave = profe.clave;
                    result.correo = profe.correo;
                    result.estado = profe.estado;
                    result.apellido_usua = profe.apellido_usua;
                    result.direccion = profe.direccion;
                    result.telefono = profe.telefono;
                    result.num_documento = profe.num_documento;
                    result.foto_usua = profe.foto_usua;
                    result.fecha_nac = profe.fecha_nac;
                    result.dep_nacimiento = profe.dep_nacimiento;
                    result.ciu_nacimiento = profe.ciu_nacimiento;
                    result.sesion = profe.sesion;
                    result.ultima_modificacion = DateTime.Now.ToShortDateString();
                    db.SaveChanges();

                }
            }
            return uuser;

        }


    }
}
