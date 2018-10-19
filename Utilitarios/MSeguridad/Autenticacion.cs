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
    [Table("autenication", Schema = "security")]
    public class Autenticacion
    {
        private Int32 Id;
        private Int32 UserId;
        private String Ip;
        private String Mac;
        private String FechaInicio;
        private String Sesion;
        private String FechaFin;

        [Key]
        [Column("id")]
        public int id { get => Id; set => Id = value; }
        [Column("user_id")]
        public int user_id { get => UserId; set => UserId = value; }
        [Column("ip")]
        public string ip { get => Ip; set => Ip = value; }
        [Column("mac")]
        public string mac { get => Mac; set => Mac = value; }
        [Column("fecha_inicio")]
        public string fecha_inicio { get => FechaInicio; set => FechaInicio = value; }
        [Column("session")]
        public string session { get => Sesion; set => Sesion = value; }
        [Column("fecha_fin")]
        public string fecha_fin { get => FechaFin; set => FechaFin = value; }

        

    }
}
