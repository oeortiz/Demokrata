using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiDemokrataPerson.Migrations
{
    /// <inheritdoc />
    public partial class StartPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Sueldo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Apellido", "FechaActualizacion", "FechaCreacion", "FechaNacimiento", "Nombre", "SegundoApellido", "SegundoNombre", "Sueldo" },
                values: new object[,]
                {
                    { 1, "Perez", new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateOnly(1968, 10, 8), "Juan", "Ortega", "Manuel", 7500000 },
                    { 2, "Rincon", new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateOnly(1985, 9, 20), "Miguel", "Ruiz", "Angel", 3000000 },
                    { 3, "Sanchez", new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateOnly(1993, 5, 15), "Tatiana", "Maldonado", "Milena", 4000000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
