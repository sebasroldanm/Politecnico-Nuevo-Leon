using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("inicio", Schema = "inicio")]
    public class Inicio
    {
        private Int32 idInicio;
        private String inicioCont;
        private String misionInicio;
        private String visionInicio;
        private String Sesion;
        private String ultimaModificacion;

        [Key]
        [Column("id_inicio")]
        public int id_inicio { get => idInicio; set => idInicio = value; }
        [Column("inicio_cont")]
        public string inicio_cont { get => inicioCont; set => inicioCont = value; }
        [Column("mision_inicio")]
        public string mision_inicio { get => misionInicio; set => misionInicio = value; }
        [Column("vision_inicio")]
        public string vision_inicio { get => visionInicio; set => visionInicio = value; }
        [Column("sesion")]
        public string sesion { get => Sesion; set => Sesion = value; }
        [Column("ultima_modificacion")]
        public string ultima_modificacion { get => ultimaModificacion; set => ultimaModificacion = value; }
    }
}