using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;

namespace Logica
{
    public class LIdioma
    {
        public DataTable obtIdioma(int form, int idioma)
        { 
            DIdioma datos = new DIdioma();
            UUser enc = new UUser();
            DataTable reg = new DataTable();

            reg = datos.obtenerIdioma(form, idioma);

            return reg;
        }
    }
}
