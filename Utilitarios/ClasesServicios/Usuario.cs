using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utilitarios.ClasesServicios
{
   public class Usuario
    {

        private String nombre;
        private String apellido;
        private String email;
        private String User_Name;
        private String clave;
        private String rclave;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public string User_Name1 { get => User_Name; set => User_Name = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Rclave { get => rclave; set => rclave = value; }
    }
}
