using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class HorarioEstudiante
    {
        private String NombreMateria;
        private String Dia;
        private String HoraInicio;
        private String HoraFin;

        public string nombre_materia { get => NombreMateria; set => NombreMateria = value; }
        public string dia { get => Dia; set => Dia = value; }
        public string hora_inicio { get => HoraInicio; set => HoraInicio = value; }
        public string hora_fin { get => HoraFin; set => HoraFin = value; }
    }
}
