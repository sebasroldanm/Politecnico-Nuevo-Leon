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
    [Table("controles", Schema = "idioma")]
    public class Controles
    {

        private Int32 IdControles;
        private String Control;
        private String Texto;
        private Int32 ConIdiomaId;
        private Int32 ConFormularioId;

        [Key]
        [Column("id_controles")]
        public int id_controles { get => IdControles; set => IdControles = value; }
        [Column("control")]
        public string control { get => Control; set => Control = value; }
        [Column("texto")]
        public string texto { get => Texto; set => Texto = value; }
        [Column("con_idioma_id")]
        public int con_idioma_id { get => ConIdiomaId; set => ConIdiomaId = value; }
        [Column("con_formulario_id")]
        public int con_formulario_id { get => ConFormularioId; set => ConFormularioId = value; }
    }
}
