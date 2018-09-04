using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
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
        public UUser logAdminSecillo(string sesion)
        {
            UUser usua = new UUser();
            DUser dat = new DUser();

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
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

            if (sesion != "wpygkcrggjyqsrtf50nlfjlu")
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
                usua.Url = "~/View/Acudiente/AccesoDenegado.aspx";

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


    }
}
