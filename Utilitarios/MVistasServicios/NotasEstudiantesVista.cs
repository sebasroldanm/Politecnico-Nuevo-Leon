using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MVistasServicios
{
    public class NotasEstudiantesVista
    {
        private String nombre;
        private String apellido;
        private String curso;
        private String nota1;
        private String nota2;
        private String nota3;
        private String notaDef;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Curso { get => curso; set => curso = value; }
        public string Nota1 { get => nota1; set => nota1 = value; }
        public string Nota2 { get => nota2; set => nota2 = value; }
        public string Nota3 { get => nota3; set => nota3 = value; }
        public string NotaDef { get => notaDef; set => notaDef = value; }
        
    }
}
