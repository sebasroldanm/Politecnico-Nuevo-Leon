using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncAcudiente
    {
        Int32 Id_ac_estudiante_nuevo;
        Int32 Id_ac_estudiante_old;
        Int32 Id_ac_acudiente_nuevo;       
        Int32 Id_ac_acudiente_old;

        public int id_ac_estudiante_nuevo { get => Id_ac_estudiante_nuevo; set => Id_ac_estudiante_nuevo = value; }
        public int id_ac_estudiante_old { get => Id_ac_estudiante_old; set => Id_ac_estudiante_old = value; }
        public int id_ac_acudiente_nuevo { get => Id_ac_acudiente_nuevo; set => Id_ac_acudiente_nuevo = value; }
        public int id_ac_acudiente_old { get => Id_ac_acudiente_old; set => Id_ac_acudiente_old = value; }
    }
}
