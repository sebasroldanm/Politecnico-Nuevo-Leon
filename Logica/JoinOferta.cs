using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class JoinOferta
    {


        private int id_oferta;
        private String nombre_oferta;
        private int id_empresa;
        private String sueldo;
        private String horario;
        private String funciones;

        public int Id_oferta { get => id_oferta; set => id_oferta = value; }
        public string Nombre_oferta { get => nombre_oferta; set => nombre_oferta = value; }
        public int Id_empresa { get => id_empresa; set => id_empresa = value; }
        public string Sueldo { get => sueldo; set => sueldo = value; }
        public string Horario { get => horario; set => horario = value; }
        public string Funciones { get => funciones; set => funciones = value; }
    }
}
