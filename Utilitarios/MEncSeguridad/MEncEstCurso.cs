using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncEstCurso
    {
        private String Id_ec_nuevo;
        private String Id_ec_estudiante_nuevo;
        private String Id_ec_curso_nuevo;
        private String Id_ec_anterior;
        private String Id_ec_estudiante_old;
        private String Id_ec_curso_old;
        private String Id_ec_estudiante_anterior;
        private String Id_ec_curso_anterior;

        public string id_ec_nuevo { get => Id_ec_nuevo; set => Id_ec_nuevo = value; }
        public string id_ec_estudiante_nuevo { get => Id_ec_estudiante_nuevo; set => Id_ec_estudiante_nuevo = value; }
        public string id_ec_curso_nuevo { get => Id_ec_curso_nuevo; set => Id_ec_curso_nuevo = value; }
        public string id_ec_anterior { get => Id_ec_anterior; set => Id_ec_anterior = value; }
        public string id_ec_estudiante_old { get => Id_ec_estudiante_old; set => Id_ec_estudiante_old = value; }
        public string id_ec_curso_old { get => Id_ec_curso_old; set => Id_ec_curso_old = value; }
        public string id_ec_estudiante_anterior { get => Id_ec_estudiante_anterior; set => Id_ec_estudiante_anterior = value; }
        public string id_ec_curso_anterior { get => Id_ec_curso_anterior; set => Id_ec_curso_anterior = value; }
    }
}
