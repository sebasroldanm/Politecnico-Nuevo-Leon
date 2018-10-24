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
    
       

        
        public string Nombre_materia_nuevo1 { get => Nombre_materia_nuevo; set => Nombre_materia_nuevo = value; }
        public string Sesion_nuevo1 { get => Sesion_nuevo; set => Sesion_nuevo = value; }
        public string Nombre_materia_old1 { get => Nombre_materia_old; set => Nombre_materia_old = value; }
        public string Sesion_old1 { get => Sesion_old; set => Sesion_old = value; }
    }
}
