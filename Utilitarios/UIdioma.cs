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
        private String[] textos = new String[20];
        Hashtable compIdioma = new Hashtable();
        private String numFormulario;
        private String idFormulario;
        private String control;
        private String controlIngles;
        private String controlEsp;
        private String idIdioma;
        private String texto;
        private String nombreIdioma;
        private Int32 contador;
        private Boolean boolIdioma;
        private String notificacion;
        private String empezar;

        public int SelecIdioma { get => selecIdioma; set => selecIdioma = value; }
        public Hashtable CompIdioma { get => compIdioma; set => compIdioma = value; }
        public string IdiomaTermina { get => idiomaTermina; set => idiomaTermina = value; }
        public string NumFormulario { get => numFormulario; set => numFormulario = value; }
        public string IdFormulario { get => idFormulario; set => idFormulario = value; }
        public string Control { get => control; set => control = value; }
        public string ControlIngles { get => controlIngles; set => controlIngles = value; }
        public string ControlEsp { get => controlEsp; set => controlEsp = value; }
        public string IdIdioma { get => idIdioma; set => idIdioma = value; }
        public string Texto { get => texto; set => texto = value; }
        public string NombreIdioma { get => nombreIdioma; set => nombreIdioma = value; }
        public bool BoolIdioma { get => boolIdioma; set => boolIdioma = value; }
        public int Contador { get => contador; set => contador = value; }
        public string Notificacion { get => notificacion; set => notificacion = value; }
        public string Empezar { get => empezar; set => empezar = value; }
    }
}