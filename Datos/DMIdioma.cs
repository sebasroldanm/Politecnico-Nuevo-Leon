﻿using System;
using System.Collections.Generic;
using Utilitarios;
using Utilitarios.MVistasUsuario;
using Utilitarios.MIdioma;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Datos
{
    public class DMIdioma
    {
        public List<Controles> obtenerIdioma(int form, int idioma)
        {
            using (var db = new Mapeo("public"))
            {
                var idiom = db.controles.ToList<Controles>()
                    .Where(x => x.con_formulario_id == form)
                    .Where(x => x.con_idioma_id == idioma);
                return idiom.ToList<Controles>();
            }

        }




        public List<Idioma> obtenerSeleccionIdioma()
        {
            using (var db = new Mapeo("public"))
            {
                return (db.idioma.ToList<Idioma>().OrderBy(i => i.id_idioma)).ToList<Idioma>();
            }

        }



        public void eliminarControles(int idioma)
        {
            List<Controles> contro = new List<Controles>();
            using (var db = new Mapeo("public"))
            {
                contro = db.controles.ToList<Controles>().Where(x => x.con_idioma_id == idioma).ToList();
                foreach (Controles c in contro)
                {
                    var result = db.controles.SingleOrDefault(y => y.id_controles == c.id_controles);
                    if (result != null)
                    {
                        db.controles.Remove(result);
                        db.SaveChanges();
                    }
                }
            }

        }

        public void eliminarIdioma(int idioma)
        {
            using (var db = new Mapeo("public"))
            {
                var result = db.idioma.SingleOrDefault(y => y.id_idioma == idioma);
                if (result != null)
                {
                    db.idioma.Remove(result);
                    db.SaveChanges();
                }

            }


        }

        public List<UsuarioVista> listarusuariosxrol(int usuario)
        {
            using (var db = new Mapeo("public"))
            {
                List<UsuarioVista> lista = null;
                UsuarioVista us = new UsuarioVista();
                us.id_usua = 0;
                us.nombre_usua = "Select";
                lista = new List<UsuarioVista>();
                lista.Add(us);
                var query = lista;
                var usus = db.usuario.ToList<Usuario>().Where(x => x.rol_id == usuario)
                    .Select (m => new UsuarioVista
                    {
                        id_usua = m.id_usua,
                        nombre_usua = m.nombre_usua + " " + m.apellido_usua
                    }).ToList();

                return query.Union(usus).ToList<UsuarioVista>();
            }

        }

        public void editarsesionusua(int usuario, string sesion)
        {
            int s = int.Parse(sesion);
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdSesion == usuario);
                if (result != null)
                {
                    result.SesionUsuario = s;
                    db.SaveChanges();
                }
            }
        }

        public UUser listarSesion(int usuario)
        {
            UUser usua = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdSesion == usuario);
                if (result != null)
                {
                    usua.Session = result.SesionUsuario.ToString();
                }
            }
            return usua;
        }

        public void insertarIdioma(Idioma enc)
        {
            using (var db = new Mapeo("public"))
            {
                db.idioma.Add(enc);
                db.SaveChanges();
            }
        }
        
        public UIdioma verificarIdiomaBD(string termin)
        {
            UIdioma usua = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                if (db.idioma.LongCount(x => x.terminacion == termin) != 0)
                {
                    usua.Control = "ya esta";
                    var resut = db.idioma.SingleOrDefault(x => x.terminacion == termin);
                    usua.IdIdioma = resut.id_idioma.ToString();
                }
                else
                {
                    if (db.terminacion.LongCount(y => y.termino == termin) != 0)
                    {
                        usua.Control = "no esta";
                    }
                }
            }
            return usua;
        }

        public UIdioma contadorControl(int idIdioma)
        {
            UIdioma usua = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                var result = db.controles.Count(x => x.con_idioma_id == idIdioma);
                if (result != 0)
                {
                    usua.Contador = int.Parse(result.ToString());
                }
            }
            return usua;
        }

        public UIdioma listarIdiomaVarchar(string nombre)
        {
            UIdioma usua = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                var result = db.idioma.SingleOrDefault(x => x.nombre == nombre);
                if (result != null)
                {
                    usua.IdIdioma = result.id_idioma.ToString();
                }
            }
            return usua;
        }

        public void insertarIdiomaControles(Controles enc)
        {
            using (var db = new Mapeo("public"))
            {
                db.controles.Add(enc);
                db.SaveChanges();
            }
        }

        public List<Controles> listarControlIdiomaEditar(string form, string control, string idIdioma)
        {
            UIdioma usua = new UIdioma();
            using (var db = new Mapeo("public"))
                
            {
                var contr = db.controles.ToList<Controles>()
                    .Where(x => x.con_formulario_id == Convert.ToInt32(form))
                    .Where(x => x.control == control)
                    .Where(x => x.con_idioma_id == Convert.ToInt32(idIdioma));

                return contr.ToList<Controles>();
            }

        }

        public void editarIdiomaControl(int id, string texto)
        {
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.controles.SingleOrDefault(x => x.id_controles == id);
                if (result != null)
                {
                    result.texto = texto;
                    db.SaveChanges();
                }
            }
        }

        public List<Formulario> listarFormulario(int idioma)
        {
            using (var db = new Mapeo("public"))
            {

                
                Formulario formSelect = new Formulario();
                List<Formulario> lista = new List<Formulario>();
                formSelect.id_formulario = 0;
                formSelect.nombre = "Selec.";
                formSelect.url = "";

                lista.Add(formSelect);
                var q = lista;

                                           
                List<Formulario> f = new List<Formulario>();
                Formulario form = new Formulario();
               
                var rol = f;
                if (idioma == 0)
                {
                    form.id_formulario = 0;
                    form.nombre = "";
                    form.url = "";
                    f.Add(form);
                    rol = f;
                }
                if (idioma == 1)
                {
                    rol = (db.formulario.ToList<Formulario>().Where(x => x.id_formulario >= 30 &&  x.id_formulario <= 33 || x.id_formulario >= 40 && x.id_formulario <= 43)).ToList<Formulario>();
                }
                if (idioma == 2)
                {
                    rol = (db.formulario.ToList<Formulario>().Where(x => x.id_formulario >= 5 && x.id_formulario <= 24 || x.id_formulario >= 44 && x.id_formulario <= 53)).ToList<Formulario>();
                }
                if (idioma == 3)
                {
                    rol = (db.formulario.ToList<Formulario>().Where(x => x.id_formulario >= 34 && x.id_formulario <= 39 || x.id_formulario >= 61 && x.id_formulario <= 62)).ToList<Formulario>();
                }
                if (idioma ==  4)
                {
                    rol = (db.formulario.ToList<Formulario>().Where(x => x.id_formulario >= 25 && x.id_formulario <= 29 || x.id_formulario == 60)).ToList<Formulario>();
                }
                if (idioma == 5)
                {
                    rol = (db.formulario.ToList<Formulario>().Where(x => x.id_formulario >= 1 && x.id_formulario <= 4 || x.id_formulario >= 58 && x.id_formulario <= 59)).ToList<Formulario>();
                }
                return q.Union(rol).ToList<Formulario>();
            }
        }

        public List<RolUsuario> obtenerroles()
        {
            using (var db = new Mapeo("public"))
            {
                RolUsuario formSelect = new RolUsuario();
                List<RolUsuario> lista = new List<RolUsuario>();
                formSelect.id_rol = 0;
                formSelect.nombre_rol = "Selec.";

                lista.Add(formSelect);
                var q = lista;


                List<RolUsuario> f = new List<RolUsuario>();
                RolUsuario form = new RolUsuario();

                var rol = f;
                rol = (db.rolUsuario.ToList<RolUsuario>().ToList<RolUsuario>());
                return q.Union(rol).ToList<RolUsuario>();
            }

        }
        
        public List<RolIdioma> obtenerRolIdioma()
        {
            using (var db = new Mapeo("public"))
            {
                RolIdioma formSelect = new RolIdioma();
                List<RolIdioma> lista = new List<RolIdioma>();
                formSelect.id_rol_idioma = 0;
                formSelect.rol_idioma = "Selec.";

                lista.Add(formSelect);
                var q = lista;


                List<RolIdioma> f = new List<RolIdioma>();
                RolIdioma form = new RolIdioma();

                var rol = f;
                rol = (db.rolIdioma.ToList<RolIdioma>().ToList<RolIdioma>());
                return q.Union(rol).ToList<RolIdioma>();
            }

        }

        public List<Controles> listarIdiomaControles(UIdioma idioma)
        {

            int form = int.Parse(idioma.IdFormulario);
            using (var db = new Mapeo("public"))
            {
                var control = (from controles in db.controles
                               where controles.con_formulario_id == form
                               where controles.control == idioma.Control
                               select
                               controles

                    ).ToList();
                return control.ToList<Controles>();
            }
            
        }

        public List<Idioma> obtenerTraerIdioma(string idioma)
        {
            using (var db = new Mapeo("publich"))
            {
                var nomidi = db.idioma.ToList<Idioma>().Where(c => c.nombre == idioma).ToList<Idioma>();
                return nomidi.ToList<Idioma>();                  

            }

        }

        public List<Controles> listarIdiomaControlesEditar(UIdioma idioma)
        {

           int form = int.Parse(idioma.IdFormulario);
           int idi = int.Parse(idioma.IdIdioma);
            using (var bd = new Mapeo("public"))
            {
                var control = (from controles in bd.controles
                               where controles.con_formulario_id == form
                               where controles.control == idioma.Control
                               where controles.con_idioma_id == idi
                               select
                               controles
                    ).ToList();
                return control.ToList<Controles>();
            }


        }

        public List<Controles> listarControles(int idioma)
        {
            using (var db = new Mapeo("public"))
            {
                Controles formSelect = new Controles();
                List<Controles> lista = new List<Controles>();
                formSelect.id_controles = 0;
                formSelect.texto = "Selec.";

                lista.Add(formSelect);
                var q = lista;


                List<Controles> f = new List<Controles>();
                Controles form = new Controles();

                var rol = f;
                rol = (db.controles.ToList<Controles>().Where(x => x.con_formulario_id == idioma && x.con_idioma_id == 1).ToList<Controles>());
                return q.Union(rol).ToList<Controles>();
            }

        }

        //public List<RolUsuario> listarusuariosxrol(int usuario)
        //{
        //    using (var db = new Mapeo("public"))
        //    {
        //        RolUsuario formSelect = new RolUsuario();
        //        List<RolUsuario> lista = new List<RolUsuario>();
        //        formSelect.id_rol = 0;
        //        formSelect.nombre_rol = "Selec.";

        //        lista.Add(formSelect);
        //        var q = lista;


        //        List<RolUsuario> f = new List<RolUsuario>();
        //        RolUsuario form = new RolUsuario();

        //        var rol = f;
        //        rol = (db.rolUsuario.ToList<RolUsuario>().ToList<RolUsuario>());
        //        return q.Union(rol).ToList<RolUsuario>();
        //    }

        //}

        public List<Idioma> obtenerTerminacionIdioma(int idioma)
        {
            using (var db = new Mapeo("public"))
            {
                var idiom = db.idioma.ToList<Idioma>().Where(x => x.id_idioma == idioma);
                return idiom.ToList<Idioma>();
            }
        }

        // Funcion de Idioma Migracion a SQL Server
        public DataTable listarControlesExcluir(int formular, string idioma)
        {
            DataTable list = new DataTable();

            DIdioma postgres = new DIdioma();
            DSql sqlserver = new DSql();

            using (var db = new Mapeo("public"))
            {
                if ((db.Database.Connection).ToString() == "Npgsql.NpgsqlConnection")
                {
                    list = postgres.listarControlesExcluir(formular, idioma);
                }
                else
                {
                    list = sqlserver.listarControlesExcluir(formular, idioma);
                }
            }
            return list;
        }

        /////////////////////////////////////////
    }
}
