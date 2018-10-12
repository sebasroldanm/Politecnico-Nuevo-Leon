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
                var idiom = db.controles.ToList<Controles>().Where(x => x.con_formulario_id == form).Where(x => x.con_idioma_id == idioma);
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





    }
}
