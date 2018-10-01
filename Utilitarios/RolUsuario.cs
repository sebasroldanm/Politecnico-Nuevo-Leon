using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("rol_usuario", Schema = "usuario")]
    public class RolUsuario
    {
        private Int32 idRol;
        private String rolUsua;

        [Key]
        [Column("id_rol")]
        public int IdRol { get => idRol; set => idRol = value; }
        [Column("nombre_rol")]
        public string RolUsua { get => rolUsua; set => rolUsua = value; }
    }
}