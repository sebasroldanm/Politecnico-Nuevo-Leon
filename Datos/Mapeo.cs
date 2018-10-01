using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Utilitarios;

namespace Datos
{
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo(string schema)
            : base("name=Postgres")
        {
            this.schema = schema;
        }


        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Sesion> sesion { get; set; }
        public DbSet<TokenRecuperaUsuario> tokenRecuperaUsuarios { get; set; }
        public DbSet<Acudiente> acudiente { get; set; }
        public DbSet<RolUsuario> rolUsuario { get; set; }


        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}
