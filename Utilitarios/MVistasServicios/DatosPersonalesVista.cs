using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MVistasServicios
{
   public class DatosPersonalesVista
    {

        private string nombre;
        private string apellido;
        private string telefono;
        private string correo;
        private string fechanac;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fechanac { get => fechanac; set => fechanac = value; }
    }
}
