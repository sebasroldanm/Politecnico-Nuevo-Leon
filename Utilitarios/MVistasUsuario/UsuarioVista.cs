using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.MVistasUsuario
{
    public class UsuarioVista
    {
        private Int32 idUsua;
        private String nombreUsua;

        public int id_usua { get => idUsua; set => idUsua = value; }
        public string nombre_usua { get => nombreUsua; set => nombreUsua = value; }
    }
}
