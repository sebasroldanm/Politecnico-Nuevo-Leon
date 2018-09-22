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

        public UIdioma listarControlIdioma(string form, string control)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();
            if (form == "")
            {
                form = "0";
            }
            if (control == "")
            {
                control = "L";
            }
            enc.IdFormulario = form;
            enc.Control = control;
            reg = datos.listarIdiomaControles(enc);
            if (reg.Rows.Count > 0)
            {
                enc.ControlEsp = reg.Rows[0]["texto"].ToString();
                enc.ControlIngles = reg.Rows[1]["texto"].ToString();
            }
            return enc;
        }

        public UIdioma listarControlIdiomaEditar(string form, string control,string idIdioma)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();
            if (form == "")
            {
                form = "0";
            }
            if (control == "")
            {
                control = "L";
            }
            if (idIdioma == "")
            {
                idIdioma = "0";
            }
            enc.IdFormulario = form;
            enc.Control = control;
            enc.IdIdioma = idIdioma;
            reg = datos.listarIdiomaControlesEditar(enc);
            if (reg.Rows.Count > 0)
            {
                enc.ControlEsp = reg.Rows[0]["texto"].ToString();
            }
            return enc;
        }

        public UIdioma insertarIdioma(string nombre, string termin)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            reg = datos.insertarIdioma(nombre, termin);

            return enc;
        }

        public UIdioma insertarControlIdioma(string control, string texto, string ididioma, string idform)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            enc.Control = control;
            enc.Texto = texto;
            enc.IdIdioma = ididioma;
            enc.IdFormulario = idform;

            reg = datos.insertarIdiomaControles(enc);
            return enc;
        }

        public UIdioma listarIdiomaVarchar(string nombre)
        {
            DIdioma datos = new DIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            reg = datos.listarIdiomaVarchar(nombre);
            enc.IdIdioma = reg.Rows[0]["id_idioma"].ToString();
            return enc;
        }

    }
}
