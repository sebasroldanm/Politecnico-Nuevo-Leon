using System;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Configuration;
using System.Collections.Generic;

namespace Datos
{
   public class DMUser
    {

        public void insertarUserMapeo(Usuario user)
        {
            using (var db = new Mapeo("public"))
            {
                db.usuario.Add(user);
                db.SaveChanges();
            }


        }

        public List<Usuario> listarAdministradores()
        {
            using (var db = new Mapeo("public"))
            {

                var admin = db.usuario.ToList<Usuario>().Where(x => x.rol_id.Contains("1"));
                return admin.ToList<Usuario>();

            }

        }


    }
}
