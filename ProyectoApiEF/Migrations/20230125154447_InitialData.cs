using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoApiEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "peso",
                table: "Categoria",
                newName: "Peso");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("e2a2a013-09ce-4446-bfc1-3aacab502702"), null, "Actividades personales", 50 },
                    { new Guid("e2a2a013-09ce-4446-bfc1-3aacab502763"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("e2a2a013-09ce-4446-bfc1-3aacab502710"), new Guid("e2a2a013-09ce-4446-bfc1-3aacab502763"), null, new DateTime(2023, 1, 25, 9, 44, 47, 517, DateTimeKind.Local).AddTicks(308), 1, "Pago de servicios publicos" },
                    { new Guid("e2a2a013-09ce-4446-bfc1-3aacab502720"), new Guid("e2a2a013-09ce-4446-bfc1-3aacab502702"), null, new DateTime(2023, 1, 25, 9, 44, 47, 517, DateTimeKind.Local).AddTicks(378), 0, "Terminar de ver serie The Last Of Us" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502710"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502720"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502702"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502763"));

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Categoria",
                newName: "peso");

            migrationBuilder.AlterColumn<Guid>(
                name: "Descripcion",
                table: "Tarea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
