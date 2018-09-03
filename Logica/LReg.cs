using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;

namespace Logica
{
    public class LReg
    {
        public DataTable horario(int curso, int hor_tipo)
        {
            DUser datos = new DUser();

            string l8 = " ", m8 = " ", w8 = " ", j8 = " ", v8 = " ", l10 = " ", m10 = " ", w10 = " ", j10 = " ", v10 = " ", l12 = " ", m12 = " ", w12 = " ", j12 = " ", v12 = " ";

            int id_curso;
            id_curso = curso;
            DataTable registro;

            switch (hor_tipo)
            {
                case 1:
                    //Horario Curso
                    registro = datos.horarioCurso(id_curso);
                    break;
                case 2:
                    //Horario Profesor
                    registro = datos.horarioProf(id_curso.ToString());
                    break;
                default:
                    registro = datos.horarioCurso(id_curso);
                    break;
            }

            int n = registro.DefaultView.Count;
            DataSet reg = new DataSet();

            DataTable Dt = new DataTable();
            Dt.Columns.Add("      ", typeof(string));
            Dt.Columns.Add("  Lunes  ", typeof(string));
            Dt.Columns.Add("  Martes  ", typeof(string));
            Dt.Columns.Add(" Miercoles ", typeof(string));
            Dt.Columns.Add("  Jueves  ", typeof(string));
            Dt.Columns.Add("  Viernes  ", typeof(string));


            for (int i = 0; i < n; i++)
            {
                //8:00:00
                if (registro.Rows[i]["hora_inicio"].ToString() == "8:00:00" && registro.Rows[i]["dia"].ToString() == "Lunes")
                {
                    l8 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "8:00:00" && registro.Rows[i]["dia"].ToString() == "Martes")
                {
                    m8 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "8:00:00" && registro.Rows[i]["dia"].ToString() == "Miercoles")
                {
                    w8 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "8:00:00" && registro.Rows[i]["dia"].ToString() == "Jueves")
                {
                    j8 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "8:00:00" && registro.Rows[i]["dia"].ToString() == "Viernes")
                {
                    v8 = registro.Rows[i]["nombre_materia"].ToString();
                }

                //10:00:00
                if (registro.Rows[i]["hora_inicio"].ToString() == "10:00:00" && registro.Rows[i]["dia"].ToString() == "Lunes")
                {
                    l10 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "10:00:00" && registro.Rows[i]["dia"].ToString() == "Martes")
                {
                    m10 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "10:00:00" && registro.Rows[i]["dia"].ToString() == "Miercoles")
                {
                    w10 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "10:00:00" && registro.Rows[i]["dia"].ToString() == "Jueves")
                {
                    j10 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "10:00:00" && registro.Rows[i]["dia"].ToString() == "Viernes")
                {
                    v10 = registro.Rows[i]["nombre_materia"].ToString();
                }

                //12:00:00
                if (registro.Rows[i]["hora_inicio"].ToString() == "12:00:00" && registro.Rows[i]["dia"].ToString() == "Lunes")
                {
                    l12 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "12:00:00" && registro.Rows[i]["dia"].ToString() == "Martes")
                {
                    m12 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "12:00:00" && registro.Rows[i]["dia"].ToString() == "Miercoles")
                {
                    w12 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "12:00:00" && registro.Rows[i]["dia"].ToString() == "Jueves")
                {
                    j12 = registro.Rows[i]["nombre_materia"].ToString();
                }

                if (registro.Rows[i]["hora_inicio"].ToString() == "12:00:00" && registro.Rows[i]["dia"].ToString() == "Viernes")
                {
                    v12 = registro.Rows[i]["nombre_materia"].ToString();
                }
            }
            Dt.Rows.Add(" 8:00:00-9:29:00 ", l8, m8, w8, j8, v8);
            Dt.Rows.Add(" 09:30:00-9:59:00 ", "  L  ", "  I  ", " B ", "  R  ", "  E ");
            Dt.Rows.Add(" 10:00:00-11:59:00", l10, m10, w10, j10, v10);
            Dt.Rows.Add(" 12:00:00-2:00:00", l12, m12, w12, j12, v12);

            return Dt;
        }

