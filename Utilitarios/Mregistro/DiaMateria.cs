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
    [Table("dia_materia", Schema ="registro")]
     public class DiaMateria
    {
       private Int32 idDiaMateria;
        private String Dia;
        private String horaInicio;
        private String horaFin;

        [Key]
        [Column("id_dia_materia")]
        public int id_dia_materia { get => idDiaMateria; set => idDiaMateria = value; }
        [Column("dia")]
        public string dia { get => Dia; set => Dia = value; }
        [Column("hora_inicio")]
        public string hora_inicio { get => horaInicio; set => horaInicio = value; }
        [Column("hora_fin")]
        public string hora_fin { get => horaFin; set => horaFin = value; }
    }
}
