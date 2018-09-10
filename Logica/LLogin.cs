using System;
using System.Data;
using Datos;
using Utilitarios;

namespace Logica
{
    public class LLogin
    {
        //****ADMINISTRADOR
        public UUser logAgregarAdmin(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != null)
            {
                int year;
                year = int.Parse(DateTime.Now.ToString("yyyy"));
                year = year - 18;
                usua.Año = year.ToString();
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";

            return usua;
        }

        public UUser prueba(UUser sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion.Session != null)
            {
                int year;
                year = int.Parse(DateTime.Now.ToString("yyyy"));
                year = year - 18;
                usua.RolId = year;
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";

            return usua;
        }

        public UUser prueba1(UUser sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if(sesion.Session == null)
            {
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";
            }
            return usua;
        }


        public UUser logAdminSecillo(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != null)
            {
                Console.WriteLine("");
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";

            return usua;
        }
        public UUser logAgregaEstudiante(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != null)
            {
                usua.BotonTrue = true;
                usua.BotonFalse = false;
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";
            return usua;
        }
        public UUser logConfiguracionAdmin(string sesion, string foto)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                usua.Foto = foto;
                usua.BotonFalse = false;
                usua.BotonTrue = true;
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";


                return usua;
        }

        public UUser logEditarAcudienteAdmin(string sesion, string documento)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                usua.Documento = documento;
                usua.BotonFalse = false;
                usua.BotonTrue = true;
            }
            else
                usua.Url = "~/View/Admin/AccesoDenegado.aspx";

            return usua;
        }

        //ACUDIENTE
        public UUser logAcudienteSecillo(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                Console.WriteLine("");
            }
            else
                usua.Url = "~/View/Acudiente/AccesoDenegado.aspx";

            return usua;
        }

        public UUser logAcudienteBoletin(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                Console.WriteLine("");
                DateTime fecha = DateTime.Now;
                string año = (fecha.Year).ToString();
                usua.Año = año + "-01-01";
            }
            else
                usua.Url = "~/View/Acudiente/AccesoDenegado.aspx";

            return usua;
        }

        public UUser logConfiguracionAcudiente(string sesion, string foto)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                usua.Foto = foto;
                usua.BotonFalse = false;
                usua.BotonTrue = true;
            }
            else
                usua.Url = "~/View/Acudiente/AccesoDenegado.aspx";


            return usua;
        }


        //ESTUDIANTE

        public UUser logEstudianteSecillo(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                Console.WriteLine("");
            }
            else
                usua.Url = "~/View/Estudiante/AccesoDenegado.aspx";

            return usua;
        }

        public UUser logConfiguracionEstudiante(string sesion, string foto)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                usua.Foto = foto;
                usua.BotonFalse = false;
                usua.BotonTrue = true;
            }
            else
                usua.Url = "~/View/Estudiante/AccesoDenegado.aspx";

            return usua;
        }

        public UUser logEstudianteVerNotas(string sesion)
        {
            UUser usua = new UUser();
            DUser datos = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                UUser enc = new UUser();
                DateTime fecha = DateTime.Now;
                string año = (fecha.Year).ToString();
                año = año + "-01-01";
                DataTable re = datos.obtenerAniodeCurso(año);
                enc.Año = re.Rows[0]["id_anio"].ToString();
                enc.Id_estudiante = sesion;

                DataTable registros = datos.obtenerCursoEst(enc);
                if (registros.Rows.Count > 0)
                {
                    usua.Año = registros.Rows[0]["id_ancu"].ToString();
                }
                else
                {
                    usua.Año = "0";
                }
            }
            else
                usua.Url = "~/View/Acudiente/AccesoDenegado.aspx";

            return usua;
        }
        //PROFESOR
        public UUser logProfesorSecillo(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
            {
                Console.WriteLine("");
            }
            else
                usua.Url = "~/View/Profesor/AccesoDenegado.aspx";

            return usua;
        }

        public UUser cerrarSessionAcudiente(string session)
        {
            DUser user = new DUser();
            UUser datos = new UUser();

            datos.SUserId = null;
            datos.SNombre = null;

            datos.Session = session;
            user.cerrarSession(datos);

            datos.Url =("../Inicio/InicioNosotros.aspx");
            return datos;
        }

    }
}