        public UUser agregarMateria(string materia, string sesion)
        {
            UUser user = new UUser();
            DUser datos = new DUser();
            LReg l_reg = new LReg();

            user.Mensaje = " ";
            bool ok = validar_mat(materia);

            if (ok == false)
            {
                user.Materia = materia;
                user.Session = sesion;
                datos.insertarMateria(user);
                //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada con Exito');</script>");
                user.Mensaje = "Materia Insertada con Exito";
            }
            else
            {
                user.Mensaje = "La Materia ya se encuentra en nuestra Base de Datos";
            }
            return user;
        }

        public UUser agregaraHorario(string curso, string anio, string dia, string docente, string hora, string materia)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();

            enc.Mensaje = " ";
            if (curso == "0" || anio == "0" || dia == "0" || docente == "0" || hora == "0" || materia == "0")
            {
                enc.Mensaje = "Falta seleccionar";
            }
            else
            {
                bool ok = validar_horario(curso, dia, hora);

                if (ok == true)
                {
                    bool wp = validar_profesor(docente, dia, hora);
                    if (wp == true)
                    {
                        enc.Materia = materia;

                        enc.Dia_materia = dia;
                        enc.Hora_in = hora;

                        DataTable registros = datos.obtenerHora(enc);

                        enc.Cur_mat = registros.Rows[0]["id_mf"].ToString();
                        enc.Curso = curso;
                        enc.Id_docente = docente;

                        datos.insertarCursoMateria(enc);

                        int cur = Convert.ToInt32(curso);
                        DataTable est = datos.gEstudiante(cur);
                        int n = est.DefaultView.Count;

                        for (int i = 0; i < n; i++)
                        {
                            enc.Id_estudiante = est.Rows[i]["id_usua"].ToString();
                            enc.Materia = materia;
                            datos.insertarNotaMateria(enc);
                        }
                        enc.Mensaje = "Materia Insertada a Curso con Exito";
                        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada a Curso con Exito');</script>");
                    }
                    else
                    {
                        enc.Mensaje = "El docente presenta un cruce de Horarios";
                    }
                }
                else
                {
                    enc.Mensaje = "Presenta un cruce de Horarios";
                }

            }
            return enc;

        }


        public UUser subirNota(string alumno, string materia, string curso, string nota1, string nota2, string nota3)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            enc.Mensaje = " ";

