using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class Boletin
    {
        private String nombreMateria;
        private Double Nota1;
        private Double Nota2;
        private Double Nota3;
        private Double notaDef;

        public string nombre_materia { get => nombreMateria; set => nombreMateria = value; }
        public double nota1 { get => Nota1; set => Nota1 = value; }
        public double nota2 { get => Nota2; set => Nota2 = value; }
        public double nota3 { get => Nota3; set => Nota3 = value; }
        public double notadef { get => notaDef; set => notaDef = value; }
    }
}
