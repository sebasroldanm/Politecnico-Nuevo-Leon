using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncMateriaFecha
    {

        private Int32 Id_mf_materia_nuevo;
        private Int32 Id_mf_materia_old;

        private Int32 Id_mf_fecha_nuevo;  
        private Int32 Id_mf_fecha_old;
 

        public int id_mf_materia_nuevo { get => Id_mf_materia_nuevo; set => Id_mf_materia_nuevo = value; }
        public int id_mf_fecha_nuevo { get => Id_mf_fecha_nuevo; set => Id_mf_fecha_nuevo = value; }
        public int id_mf_materia_old { get => Id_mf_materia_old; set => Id_mf_materia_old = value; }
        public int id_mf_fecha_old { get => Id_mf_fecha_old; set => Id_mf_fecha_old = value; }
    
    }
}
