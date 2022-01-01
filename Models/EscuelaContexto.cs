using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
namespace platzi_asp_net_core.Models
{
    public class EscuelaConexto : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Evaluación> Evaluaciones { get; set; }

        public EscuelaConexto(DbContextOptions<EscuelaConexto> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela();
            escuela.AñoDeCreación = 2005;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Platzi School";
            escuela.Ciudad = "Bogota";
            escuela.Pais = "Colombia";
            escuela.Dirección = "Avd Siempre viva";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            modelBuilder.Entity<Escuela>().HasData(escuela);
            var cursos = CargarCursos(escuela);
            var asignaturas =  CargarAsignaturas(cursos);

            modelBuilder.Entity<Asignatura>().HasData(
                           new Asignatura
                           {
                               Nombre = "Matemáticas",

                               Id = Guid.NewGuid().ToString()
                           },
                            new Asignatura
                            {
                                Nombre = "Educación Física",
                                Id = Guid.NewGuid().ToString()
                            },
                            new Asignatura
                            {
                                Nombre = "Castellano",
                                Id = Guid.NewGuid().ToString()
                            },
                            new Asignatura
                            {
                                Nombre = "Ciencias Naturales",
                                Id = Guid.NewGuid().ToString()
                            }
                            ,
                            new Asignatura
                            {
                                Nombre = "Programación",
                                Id = Guid.NewGuid().ToString()
                            }
                           );

            modelBuilder.Entity<Alumno>()
                        .HasData(GenerarAlumnosAlAzar().ToArray());
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos)
        {
            var Listacompleta =  new List<Asignatura> ();
            foreach (var curso in cursos)
            {
                List<Asignatura> asignaturas = new List<Asignatura>{
                    new Asignatura
                           {
                               Nombre = "Matemáticas",
                               CursoId = curso.Id,
                               Id = Guid.NewGuid().ToString()
                           },
                           new Asignatura
                           {
                                 Nombre = "Español",
                               CursoId = curso.Id,
                               Id = Guid.NewGuid().ToString()
                           },
                           new Asignatura
                           {
                                   Nombre = "Geometria",
                               CursoId = curso.Id,
                               Id = Guid.NewGuid().ToString()
                           },
                           new Asignatura
                           {
                                   Nombre = "fisica",
                               CursoId = curso.Id,
                               Id = Guid.NewGuid().ToString()
                           },
                           new Asignatura
                           {
                                  Nombre = "programacion",
                               CursoId = curso.Id,
                               Id = Guid.NewGuid().ToString()
                           },
                };
                Listacompleta.AddRange(asignaturas);
                curso.Asignaturas = asignaturas;
            }
            return Listacompleta;
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                new Curso(){
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="101",
                    Jornada= TiposJornada.Mañana
                },
                     new Curso(){
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="430",
                    Jornada= TiposJornada.Mañana
                },
                     new Curso(){
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="230",
                    Jornada= TiposJornada.Mañana
                },
                     new Curso(){
                    Id = Guid.NewGuid().ToString(),
                    EscuelaId = escuela.Id,
                    Nombre="503",
                    Jornada= TiposJornada.Mañana
                },
            };
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso CURSO, int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   CursoId = CURSO.Id,
                                   Nombre = $"{n1} {n2} {a1}",
                                   Id = Guid.NewGuid().ToString()
                               };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();

        }

    }
}