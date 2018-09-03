using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;

namespace Logica
{
    public class LInicio
    {
        public UUser inicioNosotros()
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            DataTable regi = dat.incio();

            if (regi.Rows.Count > 0)
            {
                usua.Inicio = Convert.ToString(regi.Rows[0]["inicio_cont"].ToString());
            }
        }
    }
}
