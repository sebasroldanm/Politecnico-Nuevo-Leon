using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEncNota
    {
       
        private Int32 Id_n_estudiante_nuevo;
        private Int32 Id_n_estudiante_anterior;
        private Int32 Id_n_materia_nuevo;
        private Int32 Id_n_materia_old;
        private String Nota1_nuevo;
        private String Nota1_old;
        private String Nota2_nuevo;
        private String Nota2_old;
        private String Nota3_nuevo;       
        private String Nota3_old;
        private String Notadef_nuevo;
        private String Notadef_old;

        public int id_n_estudiante_nuevo { get => Id_n_estudiante_nuevo; set => Id_n_estudiante_nuevo = value; }
        public int id_n_estudiante_anterior { get => Id_n_estudiante_anterior; set => Id_n_estudiante_anterior = value; }

        public int id_n_materia_nuevo { get => Id_n_materia_nuevo; set => Id_n_materia_nuevo = value; }
        public int id_n_materia_old { get => Id_n_materia_old; set => Id_n_materia_old = value; }

        public string nota1_nuevo { get => Nota1_nuevo; set => Nota1_nuevo = value; }
        public string nota1_old { get => Nota1_old; set => Nota1_old = value; }

        public string nota2_nuevo { get => Nota2_nuevo; set => Nota2_nuevo = value; }
        public string nota2_old { get => Nota2_old; set => Nota2_old = value; }

        public string nota3_nuevo { get => Nota3_nuevo; set => Nota3_nuevo = value; }
        public string nota3_old { get => Nota3_old; set => Nota3_old = value; }

        public string notadef_nuevo { get => Notadef_nuevo; set => Notadef_nuevo = value; }
        public string notadef_old { get => Notadef_old; set => Notadef_old = value; }

      
        
    }
}
