using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MVistasUsuario
{
    public class CursoDeEstudianteVista
    {
        private Int32 IdAncu;
        private Int32 IdCurso;
        private String NombreCurso;

        public int id_ancu { get => IdAncu; set => IdAncu = value; }
        public int id_curso { get => IdCurso; set => IdCurso = value; }
        public string nombre_curso { get => NombreCurso; set => NombreCurso = value; }
    }
}
