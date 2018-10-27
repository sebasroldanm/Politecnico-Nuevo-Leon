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
    [Table("observador", Schema = "registro")]
    public class Observador
    {
        private Int32 idObservador;
        private String Observacion;
        private Int32 idEstudiante;
        private String fechaObservacion;
        [Key]
        [Column("id_observador")]
        public int id_observador { get => idObservador; set => idObservador = value; }
        [Column("observacion")]
        public string observacion { get => Observacion; set => Observacion = value; }
        [Column("id_estudiante")]
        public int id_estudiante { get => idEstudiante; set => idEstudiante = value; }
        [Column("fecha_observacion")]
        public string fecha_observacion { get => fechaObservacion; set => fechaObservacion = value; }
    }
}
