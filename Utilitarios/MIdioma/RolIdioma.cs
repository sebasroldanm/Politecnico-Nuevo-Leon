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
    [Table("rol_idioma", Schema = "idioma")]
    class RolIdioma
    {
        private Int32 IdRolIdioma;
        private String Rol_Idioma;
        [Key]
        [Column("id_rol_idioma")]
        public int id_rol_idioma { get => IdRolIdioma; set => IdRolIdioma = value; }
        [Column("rol_idioma")]
        public string rol_idioma { get => Rol_Idioma; set => Rol_Idioma = value; }

        
    }
}
