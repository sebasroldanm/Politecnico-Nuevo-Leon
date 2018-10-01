using System;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Configuration;


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




    }
}
