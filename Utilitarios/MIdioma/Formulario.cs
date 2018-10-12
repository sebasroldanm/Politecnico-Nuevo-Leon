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
    [Table("formulario", Schema = "idioma")]
    class Formulario
    {
        private Int32 IdFormulario;
        private String Nombre;
        private String Url;

        [Key]
        [Column("id_formulario")]
        public int id_formulario { get => IdFormulario; set => IdFormulario = value; }
        [Column("nombre")]
        public string nombre { get => Nombre; set => Nombre = value; }
        [Column("url")]
        public string url { get => Url; set => Url = value; }
    }
}
