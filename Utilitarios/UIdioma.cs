using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Utilitarios
{
    public class UIdioma
    {
        private Int32 idioma;
        private Int32 selecIdioma;
        private String[] texto = new String[20];
        Hashtable compIdioma = new Hashtable();

        public int Idioma { get => idioma; set => idioma = value; }
        public int SelecIdioma { get => selecIdioma; set => selecIdioma = value; }
        public string[] Texto { get => texto; set => texto = value; }
        public Hashtable CompIdioma { get => compIdioma; set => compIdioma = value; }

    }
}
