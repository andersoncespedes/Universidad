using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "curso_escolar",
                newName: "Id");

            migrationBuilder.AlterColumn<short>(
                name: "anyo_inicio",
                table: "curso_escolar",
                type: "year",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<short>(
                name: "anyo_fin",
                table: "curso_escolar",
                type: "year",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "curso_escolar",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "anyo_inicio",
                table: "curso_escolar",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "year");

            migrationBuilder.AlterColumn<DateTime>(
                name: "anyo_fin",
                table: "curso_escolar",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "year");
        }
    }
}
