using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("00a2eb6d-b1f2-4bc3-b7ad-807f4c42e3b6"), "Curso de Unit Test para Net Core", new DateTime(2022, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4884), new DateTime(2024, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4886), 1000m, "Master en Unit Test con CQRS" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("2bf2a8ed-372a-4548-8a1e-4b017e6ad52b"), "Curso de Java", new DateTime(2022, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4839), new DateTime(2024, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4842), 25m, "Master en Java Spring desde las raices" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("f687de77-8ee2-4d02-9fab-25557731ccc6"), "Curso C# básico", new DateTime(2022, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4734), new DateTime(2024, 5, 22, 21, 17, 33, 633, DateTimeKind.Local).AddTicks(4760), 56m, "C# desde cero hasta avanzado" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
