using System;
using System.Collections.Generic;
using Utilitarios;
using Utilitarios.MVistasUsuario;
using Utilitarios.MIdioma;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public List<RolUsuario> obtenerroles()
        {
            using (var db = new Mapeo("public"))
            {
                List<RolUsuario> lista = null;
                RolUsuario rol = new RolUsuario();
                lista = new List<RolUsuario>();
                rol.IdRol = 0;
                rol.RolUsua = "Select";
                lista.Add(rol);
                var query = lista;
                var rolU = db.rolUsuario.ToList<RolUsuario>();

                return query.Union(rolU).ToList<RolUsuario>();
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
                var usus = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains(usuario.ToString()))
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
            UUser uuser = new UUser();
            using (var db = new Mapeo("public"))
            {
                var result = db.sesion.SingleOrDefault(x => x.IdSesion == usuario);
                if (result != null)
                {
                    result.SesionUsuario = sesion;
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
                    usua.Session = result.SesionUsuario;
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
                    usua.Control = "no esta";
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

        public List<Controles> listarControlIdiomaEditar(UIdioma enc)
        {
            UIdioma usua = new UIdioma();
            using (var db = new Mapeo("public"))
            {
                var contr = db.controles.ToList<Controles>()
                    .Where(x => x.con_formulario_id == int.Parse(enc.IdFormulario))
                    .Where(x => x.control == enc.Control)
                    .Where(x => x.con_idioma_id == int.Parse(enc.IdIdioma));
                var result = db.controles.SingleOrDefault(x => x.con_formulario_id == int.Parse(enc.IdFormulario));
                return contr.ToList<Controles>();
            }

        }



    }
}
