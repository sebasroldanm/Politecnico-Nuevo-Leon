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
    [Table("materia_fecha",Schema ="registro")]
    public class MateriaFecha
    {
        Int32 idMf;
        Int32 idMfMateria;
        Int32 idMfFecha;

        [Key]
        [Column("id_mf")]
        public int id_mf { get => idMf; set => idMf = value; }
        [Column("id_mf_materia")]
        public int id_mf_materia { get => idMfMateria; set => idMfMateria = value; }
        [Column("id_mf_fecha")]
        public int id_mf_fecha { get => idMfFecha; set => idMfFecha = value; }
    }
}
