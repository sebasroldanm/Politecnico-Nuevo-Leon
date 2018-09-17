using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;
using Logica;
using System.Globalization;

namespace Logica
{
    public class LIdioma
    {
        public UIdioma obtIdioma(int form, int idioma)
        { 
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            reg = datos.obtenerIdioma(form,idioma);

            for (int i = 0; i < reg.Rows.Count; i++)
            {
                enc.CompIdioma.Add(reg.Rows[i]["control"].ToString(), reg.Rows[i]["texto"].ToString());
            }

            return enc;
        }

        public UIdioma obtTerminacionIdioma(int idioma)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            reg = datos.obtenerTerminacionIdioma(idioma);
            enc.IdiomaTermina = reg.Rows[0]["terminacion"].ToString();

            return enc;
        }
    }
}
