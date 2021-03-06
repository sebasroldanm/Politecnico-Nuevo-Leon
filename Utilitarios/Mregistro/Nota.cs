﻿using System;
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
        private Int32 idNota;
        private Int32 idNEstudiante;
        private Int32 idNMateria;
        private Double Nota1;
        private Double Nota2;
        private Double Nota3;
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
        public double notadef { get => notaDef; set => notaDef = value; }
    }
}
