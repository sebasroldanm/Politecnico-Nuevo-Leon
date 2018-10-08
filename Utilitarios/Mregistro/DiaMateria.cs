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
        Int32 idDiaMateria;
        String dia;
        String horaInicio;
        String horaFin;

        [Key]
        [Column("id_dia_materia")]
        public int id_dia_materia { get => idDiaMateria; set => idDiaMateria = value; }
        [Column("dia")]
        public string Dia { get => dia; set => dia = value; }
        [Column("hora_inicio")]
        public string hora_inicio { get => horaInicio; set => horaInicio = value; }
        [Column("hora_fin")]
        public string HoraFin { get => horaFin; set => horaFin = value; }
    }
}
