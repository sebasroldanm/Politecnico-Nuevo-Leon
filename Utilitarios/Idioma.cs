using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("idioma", Schema = "idioma")]
    public class Idioma
    {
        private Int32 IdIdioma;
        private String Nombre;
        private String Terminacion;

        [Key]
        [Column("id_idioma")]
        public int id_idioma { get => IdIdioma; set => IdIdioma = value; }
        [Column("nombre")]
        public string nombre { get => Nombre; set => Nombre = value; }
        [Column("terminacion")]
        public string terminacion { get => Terminacion; set => Terminacion = value; }
    }
}
