using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("acudiente", Schema = "usuario")]
    public class Acudiente
    {
        private Int32 idAc;
        private Int32 idEstudiante;
        private Int32 idAcudiente;

        [Key]
        [Column("id_ac")]
        public int IdAc { get => idAc; set => idAc = value; }
        [Column("id_ac_estudiante")]
        public int IdEstudiante { get => idEstudiante; set => idEstudiante = value; }
        [Column("id_ac_acudiente")]
        public int IdAcudiente { get => idAcudiente; set => idAcudiente = value; }
    }
}
