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
        private String materia;
        private Double nota1;
        private Double nota2;
        private Double nota3;
        private Double notaDef;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Curso { get => curso; set => curso = value; }
        public string Materia { get => materia; set => materia = value; }
        public double Nota1 { get => nota1; set => nota1 = value; }
        public double Nota2 { get => nota2; set => nota2 = value; }
        public double Nota3 { get => nota3; set => nota3 = value; }
        public double NotaDef { get => notaDef; set => notaDef = value; }
    }
}
