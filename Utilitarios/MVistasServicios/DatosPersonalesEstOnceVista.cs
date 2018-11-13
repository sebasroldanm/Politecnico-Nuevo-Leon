using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MVistasServicios
{
   public class DatosPersonalesEstOnceVista
    {
        private string nombre;
        private string apellido;
        private string correo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
    }
}
