using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.MSeguridad
{
    [Serializable]
    [Table("auditoria", Schema = "security")]
    public class Auditoria
    {
        private Int32 Id;
        private String Fecha;
        private String Accion;
        private String Esquema;
        private String Tabla;
        private String Session;
        private String UserBD;
        private String Data;
        private String Pk;

        [Key]
        [Column("id")]
        public int id { get => Id; set => Id = value; }
        [Column("fecha")]
        public string fecha { get => Fecha; set => Fecha = value; }
        [Column("accion")]
        public string accion { get => Accion; set => Accion = value; }
        [Column("schema")]
        public string schema { get => Esquema; set => Esquema = value; }
        [Column("tabla")]
        public string tabla { get => Tabla; set => Tabla = value; }
        [Column("session")]
        public string session { get => Session; set => Session = value; }
        [Column("user_bd")]
        public string user_bd { get => UserBD; set => UserBD = value; }
        [Column("data")]
        public string data { get => Data; set => Data = value; }
        [Column("pk")]
        public string pk { get => Pk; set => Pk = value; }
    }
}
