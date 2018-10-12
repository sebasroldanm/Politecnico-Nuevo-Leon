using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Utilitarios;
using Utilitarios.Mregistro;
using Utilitarios.Mlugares;
using Utilitarios.MIdioma;

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
        public DbSet<Anio> anio { get; set; }
        public DbSet<AnioCurso> aniocurso { get; set; }
        public DbSet<Curso> curso { get; set; }
        public DbSet<CursoMateria>cursomateria { get; set; }
        public DbSet<DiaMateria>diamateria { get; set; }
        public DbSet<EstudianteCurso>estudiantecurso { get; set; }
        public DbSet<Materia>materia { get; set; }
        public DbSet<MateriaFecha>materiafecha { get; set; }
        public DbSet<Nota>nota { get; set; }
        public DbSet<Observador>observador { get; set; }
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<Ciudad> ciudad { get; set; }

        public DbSet<Controles> controles { get; set; }
        public DbSet<Formulario> formulario { get; set; }
        public DbSet<Idioma> idioma { get; set; }
        public DbSet<RolIdioma> rolIdioma { get; set; }
        public DbSet<Terminacion> terminacion { get; set; }

        public DbSet<Inicio> inicio { get; set; }




        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}
