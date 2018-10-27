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
    [Table("materia", Schema ="registro")]
   public class Materia
    {

        private  Int32 idMateria;
        private String nombreMateria;
        private String Sesionm;
        private String ultimaModificacion;


        [Key]
        [Column("id_materia")]
        public int id_materia { get => idMateria; set => idMateria = value; }
        [Column("nombre_materia")]
        public string nombre_materia { get => nombreMateria; set => nombreMateria = value; }
        [Column("sesion")]
        public string sesion { get => Sesionm; set => Sesionm = value; }
        [Column("ultima_modificacion")]
        public string ultima_modificacion { get => ultimaModificacion; set => ultimaModificacion = value; }
    }
}
