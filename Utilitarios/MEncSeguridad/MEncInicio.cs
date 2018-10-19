using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncInicio
    {
        private String Inicio_cont_nuevo;
        private String Inicio_cont_old;
        private String Mision_inicio_nuevo;
        private String Mision_inicio_old;
        private String Vision_inicio_nuevo;
        private String Vision_inicio_old;

       
        public string inicio_cont_nuevo { get => Inicio_cont_nuevo; set => Inicio_cont_nuevo = value; }
        public string inicio_cont_old { get => Inicio_cont_old; set => Inicio_cont_old = value; }

        public string mision_inicio_nuevo { get => Mision_inicio_nuevo; set => Mision_inicio_nuevo = value; }
        public string mision_inicio_old { get => Mision_inicio_old; set => Mision_inicio_old = value; }

        public string vision_inicio_nuevo { get => Vision_inicio_nuevo; set => Vision_inicio_nuevo = value; }
        public string vision_inicio_old { get => Vision_inicio_old; set => Vision_inicio_old = value; }
        
    }
}
