using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Utilitarios;
using Utilitarios.Mregistro;
using Utilitarios.MVistasUsuario;
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
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 10;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            string l8 = " ", m8 = " ", w8 = " ", j8 = " ", v8 = " ", l10 = " ", m10 = " ", w10 = " ", j10 = " ", v10 = " ", l12 = " ", m12 = " ", w12 = " ", j12 = " ", v12 = " ";

            int id_curso;
            id_curso = curso;
            List<HorarioEstudiante> horar;
            
            switch (hor_tipo)
            {
                case 1:
                    //Horario Curso
                    horar = muser.horarioCurso(id_curso); ;
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




        public UUser agregarMateria(Materia materia, string sesion, int selIdioma)
        {
            UUser user = new UUser();
            DMReg datos = new DMReg();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 10;
            Materia mat = new Materia();
            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            user.Mensaje = " ";
            bool ok = datos.validaMateria(materia);

            if (ok == true)
            {        
                materia.sesion = sesion;
                materia.ultima_modificacion = DateTime.Now.ToShortDateString();
                datos.insertarMateria(materia);
                //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada con Exito');</script>");
                user.Mensaje = encId.CompIdioma["L_Error_falta_materia"].ToString(); //"Materia Insertada con Exito";
            }
            else
            {
                user.Mensaje = encId.CompIdioma["L_Error_materia_ya_esta"].ToString(); //"La Materia ya se encuentra en nuestra Base de Datos";
            }
            return user;
        }


        public UUser ObAniodeCurso(string sesion)
        {
            UUser enc = new UUser();
            DMReg datos = new DMReg();
            enc.Año = 0.ToString();
            if (sesion != null)
            {
                DateTime fecha = DateTime.Now;
                string año = (fecha.Year).ToString();
                año = año + "-01-01";
                List<Anio> re = datos.obtenerAniodeCurso(año);
                foreach (Anio an in re)
                {
                    enc.Año = an.id_anio.ToString();
                }
            }
            else
                enc.Url = "~/View/Profesor/AccesoDenegado.aspx";

            return enc;
        }

        public UUser subirNota(string alumno, string materia, string curso, string nota1, string nota2, string nota3, int selIdioma)
        {
            DMReg datos = new DMReg();
            UUser enc = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 39;
            Nota not = new Nota();

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            enc.Mensaje = " ";

            if (alumno == "0" || materia == "0" || curso == "0")
            {
                enc.Mensaje = encId.CompIdioma["L_Falta_Selec"].ToString(); //"Falta seleccionar";
            }
            else
            {
                enc.Id_estudiante = alumno;
                enc.Materia = materia;
                enc.Curso = curso;
                List<Nota> registros = datos.obtenerNota(enc);
                //DataTable registros = datos.obtenerNota(enc);
                foreach (Nota no in registros)
                {
                    enc.IdNota = no.id_nota.ToString();
                    not.id_nota = no.id_nota;
                }
                
                Double n1 = Convert.ToDouble(nota1);
                Double n2 = Convert.ToDouble(nota2);
                Double n3 = Convert.ToDouble(nota3);

                Double nd = (n1 + n2 + n3) / 3.0;

                enc.Nota1 = n1.ToString();
                enc.Nota2 = n2.ToString();
                enc.Nota3 = n3.ToString();

                enc.Notadef = nd.ToString();

                not.nota1 = n1;
                not.nota2 = n2;
                not.nota3 = n3;
                
                not.notadef = nd;
                datos.insertarNota(not);

            }
            return enc;
        }

        public UUser PL_EstudianteVerNotas(string userId)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            DateTime fecha = DateTime.Now;
            DMReg dato = new DMReg();
            enc.SAño = "0";
            string año = (fecha.Year).ToString();
            año = año + "-01-01";
            //DataTable re = datos.obtenerAniodeCurso(año);
            List<Anio> re = dato.obtenerAniodeCurso(año);
            foreach (Anio an in re)
            {
                enc.Año = an.id_anio.ToString();
                //enc.Año = re.Rows[0]["id_anio"].ToString();
            }
            enc.Id_estudiante = userId;

            List<CursoDeEstudianteVista> registros = new List<CursoDeEstudianteVista>();
            //DataTable registros = datos.obtenerCursoEst(enc);
            registros = dato.obtenerCursoEst(enc);
            foreach (CursoDeEstudianteVista ce in registros)
            {
                if (registros.Count > 0)
                {
                    enc.SAño = ce.id_ancu.ToString();
                }
                else
                {
                    enc.SAño = "0";
                }
            }
            return enc;
        }

    }


}