            if (alumno == "0" || materia == "0" || curso == "0")
            {
                enc.Mensaje = "Falta seleccionar";
            }
            else
            {
                enc.Id_estudiante = alumno;
                enc.Materia = materia;
                enc.Curso = curso;
                DataTable registros = datos.obtenerNota(enc);

                enc.IdNota = registros.Rows[0]["id_nota"].ToString();
                Double n1 = Convert.ToDouble(nota1);
                Double n2 = Convert.ToDouble(nota2);
                Double n3 = Convert.ToDouble(nota3);

                Double nd = (n1 + n2 + n3) / 3.0;

                enc.Nota1 = n1.ToString();
                enc.Nota2 = n2.ToString();
                enc.Nota3 = n3.ToString();

                enc.Notadef = nd.ToString();
                datos.insertarNota(enc);

            }
            return enc;
        }

        public UUser verNota(string alumno, string materia, string curso)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            enc.Mensaje = " ";
            if (alumno == "0" || materia == "0" || curso == "0")
            {
                enc.Mensaje = "Falta seleccionar";
            }
            else
            {
                enc.Id_estudiante = alumno;
                enc.Materia = materia;
                enc.Curso = curso;
                DataTable registros = datos.obtenerNota(enc);

                enc.Nota1 = registros.Rows[0]["nota1"].ToString();
                enc.Nota2 = registros.Rows[0]["nota2"].ToString();
                enc.Nota3 = registros.Rows[0]["nota3"].ToString();

                enc.Notadef = registros.Rows[0]["notadef"].ToString();
            }
            return enc;
        }

        public UUser ObAniodeCurso(string sesion)
        {
            UUser enc = new UUser();
            DUser datos = new DUser();
            if (sesion != null)
            {
                DateTime fecha = DateTime.Now;
                string año = (fecha.Year).ToString();
                año = año + "-01-01";
                DataTable re = datos.obtenerAniodeCurso(año);
                enc.Año = re.Rows[0]["id_anio"].ToString();
            }
            else
                enc.Url = "~/View/Profesor/AccesoDenegado.aspx";

            return enc;
        }

        public UUser selecObservador(string documento)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();

            enc.Documento = documento;

            DataTable registro = datos.obtenerUsuarioMod(enc);
            enc.Id_estudiante = registro.Rows[0]["id_usua"].ToString();
            enc.Url = ("~/View/Profesor/ProfesorListado.aspx");

            return enc;
        }

        public UUser insertObservacion(string id, string observacion)
        {
            DUser datos = new DUser();
            UUser enc = new UUser();

            enc.Id_estudiante = id;
            enc.Observacion = observacion;

            datos.insertarObservacion(enc);
            return enc;
        }

        public UUser ActualizarMensajeProf(int ddl_alumno )
        {
            DUser datos = new DUser();
            UUser enc = new UUser();
            int alumno = ddl_alumno;

            DataTable mensaje = datos.acudientemensaje(alumno);
            if (mensaje.Rows.Count > 0)
            {
                enc.Mensaje = mensaje.Rows[0]["correo"].ToString();
                enc.CDestinatario = mensaje.Rows[0]["correo"].ToString();
            }
            else
            {
                enc.Mensaje = "";
            }
            return enc;
        }

        public UUser enviarMensajeProf(string materia, string alumno, string curso, string userId, string persona, string apePersona, string correo_l, string asunto, string mensaje, string tb_destinatario, string destinatario)
        {
            UUser encapsular = new UUser();
            DUser datos = new DUser();
            

            if (materia == "0" || alumno == "0" || curso == "0")
            {
                encapsular.Mensaje = "Debe seleccionar una opcion";
            }
            else
            {
                //CORREO*******************************
                encapsular.Correo = tb_destinatario;
                DataTable resultado = datos.verificarCorreo(encapsular);

                if (resultado.Rows.Count > 0)
                {
                    mensaje = mensaje + "<br><br>Atentamente: " + persona + " " + apePersona + "<br>Correo para responder: " + correo_l + "";
                    string cadena = mensaje;
                    DCorreoEnviar correo = new DCorreoEnviar();
                    correo.enviarCorreoEnviar(destinatario, asunto, mensaje);
                    encapsular.MensajeAcudiente = "mensaje";
                    encapsular.Notificacion = /* "mensaje",*/ "<script type='text/javascript'>alert('Su Mensaje ha sido Enviado.');window.location=\"ProfesorMensaje.aspx\"</script>";
                }
                else
                {
                    encapsular.Mensaje = "El correo digitado no existe";
                    encapsular.CDestinatario = "";
                }
            }
            return encapsular;
        }


        public bool validar_mat(string materia)
        {
            DUser datos = new DUser();
            bool ok = true;
            string matic = materia;
            DataTable mat = datos.validaMateria(matic);

            if (mat.Rows.Count > 0)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }



        public bool validar_materia(string materia)
        {
            DUser datos = new DUser();

            bool ok = true;
            DataTable mat = datos.obtenerMateria();
            int n = mat.DefaultView.Count;
            for (int i = 0; i < n; i++)
            {
                if ((mat.Rows[i]["nombre_materia"].ToString() == materia))
                {
                    return false;
                }
                else
                {
                    ok = true;
                }
            }
            return ok;
        }


        public bool validar_horario(string curso, string dia, string hora)
        {
            DUser datos = new DUser();
            String id = curso;
            int g = int.Parse(id);
            bool ok = true;
            DataTable mat = datos.horarioCurso(g);
            int n = mat.DefaultView.Count;
            for (int i = 0; i < n; i++)
            {
                if ((mat.Rows[i]["dia"].ToString() == dia) & (mat.Rows[i]["hora_inicio"].ToString() == hora))
                {
                    return false;
                }
                else
                {
                    ok = true;
                }
            }
            return ok;
        }

        public bool validar_profesor(string docente, string dia, string hora)
        {
            DUser datos = new DUser();
            String id = docente;
            bool ok = true;
            DataTable mat = datos.horarioProf(id);
            int n = mat.DefaultView.Count;
            for (int i = 0; i < n; i++)
            {
                if ((mat.Rows[i]["dia"].ToString() == dia) & (mat.Rows[i]["hora_inicio"].ToString() == hora))
                {
                    return false;
                }
                else
                {
                    ok = true;
                }
            }
            return ok;
        }

    }
}
