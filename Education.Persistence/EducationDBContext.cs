using Education.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Persistence
{
    public class EducationDBContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }

        public EducationDBContext()
        {

        }

        public EducationDBContext(DbContextOptions<EducationDBContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("server=.;database=Education;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(c => c.Precio)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso C# básico",
                    Titulo = "C# desde cero hasta avanzado",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 56
                }
            );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Java",
                    Titulo = "Master en Java Spring desde las raices",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 25
                }
            );

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Descripcion = "Curso de Unit Test para Net Core",
                    Titulo = "Master en Unit Test con CQRS",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 1000
                }
            );
        }
    }
}
