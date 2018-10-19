using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class USeguridad
    {
        private String _data_new;
        private String _data_old;

        private String fecha;
        private String _accion;
        private String _session;
        private String _user_bd;
        private String _table_pk;
        private String schema;
        private String tabla;
        private String _init;
        private String Data;

        public string Data_new { get => _data_new; set => _data_new = value; }
        public string Data_old { get => _data_old; set => _data_old = value; }


        public string Accion { get => _accion; set => _accion = value; }
        public string Session { get => _session; set => _session = value; }
        public string User_bd { get => _user_bd; set => _user_bd = value; }
        public string Table_pk { get => _table_pk; set => _table_pk = value; }
        public string Init { get => _init; set => _init = value; }
        public string Schema { get => schema; set => schema = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Tabla { get => tabla; set => tabla = value; }
        public string data { get => Data; set => Data = value; }
    }
}
