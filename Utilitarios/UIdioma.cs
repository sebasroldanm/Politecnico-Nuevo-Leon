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
        private String idiomaTermina;
        private Int32 selecIdioma;
        private String[] texto = new String[20];
        Hashtable compIdioma = new Hashtable();
        private String numFormulario;
        private String idFormulario;
        private String control;

        public int SelecIdioma { get => selecIdioma; set => selecIdioma = value; }
        public string[] Texto { get => texto; set => texto = value; }
        public Hashtable CompIdioma { get => compIdioma; set => compIdioma = value; }
        public string IdiomaTermina { get => idiomaTermina; set => idiomaTermina = value; }
        public string NumFormulario { get => numFormulario; set => numFormulario = value; }
        public string IdFormulario { get => idFormulario; set => idFormulario = value; }
        public string Control { get => control; set => control = value; }
    }
}
