using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profesor_departamento_id_departamento",
                table: "profesor");

            migrationBuilder.AlterColumn<int>(
                name: "id_departamento",
                table: "profesor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_profesor_departamento_id_departamento",
                table: "profesor",
                column: "id_departamento",
                principalTable: "departamento",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profesor_departamento_id_departamento",
                table: "profesor");

            migrationBuilder.AlterColumn<int>(
                name: "id_departamento",
                table: "profesor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profesor_departamento_id_departamento",
                table: "profesor",
                column: "id_departamento",
                principalTable: "departamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
