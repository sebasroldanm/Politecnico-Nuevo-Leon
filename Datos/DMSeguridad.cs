using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Utilitarios;
using Utilitarios.MSeguridad;
using Utilitarios.MEncSeguridad;

namespace Datos
{
    public class DMSeguridad
    {
        public void fiel_auditoria_inicio(string _accion, string sesion, MEncInicio enc)
        {
            Auditoria au = new Auditoria();
            USeguridad s = new USeguridad();
            au.fecha = DateTime.Now.ToShortDateString() +" "+ DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            au.accion= _accion;
            au.schema = "inicio";
            au.tabla = "inicio";
            au.pk = "1";
            au.session = sesion;
            au.user_bd = "postgres";
            if(_accion == "UPDATE")
            {
                au.data = JsonConvert.SerializeObject(enc);
                using (var db = new Mapeo("public"))
                {
                    db.auditoria.Add(au);
                    db.SaveChanges();
                }

            }
        }
        public void fiel_auditoria_agrega_estudiantes_curso(string _accion, string sesion, MEncEstCurso enc)
        {
            Auditoria au = new Auditoria();
            au.fecha = DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            au.accion = _accion;
            au.schema = "registro";
            au.tabla = "estudiante_curso";
            au.pk = "1";
            au.session = sesion;
            au.user_bd = "postgres";
            if (_accion == "INSERT")
            {
                au.data = JsonConvert.SerializeObject(enc);
                using (var db = new Mapeo("public"))
                {
                    db.auditoria.Add(au);
                    db.SaveChanges();
                }

            }
        }
        public void fiel_auditoria_agrega_materia(string _accion, string sesion, MEncMateria enc)
        {
            Auditoria au = new Auditoria();
            au.fecha = DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            au.accion = _accion;
            au.schema = "registro";
            au.tabla = "materia";
            au.pk = "1";
            au.session = sesion;
            au.user_bd = "postgres";
            if (_accion == "INSERT")
            {
                au.data = JsonConvert.SerializeObject(enc);
                using (var db = new Mapeo("public")) {
                    db.auditoria.Add(au);
                    db.SaveChanges();

                }
            }
        }

        public void fiel_auditoria_agrega_materia_fecha(string _accion, string sesion, MEncMateriaFecha enc)
        {
        }
    }
}
