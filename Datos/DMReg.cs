using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using Utilitarios.Mregistro;
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
                        join diam in db.diamateria on  matf.id_mf_fecha equals diam.id_dia_materia
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

        public void insertarMateria(Materia mat)
        {

            using (var db = new Mapeo("public"))
            {
                db.materia.Add(mat);
                db.SaveChanges();
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



    }
}
