using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
public class APIContext : DbContext
{
    public DbSet<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas {get; set;}
    public DbSet<Asignatura> Asignaturas {get; set;}
    public DbSet<CursoEscolar> CursosEscolares {get; set;}
    public DbSet<Departamento> Departamentos {get; set;}
    public DbSet<Grado> Grados {get; set;}
    public DbSet<Persona> Personas {get; set;}
    public DbSet<Profesor> Profesores {get; set;}
    public APIContext(DbContextOptions<APIContext> options) : base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
