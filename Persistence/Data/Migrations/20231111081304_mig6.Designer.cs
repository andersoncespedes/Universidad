﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20231111081304_mig6")]
    partial class mig6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AsignaturaCursoEscolar", b =>
                {
                    b.Property<int>("AsignaturasId")
                        .HasColumnType("int");

                    b.Property<int>("CursoEscolaresId")
                        .HasColumnType("int");

                    b.HasKey("AsignaturasId", "CursoEscolaresId");

                    b.HasIndex("CursoEscolaresId");

                    b.ToTable("AsignaturaCursoEscolar");
                });

            modelBuilder.Entity("Domain.Entities.AlumnoSeMatriculaAsignatura", b =>
                {
                    b.Property<int>("IdAlumnoFk")
                        .HasColumnType("int")
                        .HasColumnName("id_alumno");

                    b.Property<int>("IdAsignaturaFk")
                        .HasColumnType("int")
                        .HasColumnName("id_asignatura");

                    b.Property<int>("IdCursoEscolarFk")
                        .HasColumnType("int")
                        .HasColumnName("id_curso_escolar");

                    b.HasKey("IdAlumnoFk", "IdAsignaturaFk", "IdCursoEscolarFk");

                    b.HasIndex("IdAsignaturaFk");

                    b.HasIndex("IdCursoEscolarFk");

                    b.ToTable("alumno_se_matricula_asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<float>("Creditos")
                        .HasPrecision(2, 8)
                        .HasColumnType("float")
                        .HasColumnName("creditos");

                    b.Property<sbyte>("Cuatrimestre")
                        .HasColumnType("tinyint")
                        .HasColumnName("cuatrimestre");

                    b.Property<sbyte>("Curso")
                        .HasColumnType("tinyint")
                        .HasColumnName("curso");

                    b.Property<int>("IdGradoFk")
                        .HasColumnType("int");

                    b.Property<int?>("IdProfesorFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Tipos")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("tipo")
                        .HasAnnotation("EnumDisplayFormat", "{0}");

                    b.HasKey("Id");

                    b.HasIndex("IdGradoFk");

                    b.HasIndex("IdProfesorFk");

                    b.ToTable("asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("AnyoFin")
                        .HasColumnType("year")
                        .HasColumnName("anyo_fin");

                    b.Property<short>("AnyoInicio")
                        .HasColumnType("year")
                        .HasColumnName("anyo_inicio");

                    b.HasKey("Id");

                    b.ToTable("curso_escolar", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("grado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido1");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido2");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("ciudad");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("direccion");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date")
                        .HasColumnName("fecha_nacimiento");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("nif");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("nombre");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("sexo")
                        .HasAnnotation("EnumDisplayFormat", "{0}");

                    b.Property<string>("Telefono")
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)")
                        .HasColumnName("telefono");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("tipo")
                        .HasAnnotation("EnumDisplayFormat", "{0}");

                    b.HasKey("Id");

                    b.HasIndex("Nif")
                        .IsUnique();

                    b.HasIndex("Telefono")
                        .IsUnique();

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdDepartamento")
                        .HasColumnType("int")
                        .HasColumnName("id_departamento");

                    b.Property<int>("IdProfesorFk")
                        .HasColumnType("int")
                        .HasColumnName("id_profesor");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdProfesorFk");

                    b.ToTable("profesor", (string)null);
                });

            modelBuilder.Entity("AsignaturaCursoEscolar", b =>
                {
                    b.HasOne("Domain.Entities.Asignatura", null)
                        .WithMany()
                        .HasForeignKey("AsignaturasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CursoEscolar", null)
                        .WithMany()
                        .HasForeignKey("CursoEscolaresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AlumnoSeMatriculaAsignatura", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "Alumno")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdAlumnoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Asignatura", "Asignatura")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdAsignaturaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CursoEscolar", "CursoEscolar")
                        .WithMany("AlumnoSeMatriculaAsignaturas")
                        .HasForeignKey("IdCursoEscolarFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Asignatura");

                    b.Navigation("CursoEscolar");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdGradoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdProfesorFk");

                    b.Navigation("Grado");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Profesores")
                        .HasForeignKey("IdDepartamento");

                    b.HasOne("Domain.Entities.Persona", "ProfesorP")
                        .WithMany("Profesores")
                        .HasForeignKey("IdProfesorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("ProfesorP");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("AlumnoSeMatriculaAsignaturas");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Navigation("Asignaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
