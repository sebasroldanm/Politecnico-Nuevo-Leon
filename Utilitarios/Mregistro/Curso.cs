using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Mregistro
{

    [Serializable]
    [Table("curso",Schema ="registro")]
    public class Curso
    {
        Int32 idCurso;
        String nombreCurso;

        [Key]
        [Column("id_curso")]
        public int id_curso { get => idCurso; set => idCurso = value; }
        [Column("nombre_curso")]
        public string nombre_curso { get => nombreCurso; set => nombreCurso = value; }
    }
}
