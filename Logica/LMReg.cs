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
using Utilitarios.MEncSeguridad;
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
                    horar = muser.horarioProfesor(id_curso); ;
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
        
        public UUser agregarMateria(Materia materia, string sesion, int selIdioma)////aqui
        {
            UUser user = new UUser();
            DMReg datos = new DMReg();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 10;
            Materia mat = new Materia();
            DMSeguridad dmseg = new DMSeguridad();
            MEncMateria mencmateria = new MEncMateria();


            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            user.Mensaje = " ";
            bool ok = datos.validaMateria(materia);

            if (ok == true)
            {        
                materia.sesion = sesion;
                materia.ultima_modificacion = DateTime.Now.ToShortDateString();
                datos.insertarMateria(materia, sesion);
                //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada con Exito');</script>");
                user.Mensaje = encId.CompIdioma["L_Error_falta_materia"].ToString(); //"Materia Insertada con Exito";
                mencmateria.nombre_materia_nuevo = materia.nombre_materia;
                mencmateria.sesion_nuevo = materia.sesion;
                dmseg.fiel_auditoria_agrega_materia("INSERT", sesion, mencmateria);


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
            Nota not = new Nota();
            LMIdioma idioma = new LMIdioma();
            DMSeguridad dmseg = new DMSeguridad();
            MEncNota mencnota = new MEncNota();
            Int32 FORMULARIO = 39;
        

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
                mencnota.nota1_nuevo = not.nota1.ToString();
                mencnota.nota2_nuevo = not.nota2.ToString();
                mencnota.nota3_nuevo = nota3.ToString();
                mencnota.notadef_nuevo = not.notadef.ToString();
                dmseg.fiel_auditoria_registro_nota("INSERT", mencnota);
            }
            return enc;
        }

        public UUser PL_EstudianteVerNotas(string userId)
        {
            
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
        
        public UUser selecEstudianteACurso(string curso, string seleccion, int selIdioma)
        {
            DMUser datos = new DMUser();
            UUser enc = new UUser();
            DMReg mreg = new DMReg();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();

            List<Usuario> lusua = new List<Usuario>();

           EstudianteCurso est = new EstudianteCurso();
            Int32 FORMULARIO = 9;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);

            if (curso == "0")
            {
                enc.Mensaje = encId.CompIdioma["L_ErrorUsuario_estudiante_curso"].ToString(); //"Debe Elegir un Curso";
            }
            else
            {
                enc.Documento = seleccion;
                enc = datos.obtenerUsuarioMod(enc);

                est.id_ec_curso = int.Parse(enc.IdUsua);
                est.id_ec_estudiante = int.Parse(curso);
                enc.Id_estudiante = est.id_ec_estudiante.ToString();

                mreg.insertarEstudianteCurso(est);

                List<Materia> materias = mreg.obtener_MatCur(enc);

                foreach (Materia m in materias)
                {
                    enc.Materia = m.id_materia.ToString();
                    mreg.insertarNotaMateria(enc);
                }
                //int n = materias.DefaultView.Count;

                //for (int i = 0; i < n; i++)
                //{
                //    enc.Materia = materias.Rows[i]["id_materia"].ToString();
                //    datos.insertarNotaMateria(enc);

                //}

                enc.Mensaje = "";
            }

            return enc;
        }
        
        public UUser agregarEstudianteACurso(string anio, string curso,string sesion, int cont, GridView GridView1, int selIdioma)
        {
            DMUser datos = new DMUser();
            UUser enc = new UUser();
            DMReg mreg = new DMReg();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            DMSeguridad dmseg = new DMSeguridad();
            MEncEstCurso mencest = new MEncEstCurso();
            Int32 FORMULARIO = 9;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);


            enc.Mensaje = "";
            enc.MensajeAcudiente = "";

            if (anio == "0" || curso == "0")
            {
                enc.Mensaje = encId.CompIdioma["L_ErrorUsuario_aceptar"].ToString(); //"Debe Elegir un Curso";
            }
            else
            {
                for (int i = 0; i < cont; i++)
                {



                    CheckBox ch = (CheckBox)GridView1.Rows[i].FindControl("CBest");
                    Label lb = (Label)GridView1.Rows[i].FindControl("label1");

                    if (ch.Checked == true)
                    {
                        enc.Documento = lb.Text;
                        //DataTable reg = datos.obtenerUsuarioMod(enc);
                        
                        enc = datos.obtenerUsuarioMod(enc);

                        enc.Id_estudiante = enc.IdUsua;
                        enc.Curso = curso;

                        EstudianteCurso ecur = new EstudianteCurso();
                        ecur.id_ec_curso = int.Parse(curso);
                        ecur.id_ec_estudiante = int.Parse(enc.Id_estudiante);
                        mreg.insertarEstudianteCurso(ecur);

                        List<Materia> materias = mreg.obtener_MatCur(enc);
                        foreach(Materia m in materias)
                        {
                            enc.Materia = m.id_materia.ToString();
                            mreg.insertarNotaMateria(enc);
                        }
                        //int n = materias.DefaultView.Count;

                        //for (int k = 0; k < n; k++)
                        //{
                        //    enc.Materia = materias.Rows[k]["id_materia"].ToString();
                        //    mreg.insertarNotaMateria(enc);

                        //}

                        //L_ErrorUsuario.Text = "Debe Elegir un Curso";
                        enc.MensajeAcudiente = encId.CompIdioma["L_OkUsuario_aceptar"].ToString(); //"Estudiantes Agregados al curso";
                        mencest.id_ec_estudiante_nuevo = ecur.id_ec_estudiante;
                        mencest.id_ec_curso_nuevo = ecur.id_ec_curso;
                        dmseg.fiel_auditoria_agrega_estudiantes_curso("INSERT", sesion, mencest);


                    }
                }

            }
            return enc;
        }
        
        public UUser agregaraHorario(string curso, string anio, string dia, string docente, string hora, string materia, int selIdioma)
        {
            UUser enc = new UUser();
            DMReg datos = new DMReg();
            DMUser muser = new DMUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 10;

            encId = idioma.obtIdioma(FORMULARIO, selIdioma);


            enc.Mensaje = " ";
            if (curso == "0" || anio == "0" || dia == "0" || docente == "0" || hora == "0" || materia == "0")
            {
                enc.Mensaje = encId.CompIdioma["L_Error_falta"].ToString(); //"Falta seleccionar";
            }
            else
            {
                bool ok = validar_horario(curso, dia, hora);

                if (ok == true)
                {
                    bool wp = validar_profesor(docente, dia, hora);
                    if (wp == true)
                    {
                        if (dia == "Monday")
                        {
                            dia = "Lunes";
                        }
                        if (dia == "Tuesday")
                        {
                            dia = "Martes";
                        }
                        if (dia == "Wednesday")
                        {
                            dia = "Miercoles";
                        }
                        if (dia == "Thursday")
                        {
                            dia = "Jueves";
                        }
                        if (dia == "Friday")
                        {
                            dia = "Viernes";
                        }
                        enc.Materia = materia;
                        enc.Dia_materia = dia;
                        enc.Hora_in = hora;

                        List<MateriaFecha> registros = datos.obtenerHora(enc);
                        if (registros.Count > 0)
                        {
                            foreach(MateriaFecha mf in registros)
                            {
                                enc.Cur_mat = mf.id_mf.ToString();  //registros.Rows[0]["id_mf"].ToString();
                                enc.Curso = curso;
                                enc.Id_docente = docente;

                                datos.insertarCursoMateria(enc);
                            }
                            
                        }
                        int cur = Convert.ToInt32(curso);
                        List<Usuario> est = muser.gEstudiante(cur);
                        
                        foreach(Usuario u in est)
                        {
                            enc.Id_estudiante = u.id_usua.ToString();
                            enc.Materia = materia;
                            datos.insertarNotaMateria(enc);
                        }

                        //int n = est.DefaultView.Count;

                        //for (int i = 0; i < n; i++)
                        //{
                        //    enc.Id_estudiante = est.Rows[i]["id_usua"].ToString();
                        //    enc.Materia = materia;
                        //    datos.insertarNotaMateria(enc);
                        //}
                        enc.Mensaje = encId.CompIdioma["L_Error_materia_insertada"].ToString(); //"Materia Insertada a Curso con Exito";
                        //this.Page.Response.Write("<script language='JavaScript'>window.alert('Materia Insertada a Curso con Exito');</script>");


                    }
                    else
                    {
                        enc.Mensaje = encId.CompIdioma["L_Error_docente_cruce"].ToString(); //"El docente presenta un cruce de Horarios";
                    }
                }
                else
                {
                    enc.Mensaje = encId.CompIdioma["L_Error_curce"].ToString(); //"Presenta un cruce de Horarios";
                }

            }
            return enc;

        }
        //Funcion de agregaraHorario
        public bool validar_horario(string curso, string dia, string hora)
        {
            DMReg datos = new DMReg();
            String id = curso;
            int g = int.Parse(id);
            bool ok = true;
            List<HorarioEstudiante> mat = datos.horarioCurso(g);
            //int n = mat.DefaultView.Count;
            //for (int i = 0; i < n; i++)
            //{
            //    if ((mat.Rows[i]["dia"].ToString() == dia) & (mat.Rows[i]["hora_inicio"].ToString() == hora))
            //    {
            foreach(HorarioEstudiante h in mat)
            {
                if ((h.dia.ToString() == dia) & (h.hora_inicio.ToString() == hora))
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
        //Funcion de agregaraHorario
        public bool validar_profesor(string docente, string dia, string hora)
        {
            DMReg datos = new DMReg();
            String id = docente;
            bool ok = true;
            List<HorarioEstudiante> mat = datos.horarioProfesor(int.Parse(id));
            //int n = mat.DefaultView.Count;
            //for (int i = 0; i < n; i++)
            //{
            //    if ((mat.Rows[i]["dia"].ToString() == dia) & (mat.Rows[i]["hora_inicio"].ToString() == hora))
            //    {
            foreach(HorarioEstudiante h in mat)
            {
                if ((h.dia.ToString() == dia) & (h.hora_inicio.ToString() == hora))
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

        public UUser verNota(string alumno, string materia, string curso, int selIdioma)
        {
            DMReg datos = new DMReg();
            UUser enc = new UUser();
            UIdioma encId = new UIdioma();
            LMIdioma idioma = new LMIdioma();
            Int32 FORMULARIO = 39;

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
                try
                {
                    foreach (Nota n in registros)
                    {
                        enc.Nota1 = n.nota1.ToString();
                        enc.Nota2 = n.nota2.ToString();
                        enc.Nota3 = n.nota3.ToString();

                        enc.Notadef = n.notadef.ToString();
                        //enc.Nota1 = registros.Rows[0]["nota1"].ToString();
                        //enc.Nota2 = registros.Rows[0]["nota2"].ToString();
                        //enc.Nota3 = registros.Rows[0]["nota3"].ToString();

                        //enc.Notadef = registros.Rows[0]["notadef"].ToString();
                    }
                }
                catch
                {

                }
            }
            return enc;
        }

        public UUser ActualizarMensajeProf(int ddl_alumno)
        {
            DMReg datos = new DMReg();
            UUser enc = new UUser();
            int alumno = ddl_alumno;

            List<Usuario> mensaje = datos.acudientemensaje(alumno);
            if (mensaje.Count > 0)
            {
                foreach (Usuario u in mensaje)
                {
                    enc.Mensaje = u.correo.ToString();
                    enc.CDestinatario = u.correo.ToString();
                }
            }
            else
            {
                enc.Mensaje = "";
            }
            return enc;
        }

        public UUser selecObservador(string documento)
        {
            DMUser datos = new DMUser();
            UUser enc = new UUser();

            enc.Documento = documento;

            UUser registro = datos.obtenerUsuarioMod(enc);
            enc.Id_estudiante = registro.IdUsua.ToString();
            enc.Url = ("~/View/Profesor/ProfesorListado.aspx");

            return enc;
        }

        public UUser insertObservacion(string id, string observacion)
        {
            DMReg datos = new DMReg();
            UUser enc = new UUser();
            Observador obd = new Observador();
            DMSeguridad dmseg = new DMSeguridad();
            MEnsObservador mencob = new MEnsObservador();
            enc.Id_estudiante = id;
            enc.Observacion = observacion;

            datos.insertarObservacion(enc);
            mencob.id_estudiante_nuevo = int.Parse(id);
            mencob.observacion_nuevo = observacion;
            dmseg.fiel_auditoria_agrega_orservador("INSERT", mencob);



            return enc;
        }
    }


}
