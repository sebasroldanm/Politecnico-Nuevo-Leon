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
    [Table("anio_curso",Schema ="registro")]
   public class AnioCurso
    {
        private Int32 idAncu;
        private Int32 idAncuAnio;
        private Int32 idAncuCurso;


        [Key]
        [Column("id_ancu")]
        public int id_ancu { get => idAncu; set => idAncu = value; }
        [Column("id_ancu_anio")]
        public int id_ancu_anio { get => idAncuAnio; set => idAncuAnio = value; }
        [Column("id_ancu_curso")]
        public int id_ancu_curso { get => idAncuCurso; set => idAncuCurso = value; }

    }
}
