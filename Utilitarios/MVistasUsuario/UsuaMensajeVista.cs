using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{

    public class UsuaMensajeVista
    {
        private Int32 idUsua;
        private String nombreUsua;
        private String Correo;

        public int id_usua { get => idUsua; set => idUsua = value; }
        public string nombre_usua { get => nombreUsua; set => nombreUsua = value; }
        public string correo { get => Correo; set => Correo = value; }
    }
}
