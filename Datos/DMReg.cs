using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using Utilitarios.Mregistro;
using Utilitarios.MVistasUsuario;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMReg
    {
        public List<HorarioEstudiante> horarioEstudiante(int id)
        {
            using (var db = new Mapeo("public"))
            {
                return (from usua in db.usuario
                        join est in db.estudiantecurso on usua.id_usua equals est.id_ec_estudiante
                        join an in db.aniocurso on est.id_ec_curso equals an.id_ancu
                        join cur in db.cursomateria on an.id_ancu equals cur.id_cm_curso
                        join matf in db.materiafecha on cur.id_cm_materia equals matf.id_mf
                        join diam in db.diamateria on matf.id_mf_fecha equals diam.id_dia_materia
                        join mat in db.materia on matf.id_mf_materia equals mat.id_materia
                        where usua.id_usua == id

                        select new
                        {
                            mat.nombre_materia,
                            diam.dia,
                            diam.hora_inicio,
                            diam.hora_fin

                        })
                        .ToList().Select(h => new HorarioEstudiante
                        {
                            nombre_materia = h.nombre_materia,
                            dia = h.dia,
                            hora_inicio = h.hora_inicio,
                            hora_fin = h.hora_fin


                        }).ToList();
            }
        }

        public List<HorarioEstudiante> horarioCurso(int id)
        {
            using (var db = new Mapeo("public"))
            {
                return (from cursomateria in db.cursomateria
                        join aniocurso in db.aniocurso on cursomateria.id_cm_curso equals aniocurso.id_ancu
                        join materiafecha in db.materiafecha on cursomateria.id_cm_materia equals materiafecha.id_mf
                        join curso in db.curso on aniocurso.id_ancu_curso equals curso.id_curso
                        join materia in db.materia on materiafecha.id_mf_materia equals materia.id_materia
                        join diamateria in db.diamateria on materiafecha.id_mf_fecha equals diamateria.id_dia_materia
                        join usuario in db.usuario on cursomateria.id_cm_profesor equals usuario.id_usua
                        where aniocurso.id_ancu == id

                        select new
                        {
                            materia.id_materia,
                            usuario.nombre_usua,
                            usuario.apellido_usua,
                            materia.nombre_materia,
                            diamateria.dia,
                            diamateria.hora_inicio,
                            diamateria.hora_fin
                        })
                        .ToList().Select(h => new HorarioEstudiante
                        {
                            nombre_materia = h.nombre_materia + " " + h.nombre_usua + " " + h.apellido_usua.Substring(0, 1) + ".",
                            dia = h.dia,
                            hora_inicio = h.hora_inicio,
                            hora_fin = h.hora_fin

                        }).ToList();
            }
        }

        public List<HorarioEstudiante> horarioProfesor(int id)
        {
            using (var db = new Mapeo("public"))
            {
                return (from usuario in db.usuario
                        join cursomateria in db.cursomateria on usuario.id_usua equals cursomateria.id_cm_profesor
                        join materiafecha in db.materiafecha on cursomateria.id_cm_materia equals materiafecha.id_mf
                        join diamateria in db.diamateria on materiafecha.id_mf_fecha equals diamateria.id_dia_materia
                        join materia in db.materia on materiafecha.id_mf_materia equals materia.id_materia
                        join aniocurso in db.aniocurso on cursomateria.id_cm_curso equals aniocurso.id_ancu
                        join curso in db.curso on aniocurso.id_ancu_curso equals curso.id_curso
                        where usuario.id_usua == id

                        select new
                        {
                            materia.nombre_materia,
                            diamateria.dia,
                            diamateria.hora_inicio,
                            diamateria.hora_fin

                        })
                        .ToList().Select(h => new HorarioEstudiante
                        {
                            nombre_materia = h.nombre_materia,
                            dia = h.dia,
                            hora_inicio = h.hora_inicio,
                            hora_fin = h.hora_fin


                        }).ToList();
            }
        }

        public void insertarMateria(Materia mat)
        {
            using (var db = new Mapeo("public"))
            {
                db.materia.Add(mat);
                db.SaveChanges();

                string materia = mat.nombre_materia;
                List<Materia> matlist = (db.materia.ToList<Materia>().Where(x => x.nombre_materia.Contains(materia))).ToList<Materia>();

                MateriaFecha matfe = new MateriaFecha();
                foreach (Materia m in matlist)
                {
                    matfe.id_mf_materia = m.id_materia;
                    for (int i = 1; i <= 20; i++)
                    {
                        matfe.id_mf_fecha = i;
                        db.materiafecha.Add(matfe);
                        db.SaveChanges();
                    }
                }
            }

        }

        public bool validaMateria(Materia materia)
        {
            UUser umate = new UUser();
            UIdioma encId = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                var resultado = db.materia.SingleOrDefault(x => x.nombre_materia == materia.nombre_materia);
                if (resultado == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        public List<Observador> listarObservador(string dat)
        {
            Usuario user = new Usuario();
            using (var db = new Mapeo("public"))
            {

                var ingres = db.observador.ToList<Observador>().Where(x => x.id_estudiante == int.Parse(dat));
                if (ingres != null)
                {
                    return ingres.ToList<Observador>();
                }
                else
                {
                    return null;
                }

            }
        }

        public List<Boletin> obtenerBoletin(string usu, string ancu)
        {
            using (var db = new Mapeo("public"))
            {
                int us = int.Parse(usu);
                int anc = int.Parse(ancu);
                return (from nota in db.nota
                        join estudiantecurso in db.estudiantecurso on nota.id_n_estudiante equals estudiantecurso.id_ec
                        join materia in db.materia on nota.id_n_materia equals materia.id_materia
                        join aniocurso in db.aniocurso on estudiantecurso.id_ec_curso equals aniocurso.id_ancu
                        where estudiantecurso.id_ec_estudiante == us
                        where aniocurso.id_ancu == anc
                        select new
                        {
                            materia.nombre_materia,
                            nota.nota1,
                            nota.nota2,
                            nota.nota3,
                            nota.notadef
                        })
                        .ToList().Select(h => new Boletin
                        {
                            nombre_materia = h.nombre_materia,
                            nota1 = h.nota1,
                            nota2 = h.nota2,
                            nota3 = h.nota3,
                            notadef = h.notadef
                        }).ToList();
            }
        }

        public List<Anio> obtenerAniodeCurso(string anio)
        {
            using (var db = new Mapeo("public"))
            {
                var anioo = db.anio.ToList<Anio>().Where(x => x.nombre_anio.Contains(anio)).Select(j => new Anio
                {
                    id_anio = j.id_anio,
                    nombre_anio = j.nombre_anio.Substring(0, 4)

                }).ToList();

                return (anioo).ToList<Anio>();
            }
        }

        public List<CursoAnioVista> cursoProfesor(string id_p, string anio)
        {
            using (var db = new Mapeo("public"))
            {
                int an = int.Parse(anio);
                int profe = int.Parse(id_p);
                List<CursoAnioVista> lista = null;
                CursoAnioVista curanio = new CursoAnioVista();
                lista = new List<CursoAnioVista>();
                curanio.id_ancu = 0;
                curanio.nombre_curso = "Selec.";
                lista.Add(curanio);
                var query = lista;
                return lista.ToList<CursoAnioVista>().Union((from curso in db.curso
                                                             join aniocurso in db.aniocurso on curso.id_curso equals aniocurso.id_ancu_curso
                                                             join cursomateria in db.cursomateria on aniocurso.id_ancu equals cursomateria.id_cm_curso
                                                             where aniocurso.id_ancu_anio == an
                                                             where cursomateria.id_cm_profesor == profe
                                                             select new
                                                             {
                                                                 aniocurso.id_ancu,
                                                                 curso.nombre_curso,

                                                             })
                        .ToList().Select(m => new CursoAnioVista
                        {
                            id_ancu = m.id_ancu,
                            nombre_curso = m.nombre_curso

                        }).ToList()).ToList<CursoAnioVista>();
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

        public List<Materia> obtenermateriacurso(string Curso, string Prof)
        {
            using (var db = new Mapeo("public"))
            {
                int cur = int.Parse(Curso);
                int profe = int.Parse(Prof);
                List<Materia> lista = null;
                Materia mat = new Materia();
                lista = new List<Materia>();
                mat.id_materia = 0;
                mat.nombre_materia = "Selec.";
                lista.Add(mat);
                var query = lista;
                return lista.ToList<Materia>().Union((from materia in db.materia
                                                      join materiafecha in db.materiafecha on materia.id_materia equals materiafecha.id_mf_materia
                                                      join cursomateria in db.cursomateria on materiafecha.id_mf equals cursomateria.id_cm_materia
                                                      where cursomateria.id_cm_curso == cur
                                                      where cursomateria.id_cm_profesor == profe

                                                      select materia)
                                                    .ToList()).ToList<Materia>();
            }
        }

        public List<UsuaMensajeVista> obtenerEstApel(int curs)
        {
            using (var db = new Mapeo("public"))
            {

                List<UsuaMensajeVista> lista = null;
                UsuaMensajeVista est = new UsuaMensajeVista();
                lista = new List<UsuaMensajeVista>();
                est.id_usua = 0;
                est.nombre_usua = "Selec.";
                est.Correo = " ";
                lista.Add(est);
                var query = lista;
                return lista.ToList<UsuaMensajeVista>().Union((from estudiantecurso in db.estudiantecurso
                                                               join usuario in db.usuario on estudiantecurso.id_ec_estudiante equals usuario.id_usua
                                                               join aniocurso in db.aniocurso on estudiantecurso.id_ec_curso equals aniocurso.id_ancu
                                                               join curso in db.curso on aniocurso.id_ancu_curso equals curso.id_curso
                                                               where aniocurso.id_ancu == curs

                                                               select new
                                                               {
                                                                   usuario.id_usua,
                                                                   usuario.nombre_usua,
                                                                   usuario.apellido_usua

                                                               })
                        .ToList().Select(m => new UsuaMensajeVista
                        {
                            id_usua = m.id_usua,
                            nombre_usua = m.nombre_usua + " " + m.apellido_usua

                        }).ToList()).ToList<UsuaMensajeVista>();
            }
        }

        public List<Nota> obtenerNota(UUser dat)
        {
            using (var db = new Mapeo("public"))
            {
                int est = int.Parse(dat.Id_estudiante);
                int cur = int.Parse(dat.Curso);
                int mat = int.Parse(dat.Materia);
                return (from nota in db.nota
                        join estudiantecurso in db.estudiantecurso on nota.id_n_estudiante equals estudiantecurso.id_ec
                        join materia in db.materia on nota.id_n_materia equals materia.id_materia
                        join aniocurso in db.aniocurso on estudiantecurso.id_ec_curso equals aniocurso.id_ancu
                        where estudiantecurso.id_ec_estudiante == est
                        where aniocurso.id_ancu == cur
                        where materia.id_materia == mat

                        select nota
                        )
                       .ToList<Nota>();
            }
        }

        public void insertarNota(Nota dat)
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.nota.SingleOrDefault(x => x.id_nota == dat.id_nota);
                if (result != null)
                {
                    result.nota1 = dat.nota1;
                    result.nota2 = dat.nota2;
                    result.nota3 = dat.nota3;
                    result.notadef = dat.notadef;
                    db.SaveChanges();

                }
            }


        }

        public void insertarEstudianteCurso(EstudianteCurso est)
        {
            using (var db = new Mapeo("public"))
            {
                db.estudiantecurso.Add(est);
                db.SaveChanges();
            }
        }

        public List<Materia> obtener_MatCur(UUser reg)
        {
            int cur = int.Parse(reg.Curso);
            using (var db = new Mapeo("public"))
            {
                return (from materia in db.materia
                        join materiafecha in db.materiafecha on materia.id_materia equals materiafecha.id_mf_materia
                        join cursomateria in db.cursomateria on materiafecha.id_mf equals cursomateria.id_cm_materia
                        where cursomateria.id_cm_curso == cur
                        select materia
                        ).ToList();

            }
        }

        public List<Materia> obtenermateriadecurso(int reg)
        {
            using (var db = new Mapeo("public"))
            {
                return (from materia in db.materia
                        join materiafecha in db.materiafecha on materia.id_materia equals materiafecha.id_mf_materia
                        join cursomateria in db.cursomateria on materiafecha.id_mf equals cursomateria.id_cm_materia
                        where cursomateria.id_cm_curso == reg
                        select materia
                        ).ToList();

            }
        }

        public void insertarNotaMateria(UUser enc)
        {
            Nota not = new Nota();
            using (var db = new Mapeo("public"))
            {
                not.id_n_estudiante = obtenerIdestcur(int.Parse(enc.Id_estudiante));
                not.id_n_materia = int.Parse(enc.Materia);
                not.nota1 = 1;
                not.nota2 = 1;
                not.nota3 = 1;
                not.notadef = 1;
                db.nota.Add(not);
                db.SaveChanges();
            }
        }

        public int obtenerIdestcur(int idest)  ///Funcion de obtener_MatCur
        {
            List<EstudianteCurso> estuu = new List<EstudianteCurso>();
            int r = 0;
            using (var db = new Mapeo("public"))

            {
                var est = db.estudiantecurso.ToList<EstudianteCurso>().Where(x => x.id_ec_estudiante == idest);
                estuu = (est).ToList<EstudianteCurso>();

                foreach (EstudianteCurso e in estuu)
                {
                    r = e.id_ec;
                }
                return r;
            }

        }

        public List<MateriaFecha> obtenerHora(UUser reg)
        {
            using (var db = new Mapeo("public"))
            {
                int mat = int.Parse(reg.Materia);
;                return (from materia in db.materia
                        join materiafecha in db.materiafecha on materia.id_materia equals materiafecha.id_mf_materia
                        join diamateria in db.diamateria on materiafecha.id_mf_fecha equals diamateria.id_dia_materia
                        where materia.id_materia == mat
                        where diamateria.dia == reg.Dia_materia
                        where diamateria.hora_inicio == reg.Hora_in

                        select materiafecha
                            )
                           .ToList<MateriaFecha>();
            }
        }

        public void insertarCursoMateria(UUser dat)
        {
            CursoMateria cm = new CursoMateria();
            using (var db = new Mapeo("public"))
            {
                cm.id_cm_curso = int.Parse(dat.Curso);
                cm.id_cm_materia = int.Parse(dat.Cur_mat);
                cm.id_cm_profesor = int.Parse(dat.Id_docente);
                db.cursomateria.Add(cm);
                db.SaveChanges();
            }
        }
    }
}

