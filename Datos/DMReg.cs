using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
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





    }
}
