using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EscuelaACM.Models
{
    public partial class ModeloEscuela : DbContext
    {
        public ModeloEscuela()
            : base("name=ModeloEscuela")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<GrupoAlumno> GruposAlumnos { get; set; }
    }
}
