using System;
using Utilitarios;
using Utilitarios.MSeguridad;
using Utilitarios.Mlugares;
using Utilitarios.Mregistro;
using Utilitarios.MVistasUsuario;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Utilitarios.MEncSeguridad;
using System.Configuration;
using System.Collections.Generic;


namespace Datos
{
    public class DMUser
    {
        public List<Usuario> loggin(UUser enc)
        {
            Usuario user = new Usuario();
            List<Usuario> luser = new List<Usuario>();
            using (var db = new Mapeo("public"))
            {

                luser = db.usuario.ToList<Usuario>().Where(x => x.user_name == (enc.UserName) && x.clave == (enc.Clave)).ToList();
                return luser;
                //return ingres.ToList<Usuario>();



            }
        }

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

                var admin = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 1);
                return admin.ToList<Usuario>();

            }

        }

        public List<Usuario> verificarCorreo(UUser datos)
        {
            using (var db = new Mapeo("public"))
            {
                var vercor = db.usuario.ToList<Usuario>().Where(x => x.correo.Contains(datos.Correo));
                return vercor.ToList<Usuario>();

            }

        }

        public List<Departamento> departamento()
        {
            using (var db = new Mapeo("public"))
            {
                var query = select();
                var depar = db.departamento.ToList<Departamento>().OrderBy(x => x.nom_dep);
                return query.Union(depar).ToList<Departamento>();
            }

        }

        public List<Anio> obtenerAnio()
        {
            using (var db = new Mapeo("public"))
            {

                List<Anio> lista = null;
                Anio aniddl = new Anio();
                lista = new List<Anio>();
                int year = int.Parse(DateTime.Now.ToString("yyyy"));
                aniddl.id_anio = 0;
                aniddl.nombre_anio = "Selec.";
                lista.Add(aniddl);
                var query = lista;
                var anio = db.anio.ToList<Anio>().Where(x => int.Parse((x.nombre_anio.Substring(0, 4))) >= (year)).Select(j => new Anio
                {
                    id_anio = j.id_anio,
                    nombre_anio = j.nombre_anio.Substring(0, 4)
                }).ToList();

                return query.Union(anio).ToList<Anio>();
            }
        }

        public List<Anio> obtenertodosAnio()
        {
            using (var db = new Mapeo("public"))
            {

                List<Anio> lista = null;
                Anio aniddl = new Anio();
                lista = new List<Anio>();
                aniddl.id_anio = 0;
                aniddl.nombre_anio = "Selec.";
                lista.Add(aniddl);
                var query = lista;
                var anio = db.anio.ToList<Anio>().Select(j => new Anio
                {
                    id_anio = j.id_anio,
                    nombre_anio = j.nombre_anio.Substring(0, 4)
                }).ToList();

                return query.Union(anio).ToList<Anio>();
            }
        }

        public List<Materia> obtenerMateria()
        {

            using (var db = new Mapeo("public"))
            {

                List<Materia> lista = null;
                Materia ddlmateria = new Materia();
                lista = new List<Materia>();
                ddlmateria.id_materia = 0;
                ddlmateria.nombre_materia = "Selec.";
                lista.Add(ddlmateria);
                var query = lista;
                var mate = db.materia.ToList<Materia>();
                return query.Union(mate).ToList<Materia>();

            }



        }

        public List<Usuario> listardocenteddl()
        {
            using (var db = new Mapeo("public"))
            {

                List<Usuario> lista = null;
                Usuario ddlprof = new Usuario();
                lista = new List<Usuario>();
                ddlprof.id_usua = 0;
                ddlprof.nombre_usua = "Selec.";
                lista.Add(ddlprof);
                var query = lista;
                var prof = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 2).Select(u => new Usuario
                {
                    id_usua = u.id_usua,
                    nombre_usua = u.nombre_usua + " " + u.apellido_usua
                }).ToList();
                return query.Union(prof).ToList<Usuario>();
            }


        }

        public List<DiaMateria> obtenerdiak()
        {
            using (var db = new Mapeo("public"))
            {
                List<DiaMateria> lista = null;
                DiaMateria ddldia = new DiaMateria();
                lista = new List<DiaMateria>();
                ddldia.id_dia_materia = 0;
                ddldia.dia = "Selec.";
                lista.Add(ddldia);
                var query = lista;
                var daia = db.diamateria.ToList<DiaMateria>().Select(u => new DiaMateria
                {
                    dia = u.dia

                }).ToList();
                return query.Union(daia).ToList<DiaMateria>();
            }

        }

        public List<UsuaMensajeVista> profemensaje(int id_usua)
        {
            using (var db = new Mapeo("public"))
            {
                List<UsuaMensajeVista> listmen = new List<UsuaMensajeVista>();
                UsuaMensajeVista ddlprof = new UsuaMensajeVista();
                ddlprof.id_usua = 0;
                ddlprof.nombre_usua = "Selec.";
                listmen.Add(ddlprof);
                var query = listmen;

                var profmensa = (from estcur in db.estudiantecurso
                                 join anicur in db.aniocurso on estcur.id_ec_curso equals anicur.id_ancu
                                 join curmar in db.cursomateria on anicur.id_ancu equals curmar.id_cm_curso
                                 join us in db.usuario on curmar.id_cm_profesor equals us.id_usua
                                 where estcur.id_ec_estudiante == id_usua
                                 select new
                                 {
                                     us.id_usua,
                                     us.nombre_usua,
                                     us.apellido_usua,
                                     us.correo
                                 }).ToList().Select(d => new UsuaMensajeVista
                                 {
                                     id_usua = d.id_usua,
                                     nombre_usua = d.nombre_usua + " " + d.apellido_usua,
                                     correo = d.correo

                                 }).ToList();

                return query.Union(profmensa).ToList<UsuaMensajeVista>();
                //return profmensa.ToList<UsuaMensajeVista>();

            }
        }

        public List<Usuario> obtenerAcudiente(UUser dat)
        {

            Usuario usua = new Usuario();
            int doc = int.Parse(dat.Documento);

            using (var db = new Mapeo("public"))
            {

                var acudi = db.usuario.ToList<Usuario>().Where(x => x.num_documento == doc).Where(g => g.rol_id == 4);

                return acudi.ToList<Usuario>();


            }

        }

        public UUser inicio()
        {
            UUser usua = new UUser();

            using (var db = new Mapeo("public"))
            {
                var result = db.inicio.SingleOrDefault(x => x.id_inicio == 1);
                if (result != null)
                {
                    usua.Inicio = result.inicio_cont;
                    usua.Mision = result.mision_inicio;
                    usua.Vision = result.vision_inicio;
                }
                else
                {

                }
            }
            return usua;
        }

        public void editarInicio(UUser enc)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.inicio.SingleOrDefault(x => x.id_inicio == 1);
                if (result != null)
                {
                    result.inicio_cont = enc.Inicio;
                    result.mision_inicio = enc.Mision;
                    result.vision_inicio = enc.Vision;

                    result.sesion = enc.Session;
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
                    db.SaveChanges();

                }
            }
            //return uuser;

        }

        public List<AcudienteEstudianteVista> listarEstAcudiente(string usu)
        {

            using (var db = new Mapeo("public"))
            {
                //List<AcudienteEstudianteVista> list = null;
                //AcudienteEstudianteVista ddlestac = new AcudienteEstudianteVista();
                //ddlestac.id_usua = 0;
                //ddlestac.nombre_usua = "Selec.";
                //list.Add(ddlestac);
                //var query = list;
                List<AcudienteEstudianteVista> lista = new List<AcudienteEstudianteVista>();
                AcudienteEstudianteVista ddlacu = new AcudienteEstudianteVista();
                ddlacu.id_usua = 0;
                ddlacu.nombre_usua = "Select";
                lista.Add(ddlacu);
                var q = lista;
                int usuacu = int.Parse(usu);
                var estacu = (from us in db.usuario
                              join acu in db.acudiente on us.id_usua equals acu.id_ac_estudiante
                              where acu.id_ac_acudiente == usuacu
                              select new
                              {
                                  us.id_usua,
                                  us.nombre_usua,
                                  us.apellido_usua


                              }).ToList().Select(y => new AcudienteEstudianteVista
                              {
                                  id_usua = y.id_usua,
                                  nombre_usua = y.nombre_usua + " " + y.apellido_usua
                              }).ToList();
                //      return query.Union(estacu).ToList<AcudienteEstudianteVista>();
                return q.Union(estacu).ToList<AcudienteEstudianteVista>();




            }

        }

        public List<CursoAnioVista> obtenerCursoanio(int anio)
        {
            using (var db = new Mapeo("public"))
            {

                List<CursoAnioVista> lista = null;
                CursoAnioVista curddl = new CursoAnioVista();
                lista = new List<CursoAnioVista>();
                curddl.id_ancu = 0;
                curddl.nombre_curso = "Selec.";
                lista.Add(curddl);
                var query = lista;
                var curso = (from ani in db.anio
                             join anicur in db.aniocurso on ani.id_anio equals anicur.id_ancu_anio
                             join cur in db.curso on anicur.id_ancu_curso equals cur.id_curso
                             where anicur.id_ancu_anio == anio
                             select new
                             {
                                 anicur.id_ancu,
                                 cur.nombre_curso
                             }
                        ).ToList().Select(ob => new CursoAnioVista
                        {
                            id_ancu = ob.id_ancu,
                            nombre_curso = ob.nombre_curso
                        }).ToList();
                return query.Union(curso).ToList<CursoAnioVista>();
            }

        }

        public List<Ciudad> ciudad(int idDepart)
        {
            using (var db = new Mapeo("public"))
            {
                List<Ciudad> lista = null;
                Ciudad ciuddl = new Ciudad();
                lista = new List<Ciudad>();
                ciuddl.id_ciudad = 0;
                ciuddl.nombre_ciudad = "Selec.";
                ciuddl.id_c_depart = 0;
                lista.Add(ciuddl);
                var query = lista;
                var ciu = db.ciudad.ToList<Ciudad>().Where(x => x.id_c_depart == idDepart).OrderBy(y => y.nombre_ciudad);

                return query.Union(ciu).ToList<Ciudad>();
            }
        }

        public List<Departamento> select()
        {
            List<Departamento> lista = null;
            Departamento dep = new Departamento();
            lista = new List<Departamento>();
            dep.id_dep = 0;
            dep.nom_dep = "Selec.";
            lista.Add(dep);
            return lista;
        }

        public List<Usuario> listarProfesores()
        {

            using (var db = new Mapeo("public"))
            {
                var profe = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 2);
                return profe.ToList<Usuario>();
            }
        }

        public List<Usuario> listadiploma(string docEstudiante)
        {
            int doc = int.Parse(docEstudiante);
            using (var db = new Mapeo("public"))
            {
                var docestudante = db.usuario.ToList<Usuario>().Where(x => x.num_documento == doc);
                return docestudante.ToList<Usuario>();
            }



        }

        public List<Usuario> listaEstcurso(int curso)
        {
            using (var db = new Mapeo("public"))
            {
                return (from us in db.usuario
                        join estcur in db.estudiantecurso on us.id_usua equals estcur.id_ec_estudiante
                        join anicur in db.aniocurso on estcur.id_ec_curso equals anicur.id_ancu
                        join cur in db.curso on anicur.id_ancu_curso equals cur.id_curso
                        where anicur.id_ancu == curso
                        select us).ToList<Usuario>();

            }
        }

        public List<CursoDeEstudianteVista> obtenerCursoEst(UUser dat)
        {
            using (var db = new Mapeo("public"))
            {
                int est = int.Parse(dat.Id_estudiante);
                int aniio = int.Parse(dat.Año);
                return (from estudiantecurso in db.estudiantecurso
                        join aniocurso in db.aniocurso on estudiantecurso.id_ec_curso equals aniocurso.id_ancu
                        join anio in db.anio on aniocurso.id_ancu_anio equals anio.id_anio
                        join curso in db.curso on aniocurso.id_ancu_curso equals curso.id_curso
                        where estudiantecurso.id_ec_estudiante == est
                        where anio.id_anio == aniio
                        select new
                        {
                            aniocurso.id_ancu,
                            curso.id_curso,
                            curso.nombre_curso

                        })
                        .ToList().Select(m => new CursoDeEstudianteVista
                        {
                            id_ancu = m.id_ancu,
                            id_curso = m.id_curso,
                            nombre_curso = m.nombre_curso

                        }).ToList();
            }
        }

        public List<Usuario> listarEstudiantes()
        {

            using (var db = new Mapeo("public"))
            {
                var estudiante = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 3);
                return estudiante.ToList<Usuario>();
            }
        }

        public List<Usuario> listarAcudientes()
        {
            using (var db = new Mapeo("public"))
            {
                var estudiante = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 4);
                return estudiante.ToList<Usuario>();
            }
        }

        public List<ListaAcudiente> listarAcudientesEstudiante()
        {
            using (var db = new Mapeo("public"))
            {
                return (from c in db.usuario
                        join o in db.acudiente on c.id_usua equals o.id_ac_estudiante
                        where c.rol_id == 4
                        select new
                        {
                            c.foto_usua,
                            c.apellido_usua,
                            c.nombre_usua,
                            c.num_documento,
                            c.telefono,
                            c.user_name,
                            c.clave
                        })
                        .ToList().Select(m => new ListaAcudiente
                        {
                            fotoacudiente = m.foto_usua,
                            apeacudiente = m.apellido_usua,
                            nomacudiente = m.nombre_usua,
                            docacudiente = m.num_documento,
                            telefonoacudiente = m.telefono,
                            useracudiente = m.user_name,
                            claveacudiente = m.clave

                        }).ToList();
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

        ///LISTAR PARA EDIAR CON MAPEO////


        public void insertarEstudiante(UUser dat)
        {
            Usuario usua = new Usuario();
            Acudiente acu = new Acudiente();
            UUser uuser = new UUser();
            usua.nombre_usua = dat.Nombre;
            usua.rol_id = int.Parse(dat.Rol);
            usua.user_name = dat.UserName;
            usua.clave = dat.Clave;
            usua.correo = dat.Correo;
            usua.apellido_usua = dat.Apellido;
            usua.direccion = dat.Direccion;
            usua.telefono = dat.Telefono;
            usua.num_documento = int.Parse(dat.Documento);
            usua.foto_usua = dat.Foto;
            acu.id_ac_acudiente = int.Parse(dat.id_Acudiente);
            usua.fecha_nac = dat.fecha_nacimiento;
            usua.dep_nacimiento = int.Parse(dat.Departamento);
            usua.ciu_nacimiento = int.Parse(dat.Ciudad);
            usua.sesion = dat.Session;
            uuser.Documento = dat.Documento;
            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(usua);
                db.SaveChanges();

                uuser = obtenerUsuarioMod(uuser);
                acu.id_ac_estudiante = int.Parse(uuser.IdUsua);
                insertarAcudientedesdeEstudiante(acu);
            }

        }


        public void insertarAcudientedesdeEstudiante(Acudiente acu)
        {
            DMSeguridad dmseg = new DMSeguridad();
            MEncAcudiente encacu = new MEncAcudiente();
            encacu.id_ac_acudiente_nuevo = acu.id_ac_acudiente;
            encacu.id_ac_estudiante_nuevo = acu.id_ac_estudiante;
            dmseg.fiel_auditoria_agrega_acudiente("INSERT", encacu);

            using (var db = new Mapeo("public"))
            {
                db.acudiente.Add(acu);
                db.SaveChanges();
            }

        }


        public UUser obtenerUsuarioMod(UUser us)
        {

            UIdioma encId = new UIdioma();
            UUser usua = new UUser();
            Usuario enc = new Usuario();
            int doc = int.Parse(us.Documento);
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == doc);
                if (result != null)
                {
                    usua.IdUsua = result.id_usua.ToString();
                    usua.Nombre = result.nombre_usua;
                    usua.Rol = result.rol_id.ToString();
                    usua.UserName = result.user_name;
                    usua.Clave = result.clave;
                    usua.Correo = result.correo;
                    usua.Estado = result.estado.ToString();
                    usua.Apellido = result.apellido_usua;
                    usua.Direccion = result.direccion;
                    usua.Telefono = result.telefono;
                    usua.Documento = result.num_documento.ToString();
                    usua.Foto = result.foto_usua;
                    usua.fecha_nacimiento = result.fecha_nac;
                    usua.Departamento = result.dep_nacimiento.ToString();
                    usua.Ciudad = result.ciu_nacimiento.ToString();
                    usua.Session = result.sesion;
                }
                else
                {
                    usua.Mensaje = encId.CompIdioma["L_ErrorAdmin_sin_registro"].ToString(); //"Sin Registros";
                }
            }
            return usua;
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
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
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
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
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
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
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
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
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
                    result.ultima_modificacion = (DateTime.Now.ToShortDateString());
                    db.SaveChanges();

                }
            }
            return uuser;

        }

        public bool validarUser(Usuario usuario)
        {
            UUser uuser = new UUser();
            UIdioma encId = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.num_documento == usuario.num_documento);
                var resulta = db.usuario.SingleOrDefault(y => y.user_name == usuario.user_name);

                if (result != null || resulta != null)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }


        }

        public List<Usuario> obtenerCertificadoEst(String reg)
        {
            using (var db = new Mapeo("public"))
            {
                int usu = int.Parse(reg);
                var est = db.usuario.ToList<Usuario>().Where(x => x.rol_id == 3).Where(x => x.id_usua == usu);
                return est.ToList<Usuario>();
            }

        }

        public List<Usuario> gEstudiante(int curs)
        {
            using (var db = new Mapeo("public"))
            {
                return (from usuario in db.usuario
                        join estudiantecurso in db.estudiantecurso on usuario.id_usua equals estudiantecurso.id_ec_estudiante
                        join aniocurso in db.aniocurso on estudiantecurso.id_ec_curso equals aniocurso.id_ancu
                        join curso in db.curso on aniocurso.id_ancu_curso equals curso.id_curso
                        where aniocurso.id_ancu == curs
                        select usuario).ToList<Usuario>();
            }
        }

        public void guardadoSession(Autenticacion aut)
        {
            using (var db = new Mapeo("public"))
            {
                db.autenticacion.Add(aut);
                db.SaveChanges();
            }
        }

        public int IdUsuadeUser(string user)
        {
            List<Usuario> lusua = new List<Usuario>();
            int us = 0;
            using (var db = new Mapeo("public"))
            {
                lusua = db.usuario.ToList<Usuario>().Where(x => x.user_name.Contains(user)).ToList();
                foreach (Usuario u in lusua)
                {
                    us = u.id_usua;
                }
                return us;
            }
        }

        public int Capturafechaintentosesion(string Usuario)
        {
            List<Sesion> ses = new List<Sesion>();
            DateTime fe = new DateTime();
            using (var db = new Mapeo("public"))
            {
                ses = db.sesion.ToList<Sesion>().Where(x => x.IdUsuario == IdUsuadeUser(Usuario)).ToList();
                foreach (Sesion s in ses)
                {
                    fe = DateTime.Parse(s.HoraLibre).AddMinutes(30);
                }

                if (DateTime.Now > fe)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public int evaluaSesiones(string usuario)
        {
            List<Sesion> ses = new List<Sesion>();
            int sesionActiva = 0;
            int sesionUsuario = 0;
            using (var db = new Mapeo("public"))
            {
                ses = db.sesion.ToList<Sesion>().Where(x => x.IdUsuario == IdUsuadeUser(usuario)).ToList();
                foreach (Sesion s in ses)
                {
                    sesionActiva = (s.SesionActiva);
                    sesionUsuario = (s.SesionUsuario);
                }

                if (sesionActiva >= sesionUsuario)
                {
                    return 0;
                }
                else
                {
                    editarSumSesion(IdUsuadeUser(usuario));
                    return 1;
                }
            }

        }

        public void editarSumSesion(int usuario)
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdUsuario == usuario);
                if (result != null)
                {
                    result.SesionActiva = ((result.SesionActiva) + 1);
                    db.SaveChanges();
                }
            }
        }

        public void LimpiaIntentosErroneos(string usuario)
        {
            int u = IdUsuadeUser(usuario);
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdUsuario == u);
                if (result != null)
                {
                    result.IntentosErroneos = 0;
                    db.SaveChanges();
                }
            }
        }

        public List<Usuario> generarToken(String user_name)
        {
            Usuario us = new Usuario();
            List<Usuario> lus = new List<Usuario>();
            List<TokenRecuperaUsuario> ltru = new List<TokenRecuperaUsuario>();
            DateTime fecreado = new DateTime();
            DateTime fevigencia = new DateTime();
            using (var db = new Mapeo("public"))
            {
                var q = db.usuario.ToList<Usuario>().Where(x => x.user_name.Contains(user_name)).ToList<Usuario>();
                var pru = (from usuario in db.usuario
                           join tokenRecuperaUsuarios in db.tokenRecuperaUsuarios on usuario.id_usua equals tokenRecuperaUsuarios.id_usuario
                           where usuario.user_name == user_name
                           select tokenRecuperaUsuarios).ToList<TokenRecuperaUsuario>();
                foreach (TokenRecuperaUsuario t in pru)
                {
                    fecreado = DateTime.Parse(t.fecha_creado);
                    fevigencia = DateTime.Parse(t.fecha_vigencia);

                }
                var j = (from usuario in db.usuario
                         join tokenRecuperaUsuarios in db.tokenRecuperaUsuarios on usuario.id_usua equals tokenRecuperaUsuarios.id_usuario
                         where DateTime.Now >= fecreado
                         where DateTime.Now <= fevigencia
                         where usuario.user_name == user_name
                         select usuario).ToList<Usuario>();
                if (q.Count == 0)
                {
                    us.id_usua = -1;
                    us.nombre_usua = "";
                    us.rol_id = 1;
                    us.user_name = "";
                    us.clave = "";
                    us.correo = "";
                    us.estado = true;
                    us.apellido_usua = "";
                    us.direccion = "";
                    us.telefono = "";
                    us.num_documento = 1;
                    us.foto_usua = "";
                    us.fecha_nac = "";
                    us.dep_nacimiento = 1;
                    us.ciu_nacimiento = 1;
                    us.sesion = "";
                    us.ultima_modificacion = (DateTime.Now.ToShortDateString());
                    us.state_t = 1;
                    lus.Add(us);
                    return lus;
                }
                else if (j.Count > 0)
                {
                    us.id_usua = -2;
                    us.nombre_usua = "";
                    us.rol_id = 1;
                    us.user_name = "";
                    us.clave = "";
                    us.correo = "";
                    us.estado = true;
                    us.apellido_usua = "";
                    us.direccion = "";
                    us.telefono = "";
                    us.num_documento = 1;
                    us.foto_usua = "";
                    us.fecha_nac = "";
                    us.dep_nacimiento = 1;
                    us.ciu_nacimiento = 1;
                    us.sesion = "";
                    us.ultima_modificacion = (DateTime.Now.ToShortDateString());
                    us.state_t = 1;
                    lus.Add(us);
                    return lus;
                }
                else if (q.Count > 0)
                {
                    //Aca hace un Update
                    editarStateGenerarToken(user_name);
                    //Lista
                    var query = db.usuario.ToList<Usuario>();
                    return query.ToList();
                }
                else
                {
                    us.id_usua = -1;
                    us.nombre_usua = "";
                    us.rol_id = 1;
                    us.user_name = "";
                    us.clave = "";
                    us.correo = "";
                    us.estado = true;
                    us.apellido_usua = "";
                    us.direccion = "";
                    us.telefono = "";
                    us.num_documento = 1;
                    us.foto_usua = "";
                    us.fecha_nac = "";
                    us.dep_nacimiento = 1;
                    us.ciu_nacimiento = 1;
                    us.sesion = "";
                    us.ultima_modificacion = (DateTime.Now.ToShortDateString());
                    us.state_t = 1;
                    lus.Add(us);
                    return lus;
                }
            }
        }

        public void editarStateGenerarToken(String user_name) //Funcion Editar de Generar Token
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.usuario.SingleOrDefault(x => x.user_name == user_name);
                if (result != null)
                {
                    result.state_t = 2;
                    db.SaveChanges();
                }
            }
        }

        public void InsertaTablaSesion(string usuario)
        {
            int us = IdUsuadeUser(usuario);
            Sesion lusua = new Sesion();
            using (var db = new Mapeo("public"))
            {
                lusua.IdUsuario = us;
                lusua.SesionUsuario = 2;
                lusua.SesionActiva = 0;
                lusua.IntentosErroneos = 0;
                lusua.HoraLibre = "1946-09-05 09:30:00.21804-05";
                db.sesion.Add(lusua);
                db.SaveChanges();
            }
        }

        public int sumaIntentosErroneos(string usuario)
        {
            List<Sesion> ses = new List<Sesion>();
            int intentosErroneos = 0;
            using (var db = new Mapeo("public"))
            {
                ses = db.sesion.ToList<Sesion>().Where(x => x.IdUsuario == IdUsuadeUser(usuario)).ToList();
                foreach (Sesion s in ses)
                {
                    intentosErroneos = (s.IntentosErroneos);
                }

                if (intentosErroneos > 2)
                {
                    return 0;
                }
                else
                {
                    editarSumIntErroneos(IdUsuadeUser(usuario));
                    return 1;
                }
            }

        }

        public void editarSumIntErroneos(int usuario)
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdUsuario == usuario);
                if (result != null)
                {
                    result.IntentosErroneos = ((result.IntentosErroneos) + 1);
                    db.SaveChanges();
                }
            }
        }

        public void actualizaFechaSesionErronea(string usuario)
        {
            List<Sesion> ses = new List<Sesion>();
            int intentosErroneos = 0;
            using (var db = new Mapeo("public"))
            {
                ses = db.sesion.ToList<Sesion>().Where(x => x.IdUsuario == IdUsuadeUser(usuario)).ToList();
                foreach (Sesion s in ses)
                {
                    intentosErroneos = (s.IntentosErroneos);
                }

                if (intentosErroneos == 3)
                {
                    editarAcrtualizaHora(IdUsuadeUser(usuario));
                }
            }

        }

        public void editarAcrtualizaHora(int usuario)
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdUsuario == usuario);
                if (result != null)
                {
                    result.HoraLibre = DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    db.SaveChanges();
                }
            }
        }

        public void LimpiaSesionesActivas(string usuario)
        {
            int usua = IdUsuadeUser(usuario);
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdUsuario == usua);
                if (result != null)
                {
                    result.SesionActiva = ((result.SesionActiva) - 1);
                    db.SaveChanges();
                }
            }
        }

        public void cerrarSession(UUser datos)
        {
            List<Autenticacion> au = new List<Autenticacion>();
            using (var db = new Mapeo("public"))
            {
                au = (db.autenticacion.ToList<Autenticacion>().Where(x => x.session == datos.Session)).ToList();
                foreach (Autenticacion a in au)
                {
                    var result = db.autenticacion.SingleOrDefault(x => x.id == a.id);
                    if (result != null)
                    {
                        result.fecha_fin = (DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                        db.SaveChanges();
                    }
                }
            }
        }

        public void almacenarToken(String token, Int32 userId)
        {
            string fe = (DateTime.Now.ToShortDateString() + " " + ((DateTime.Now.Hour) + 2) + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
            //DateTime fe = DateTime.Parse(DateTime.Now.ToShortDateString() + " " + (DateTime.Now.Hour) + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).AddHours(2);
            TokenRecuperaUsuario tok = new TokenRecuperaUsuario();
            tok.id_usuario = userId;
            tok.token = token;
            tok.fecha_creado = DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            tok.fecha_vigencia = fe.ToString();
            using (var db = new Mapeo("public"))
            {
                db.tokenRecuperaUsuarios.Add(tok);
                db.SaveChanges();
            }
        }

        public int obtenerUsusarioToken(String token)
        {
            int id = 0;
            DateTime fecreado = new DateTime();
            DateTime fevigencia = new DateTime();
            List<TokenRecuperaUsuario> tr = new List<TokenRecuperaUsuario>();
            using (var db = new Mapeo("public"))
            {
                var q = db.tokenRecuperaUsuarios.ToList<TokenRecuperaUsuario>().Where(x => x.token.Contains(token)).ToList();

                var pru = db.tokenRecuperaUsuarios.ToList<TokenRecuperaUsuario>().Where(x => x.token.Contains(token)).ToList();

                foreach (TokenRecuperaUsuario t in pru)
                {
                    fecreado = DateTime.Parse(t.fecha_creado);
                    fevigencia = DateTime.Parse(t.fecha_vigencia);

                }

                var j = db.tokenRecuperaUsuarios.ToList<TokenRecuperaUsuario>().Where(x => x.token.Contains(token))
                                                                               .Where(x => DateTime.Now >= fecreado)
                                                                               .Where(x => DateTime.Now <= fevigencia).ToList();

                if (q.Count == 0)
                {
                    return -1;
                }
                else if (j.Count == 0)
                {
                    var result = db.tokenRecuperaUsuarios.SingleOrDefault(x => x.token == token);
                    if (result != null)
                    {
                        db.tokenRecuperaUsuarios.Remove(result);
                        db.SaveChanges();
                    }
                    return -2;
                }
                else
                {
                    tr = db.tokenRecuperaUsuarios.ToList<TokenRecuperaUsuario>().Where(x => x.token.Contains(token)).ToList();

                    foreach (TokenRecuperaUsuario t in tr)
                    {
                        id = t.id_usuario;
                    }
                    return id;
                }
            }
        }

        public void actualziarContrasena(UContrasenia datos)
        {
            using (var db = new Mapeo("public"))
            {
                //Delete
                var result = db.tokenRecuperaUsuarios.SingleOrDefault(x => x.id_usuario == datos.UserId);
                if (result != null)
                {
                    db.tokenRecuperaUsuarios.Remove(result);
                    db.SaveChanges();
                }

                //Update
                var resu = db.usuario.SingleOrDefault(x => x.id_usua == datos.UserId);
                if (resu != null)
                {
                    resu.state_t = 1;
                    resu.clave = datos.Clave;
                    db.SaveChanges();
                }
            }
        }


        //Funcion QUe se Migra de BD
        public DataTable listaacuestu()
        {
            DataTable list = new DataTable();

            DUser postgres = new DUser();
            DSql sqlserver = new DSql();

            using (var db = new Mapeo("public"))
            {
                if ((db.Database.Connection).ToString() == "Npgsql.NpgsqlConnection")
                {
                    list = postgres.listaacuestu();
                }
                else
                {
                    list = sqlserver.listaacuestu();
                }
            }
            return list;
        }


        public DataTable listaestsincurso()
        {
            DataTable list = new DataTable();

            DUser postgres = new DUser();
            DSql sqlserver = new DSql();

            using (var db = new Mapeo("public"))
            {
                if ((db.Database.Connection).ToString() == "Npgsql.NpgsqlConnection")//"System.Data.SqlClient.SqlConnection"
                {
                    list = postgres.listaestsincurso();
                }
                else
                {
                    list = sqlserver.listaestsincurso();
                }
            }
            return list;
        }
    }
}
