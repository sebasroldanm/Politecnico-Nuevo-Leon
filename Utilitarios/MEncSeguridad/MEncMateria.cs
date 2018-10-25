using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncMateria
    {


        
        private String Nombre_materia_nuevo;
        private String Nombre_materia_old;

        private String Sesion_nuevo;   
        private String Sesion_old;
    
       

        
        public string nombre_materia_nuevo { get => Nombre_materia_nuevo; set => Nombre_materia_nuevo = value; }
        public string sesion_nuevo { get => Sesion_nuevo; set => Sesion_nuevo = value; }
        public string nombre_materia_old { get => Nombre_materia_old; set => Nombre_materia_old = value; }
        public string sesion_old { get => Sesion_old; set => Sesion_old = value; }
    }
}
