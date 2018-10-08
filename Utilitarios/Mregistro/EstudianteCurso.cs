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
    [Table("estudiante_curso", Schema = "registro")]
    public class EstudianteCurso
    {
        Int32 idEc;
        Int32 idEcEstudiante;
        Int32 idEcCurso;


        [Key]
        [Column("id_ec")]
        public int id_ec { get => idEc; set => idEc = value; }
        [Column("id_ec_estudiante")]
        public int id_ec_estudiante { get => idEcEstudiante; set => idEcEstudiante = value; }
        [Column("id_ec_curso")]
        public int id_ec_curso { get => idEcCurso; set => idEcCurso = value; }
    }
}
