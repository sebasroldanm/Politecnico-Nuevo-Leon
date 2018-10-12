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

        public void editasesion(int usuario, string sesion)
        {
            DMIdioma datos = new DMIdioma();
            datos.editarsesionusua(usuario, sesion);
        }

        public UUser listarSesion(int usuario)
        {

            DMIdioma datos = new DMIdioma();
            UUser enc = new UUser();

            enc = datos.listarSesion(usuario);
            
            return enc;
        }

        public UIdioma insertarIdioma(string nombre, string termin)
        {
            DIdioma datos = new DIdioma();
            DMIdioma da = new DMIdioma();
            UIdioma enc = new UIdioma();
            Idioma encapsulado = new Idioma();
            DataTable reg = new DataTable();
            DataTable valida = new DataTable();

            valida = datos.verificarIdiomaBD(termin);

            if (int.Parse(valida.Rows[0][0].ToString()) == 1)
            {
                enc.IdiomaTermina = "true";
                enc.Notificacion = "<script language='JavaScript'>window.alert('Idioma ya fue Insertado');</script>";
            }
            else
            {
                encapsulado.nombre = nombre;
                encapsulado.terminacion = termin;
                da.insertarIdioma(encapsulado);
                reg = datos.contadorControl(nombre);
                enc.Contador = int.Parse(reg.Rows[0][0].ToString());
                enc.IdiomaTermina = "true";
                enc.Notificacion = "<script language='JavaScript'>window.alert('Idioma Insertado');</script>";
            }
            return enc;


        }





    }
}
