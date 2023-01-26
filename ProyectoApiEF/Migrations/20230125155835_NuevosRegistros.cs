using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoApiEF.Migrations
{
    /// <inheritdoc />
    public partial class NuevosRegistros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("a91aee3b-2de8-4020-a99c-682aea2515d7"), null, "Actividades laborales", 100 });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502710"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 25, 9, 58, 35, 706, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502720"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 25, 9, 58, 35, 706, DateTimeKind.Local).AddTicks(8803));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("5af3b1d4-5fc1-4445-87f3-2dbe112d0286"), new Guid("a91aee3b-2de8-4020-a99c-682aea2515d7"), null, new DateTime(2023, 1, 25, 9, 58, 35, 706, DateTimeKind.Local).AddTicks(8806), 2, "Realizar examen de certificacion" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("5af3b1d4-5fc1-4445-87f3-2dbe112d0286"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a91aee3b-2de8-4020-a99c-682aea2515d7"));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502710"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 25, 9, 44, 47, 517, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("e2a2a013-09ce-4446-bfc1-3aacab502720"),
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 25, 9, 44, 47, 517, DateTimeKind.Local).AddTicks(378));
        }
    }
}
