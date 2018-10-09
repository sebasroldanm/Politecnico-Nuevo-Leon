using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Utilitarios;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Logica
{
    public class LMReg
    {
        public DataTable horario(int curso, int hor_tipo, int selIdioma)
        {
            DMReg muser = new DMReg();
            UIdioma encId = new UIdioma();
            LIdioma idioma = new LIdioma();
            Int32 FORMULARIO = 10;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            string l8 = " ", m8 = " ", w8 = " ", j8 = " ", v8 = " ", l10 = " ", m10 = " ", w10 = " ", j10 = " ", v10 = " ", l12 = " ", m12 = " ", w12 = " ", j12 = " ", v12 = " ";

            int id_curso;
            id_curso = curso;
            DataTable registro;
            List<HorarioEstudiante> horar;
            switch (hor_tipo)
            {
                case 1:
                    //Horario Curso
                    horar = muser.horarioEstudiante(id_curso); ;
                    break;
                case 2:
                    //Horario Profesor
                    horar = muser.horarioEstudiante(id_curso); ;
                    break;
                case 3:
                    //Horario Estudiante
                    horar = muser.horarioEstudiante(id_curso); 
                    break;
                default:
                    horar = muser.horarioEstudiante(id_curso); 
                    break;
            }

            DataSet reg = new DataSet();

            DataTable Dt = new DataTable();
            Dt.Columns.Add("      ", typeof(string));
            Dt.Columns.Add(encId.CompIdioma["ho_lunes"].ToString(), typeof(string));
            Dt.Columns.Add(encId.CompIdioma["ho_martes"].ToString(), typeof(string));
            Dt.Columns.Add(encId.CompIdioma["ho_miercoles"].ToString(), typeof(string));
            Dt.Columns.Add(encId.CompIdioma["ho_jueves"].ToString(), typeof(string));
            Dt.Columns.Add(encId.CompIdioma["ho_viernes"].ToString(), typeof(string));
            string libre = encId.CompIdioma["ho_libre"].ToString();


            foreach (HorarioEstudiante h in horar)
            {
                //8:00:00
                if (h.hora_inicio == "8:00:00" && h.dia == "Lunes")
                {
                    l8 = h.nombre_materia;
                }

                if (h.hora_inicio == "8:00:00" && h.dia == "Martes")
                {
                    m8 = h.nombre_materia;
                }

                if (h.hora_inicio == "8:00:00" && h.dia == "Miercoles")
                {
                    w8 = h.nombre_materia;
                }

                if (h.hora_inicio == "8:00:00" && h.dia == "Jueves")
                {
                    j8 = h.nombre_materia;
                }

                if (h.hora_inicio == "8:00:00" && h.dia == "Viernes")
                {
                    v8 = h.nombre_materia;
                }

                //10:00:00
                if (h.hora_inicio == "10:00:00" && h.dia == "Lunes"
)
                {
                    l10 = h.nombre_materia;
                }

                if (h.hora_inicio == "10:00:00" && h.dia == "Martes")
                {
                    m10 = h.nombre_materia;
                }

                if (h.hora_inicio == "10:00:00" && h.dia == "Miercoles")
                {
                    w10 = h.nombre_materia;
                }

                if (h.hora_inicio == "10:00:00" && h.dia == "Jueves")
                {
                    j10 = h.nombre_materia;
                }

                if (h.hora_inicio == "10:00:00" && h.dia == "Viernes")
                {
                    v10 = h.nombre_materia;
                }

                //12:00:00
                if (h.hora_inicio == "12:00:00" && h.dia == "Lunes"
)
                {
                    l12 = h.nombre_materia;
                }

                if (h.hora_inicio == "12:00:00" && h.dia == "Martes")
                {
                    m12 = h.nombre_materia;
                }

                if (h.hora_inicio == "12:00:00" && h.dia == "Miercoles")
                {
                    w12 = h.nombre_materia;
                }

                if (h.hora_inicio == "12:00:00" && h.dia == "Jueves")
                {
                    j12 = h.nombre_materia;
                }

                if (h.hora_inicio == "12:00:00" && h.dia == "Viernes")
                {
                    v12 = h.nombre_materia;
                }
            }
            Dt.Rows.Add(" 8:00:00-9:29:00 ", l8, m8, w8, j8, v8);
            Dt.Rows.Add(" 09:30:00-9:59:00 ",
                encId.CompIdioma["ho_libre"].ToString().Substring(0, 1),
                encId.CompIdioma["ho_libre"].ToString().Substring(1, 1),
                encId.CompIdioma["ho_libre"].ToString().Substring(2, 1),
                encId.CompIdioma["ho_libre"].ToString().Substring(3, 1),
                encId.CompIdioma["ho_libre"].ToString().Substring(4, 1));
            Dt.Rows.Add(" 10:00:00-11:59:00", l10, m10, w10, j10, v10);
            Dt.Rows.Add(" 12:00:00-2:00:00", l12, m12, w12, j12, v12);

            return Dt;
        }
    }
}
