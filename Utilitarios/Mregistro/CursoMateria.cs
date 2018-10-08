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
    [Table("curso_materia", Schema = "registro")]
    public class CursoMateria
    {

        Int32 idCM;
        Int32 idCMMateria;
        Int32 idCMCurso;
        Int32 idCMProfesor;
        [Key]
        [Column("id_cm")]
        public int id_cm { get => idCM; set => idCM = value; }
        [Column("id_cm_materia")]
        public int id_cm_materia { get => idCMMateria; set => idCMMateria = value; }
        [Column("id_cm_curso")]
        public int id_cm_curso { get => idCMCurso; set => idCMCurso = value; }
        [Column("id_cm_profesor")]
        public int id_cm_profesor { get => idCMProfesor; set => idCMProfesor = value; }

        

    }
}
