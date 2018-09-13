using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class UIdioma
    {
        private Int32 selecIdioma;
        private String[] texto = new String[20];

        public int SelecIdioma { get => selecIdioma; set => selecIdioma = value; }
        public string[] Texto { get => texto; set => texto = value; }
    }
}
