using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncMateriaFecha
    {

        private String Id_mf_nuevo;
        private String Id_mf_materia_nuevo;
        private String Id_mf_fecha_nuevo;
        private String Id_mf_anterior;
        private String Id_mf_materia_old;
        private String Id_mf_fecha_old;
        private String Id_mf_materia_anterior;
        private String Id_mf_fecha_anterior;

        public string id_mf_nuevo{ get => Id_mf_nuevo; set => Id_mf_nuevo = value; }
        public string id_mf_materia_nuevo { get => Id_mf_materia_nuevo; set => Id_mf_materia_nuevo = value; }
        public string id_mf_fecha_nuevo { get => Id_mf_fecha_nuevo; set => Id_mf_fecha_nuevo = value; }
        public string id_mf_anterior { get => Id_mf_anterior; set => Id_mf_anterior = value; }
        public string id_mf_materia_old { get => Id_mf_materia_old; set => Id_mf_materia_old = value; }
        public string id_mf_fecha_old { get => Id_mf_fecha_old; set => Id_mf_fecha_old = value; }
        public string id_mf_materia_anterior { get => Id_mf_materia_anterior; set => Id_mf_materia_anterior = value; }
        public string id_mf_fecha_anterior { get => Id_mf_fecha_anterior; set => Id_mf_fecha_anterior = value; }
    }
}
