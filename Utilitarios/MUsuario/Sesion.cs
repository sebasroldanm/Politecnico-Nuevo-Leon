using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{

    [Serializable] 
    [Table("sesion", Schema = "usuario")]
    public class Sesion
    {

        private Int32 idSesion;
        private Int32 idUsuario;
        private Int32 sesionUsuario;
        private Int32 sesionActiva;
        private Int32 intentosErroneos;
        private String horaLibre;


        [Key]
        [Column("id_sesion")]
        public int IdSesion { get => idSesion; set => idSesion = value; }
        [Column("id_usuario")]
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        [Column("sesionUsuario")]
        public int SesionUsuario { get => sesionUsuario; set => sesionUsuario = value; }
        [Column("sesionActiva")]
        public int SesionActiva { get => sesionActiva; set => sesionActiva = value; }
        [Column("intentosErroneos")]
        public int IntentosErroneos { get => intentosErroneos; set => intentosErroneos = value; }
        [Column("horaLibre")]
        public string HoraLibre { get => horaLibre; set => horaLibre = value; }


    }
}
