﻿using System;
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
        private String sesion;
        private String ultimaModificacion;

        [Key]
        [Column("id_inicio")]
        public int IdInicio { get => idInicio; set => idInicio = value; }
        [Column("inicio_cont")]
        public string InicioCont { get => inicioCont; set => inicioCont = value; }
        [Column("mision_inicio")]
        public string MisionInicio { get => misionInicio; set => misionInicio = value; }
        [Column("vision_inicio")]
        public string VisionInicio { get => visionInicio; set => visionInicio = value; }
        [Column("sesion")]
        public string Sesion { get => sesion; set => sesion = value; }
        [Column("ultima_modificacion")]
        public string UltimaModificacion { get => ultimaModificacion; set => ultimaModificacion = value; }
    }
}