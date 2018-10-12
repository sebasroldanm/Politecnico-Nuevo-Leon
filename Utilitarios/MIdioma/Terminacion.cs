using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.MIdioma
{
    [Serializable]
    [Table("terminaciones", Schema = "idioma")]
    class Terminacion
    {
        private Int32 IdTerminacion;
        private String NombreIdioma;
        private String Termino;

        [Key]
        [Column("id_terminacion")]
        public int id_terminacion { get => IdTerminacion; set => IdTerminacion = value; }
        [Column("nombre_idioma")]
        public string nombre_idioma { get => NombreIdioma; set => NombreIdioma = value; }
        [Column("termino")]
        public string termino { get => Termino; set => Termino = value; }

        
    }
}
