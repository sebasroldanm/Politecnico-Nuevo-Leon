using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.MIdioma;
using Datos;
using System.Data;

namespace Logica
{
    public class LMIdioma
    {

        public UIdioma obtIdioma(int form, int idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            List<Controles> reg = new List<Controles>();

            reg = datos.obtenerIdioma(form, idioma);

            foreach(Controles c in reg)
            {
                enc.CompIdioma.Add(c.control.ToString(), c.texto.ToString());
            }

            return enc;
        }



    }
}
