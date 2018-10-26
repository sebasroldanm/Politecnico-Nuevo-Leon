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



        public UIdioma validaIdiomaEmpezarInsert(string empezar, int contador, int idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            UUser user = new UUser();

            //enc = listarIdiomaVarchar(id);
            //idioma = int.Parse(enc.IdIdioma);

            if (empezar == "true")
            {

                if (contador >= 828)
                {
                    enc.BoolIdioma = true;
                    user.Notificacion = "Se Guarda";
                    //Guarda
                }
                else
                {
                    enc.BoolIdioma = false;
                    user.Notificacion = "SI sale ahora se desacartaran los datos, desea salir S/N";
                    //ver script de aceptar y cancelar
                    eliminarControles(idioma);
                    eliminarIdioma(idioma);
                }

            }
            else
            {

            }

            return enc;
        }


        public UIdioma eliminarIdiomaCompleto(int idioma)
        {
            UIdioma enc = new UIdioma();
            eliminarControles(idioma);
            eliminarIdioma(idioma);

            enc.NombreIdioma = "<script language='JavaScript'>window.alert('Se Eliminaron Los Ultimos Registros');</script>";

            return enc;
        }


        public UIdioma listarControlIdioma(string form, string control)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            int contador = 0;
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
            List<Controles> reg = datos.listarIdiomaControles(enc);
            if (reg.Count > 0)
            {
                foreach (Controles con in reg)
                {
                    if (contador == 0)
                    {
                        enc.ControlEsp = con.texto.ToString();
                    }
                    if (contador == 1)
                    {
                        enc.ControlIngles =con.texto.ToString();
                    }

                    contador = contador + 1;

                }
                
            }
            return enc;
        }

  
        public UIdioma eliminarControles(int idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();    
            datos.eliminarControles(idioma);

            return enc;
        }

        public UIdioma traerIdioma(string idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();

           List<Idioma> reg = datos.obtenerTraerIdioma(idioma);
            foreach (Idioma idi in reg)

            {

                enc.NombreIdioma = idi.id_idioma.ToString();
            }
                 
 
            return enc;
        }





    public UIdioma eliminarIdioma(int idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            datos.eliminarIdioma(idioma);
            return enc;
        }


        public UIdioma insertarIdioma(string nombre, string termin)
        {
            DIdioma datos = new DIdioma();
            DMIdioma da = new DMIdioma();
            UIdioma enc = new UIdioma();
            Idioma encapsulado = new Idioma();


            UIdioma usua = new UIdioma();

            usua = da.verificarIdiomaBD(termin);

            if (usua.Control == "ya esta")
            {
                enc = da.contadorControl(int.Parse(usua.IdIdioma));
                if (enc.Contador < 828)
                {
                    encapsulado.nombre = nombre;
                    encapsulado.terminacion = termin;
                    //da.insertarIdioma(encapsulado);
                    enc.IdiomaTermina = "true";
                }
                else
                {
                    enc.IdiomaTermina = null;
                    enc.Notificacion = "<script language='JavaScript'>window.alert('Idioma ya fue Insertado');</script>";
                }
            }
            else
            {
                if(usua.Control == "no esta")
                {
                    encapsulado.nombre = nombre;
                    encapsulado.terminacion = termin;
                    da.insertarIdioma(encapsulado);
                    enc.IdiomaTermina = "true";
                    enc.Notificacion = "<script language='JavaScript'>window.alert('Idioma Insertado');</script>";
                }
                else
                {
                    enc.IdiomaTermina = null;
                    enc.Notificacion = "<script language='JavaScript'>window.alert('La terminación no es válida');</script>";
                }
            }
            return enc;
        }

        public UIdioma listarIdiomaVarchar(string nombre)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            enc = datos.listarIdiomaVarchar(nombre);
            
            return enc;
        }

        public void insertarControlIdioma(string control, string texto, int ididioma, int idform, string nombre)
        {
            DIdioma datos = new DIdioma();
            DMIdioma dat = new DMIdioma();
            Controles enc = new Controles();

            enc.control = control;
            enc.texto = texto;
            enc.con_idioma_id = ididioma;
            enc.con_formulario_id = idform;

            dat.insertarIdiomaControles(enc);

            //reg = datos.contadorControl(nombre);
            //enc.Contador = int.Parse(reg.Rows[0][0].ToString());

            //return enc;
        }

        public UIdioma terminarIdioma(int español, int insertando)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma encId = new UIdioma();
            DataTable reg = new DataTable();
            DataTable inser = new DataTable();

            int conEspañol;
            int conInsertando;

            encId = datos.contadorControl(español);
            conEspañol = encId.Contador;
            encId = datos.contadorControl(insertando);
            conInsertando = encId.Contador;

            if ((conEspañol - 1) < conInsertando)
            {
                encId.Empezar = null;
                encId.Notificacion = "<script language='JavaScript'>window.alert('Idioma Agregado Exitosamente');</script>";
            }
            else
            {
                encId.Empezar = "true";
            }
            return encId;
        }

        public UIdioma listarControlIdiomaEditar(string form, string control, string idIdioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            

            DIdioma datosFalta = new DIdioma();



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
            //enc.IdFormulario = int.Parse(form);
            //enc.Control = control;
            //enc.IdIdioma = int.Parse(idIdioma);
           List<Controles> regis =  datos.listarControlIdiomaEditar(form, control, idIdioma);

            foreach(Controles con in regis)
            {
                enc.IdIdioma = con.id_controles.ToString();
                enc.ControlEsp = con.texto.ToString();
            }
            //if (reg.Rows.Count > 0)
            //{
            //    enc.ControlEsp = reg.Rows[0]["texto"].ToString();
            //}
            return enc;
        }

        public UIdioma editarIdiomaControl(int id, string texto)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            DataTable reg = new DataTable();

            datos.editarIdiomaControl(id, texto);
            return enc;
        }





        public UIdioma obtTerminacionIdioma(int idioma)
        {
            DMIdioma datos = new DMIdioma();
            UIdioma enc = new UIdioma();
            List<Idioma> reg = new List<Idioma>();

            reg = datos.obtenerTerminacionIdioma(idioma);
            foreach(Idioma i in reg)
            {
                enc.IdiomaTermina = i.terminacion.ToString();
            }
            //enc.IdiomaTermina = reg.Rows[0]["terminacion"].ToString();

            return enc;
        }

    }
}
