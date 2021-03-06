﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MEncSeguridad
{
    public class MEnsObservador
    {
        private String Observacion_nuevo;
        private String Observacion_old;
        private Int32 Id_estudiante_nuevo;
        private Int32 Id_estudiante_old;
        private String Fecha_observacion_nuevo;
        private String Fecha_observacion_old;

        public string observacion_nuevo { get => Observacion_nuevo; set => Observacion_nuevo = value; }
        public string observacion_old { get => Observacion_old; set => Observacion_old = value; }
        public int id_estudiante_nuevo { get => Id_estudiante_nuevo; set => Id_estudiante_nuevo = value; }
        public int id_estudiante_old { get => Id_estudiante_old; set => Id_estudiante_old = value; }
        public string fecha_observacion_nuevo { get => Fecha_observacion_nuevo; set => Fecha_observacion_nuevo = value; }
        public string fecha_observacion_old { get => Fecha_observacion_old; set => Fecha_observacion_old = value; }
    }
}
