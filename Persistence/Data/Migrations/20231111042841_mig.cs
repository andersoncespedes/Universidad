using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    anyo_inicio = table.Column<short>(type: "year", nullable: false),
                    anyo_fin = table.Column<short>(type: "year", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_escolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nif = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ciudad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    sexo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_profesor = table.Column<int>(type: "int", nullable: false),
                    id_departamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesor_departamento_id_departamento",
                        column: x => x.id_departamento,
                        principalTable: "departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profesor_persona_id_profesor",
                        column: x => x.id_profesor,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creditos = table.Column<float>(type: "float", precision: 2, scale: 8, nullable: false),
                    tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    curso = table.Column<sbyte>(type: "tinyint", nullable: false),
                    cuatrimestre = table.Column<sbyte>(type: "tinyint", nullable: false),
                    IdProfesorFk = table.Column<int>(type: "int", nullable: true),
                    IdGradoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.id);
                    table.ForeignKey(
                        name: "FK_asignatura_grado_IdGradoFk",
                        column: x => x.IdGradoFk,
                        principalTable: "grado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignatura_profesor_IdProfesorFk",
                        column: x => x.IdProfesorFk,
                        principalTable: "profesor",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alumno_se_matricula_asignatura",
                columns: table => new
                {
                    id_alumno = table.Column<int>(type: "int", nullable: false),
                    id_asignatura = table.Column<int>(type: "int", nullable: false),
                    id_curso_escolar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumno_se_matricula_asignatura", x => new { x.id_alumno, x.id_asignatura, x.id_curso_escolar });
                    table.ForeignKey(
                        name: "FK_alumno_se_matricula_asignatura_asignatura_id_asignatura",
                        column: x => x.id_asignatura,
                        principalTable: "asignatura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumno_se_matricula_asignatura_curso_escolar_id_curso_escolar",
                        column: x => x.id_curso_escolar,
                        principalTable: "curso_escolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumno_se_matricula_asignatura_persona_id_alumno",
                        column: x => x.id_alumno,
                        principalTable: "persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignaturaCursoEscolar",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    CursoEscolaresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCursoEscolar", x => new { x.AsignaturasId, x.CursoEscolaresId });
                    table.ForeignKey(
                        name: "FK_AsignaturaCursoEscolar_asignatura_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "asignatura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaCursoEscolar_curso_escolar_CursoEscolaresId",
                        column: x => x.CursoEscolaresId,
                        principalTable: "curso_escolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alumno_se_matricula_asignatura_id_asignatura",
                table: "alumno_se_matricula_asignatura",
                column: "id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_alumno_se_matricula_asignatura_id_curso_escolar",
                table: "alumno_se_matricula_asignatura",
                column: "id_curso_escolar");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdGradoFk",
                table: "asignatura",
                column: "IdGradoFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdProfesorFk",
                table: "asignatura",
                column: "IdProfesorFk");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCursoEscolar_CursoEscolaresId",
                table: "AsignaturaCursoEscolar",
                column: "CursoEscolaresId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_nif",
                table: "persona",
                column: "nif",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_telefono",
                table: "persona",
                column: "telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_profesor_id_departamento",
                table: "profesor",
                column: "id_departamento");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_id_profesor",
                table: "profesor",
                column: "id_profesor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alumno_se_matricula_asignatura");

            migrationBuilder.DropTable(
                name: "AsignaturaCursoEscolar");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "curso_escolar");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "persona");
        }
    }
}
