using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncEstCurso
    {
       
        private Int32 Id_ec_estudiante_nuevo;
        private Int32 Id_ec_estudiante_old;

        private Int32 Id_ec_curso_nuevo;     
        private Int32 Id_ec_curso_old;
  


        public int id_ec_estudiante_nuevo { get => Id_ec_estudiante_nuevo; set => Id_ec_estudiante_nuevo = value; }
        public int id_ec_curso_nuevo { get => Id_ec_curso_nuevo; set => Id_ec_curso_nuevo = value; }
       
        public int id_ec_estudiante_old { get => Id_ec_estudiante_old; set => Id_ec_estudiante_old = value; }
        public int id_ec_curso_old { get => Id_ec_curso_old; set => Id_ec_curso_old = value; }
     
    }
}
