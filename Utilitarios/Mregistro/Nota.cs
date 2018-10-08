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
    [Table("nota", Schema ="registro")]
    public class Nota
    {
        Int32 idNota;
        Int32 idNEstudiante;
        Int32 idNMateria;
        Double Nota1;
        Double Nota2;
        Double Nota3;
        Double notaDef;
        [Key]
        [Column("id_nota")]
        public int id_nota { get => idNota; set => idNota = value; }
        [Column("id_n_estudiante")]
        public int id_n_estudiante { get => idNEstudiante; set => idNEstudiante = value; }
        [Column("id_n_materia")]
        public int id_n_materia { get => idNMateria; set => idNMateria = value; }
        [Column("nota1")]
        public double nota1 { get => Nota1; set => Nota1 = value; }
        [Column("nota2")]
        public double nota2 { get =>  Nota2; set => Nota2 = value; }
        [Column("nota3")]
        public double nota3 { get => Nota3; set => Nota3 = value; }
        [Column("notadef")]
        public double NotaDef { get => notaDef; set => notaDef = value; }
    }
}
