using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace empresaimpresora.Migrations
{
    /// <inheritdoc />
    public partial class inyecciondependencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "EmpresaId", "Descripcion", "Empleados", "Nombre" },
                values: new object[,]
                {
                    { new Guid("f83bc361-e443-47f7-89ec-556241277234"), "Empresa desarrolladora de software", 1, "WIlsoncorp" },
                    { new Guid("f83bc361-e443-47f7-89ec-556241277235"), "Empresa desarrolladora de seguridad", 8, "Jdp" }
                });

            migrationBuilder.InsertData(
                table: "impresoras",
                columns: new[] { "ImpresoraId", "EmpresaId", "Modelo", "Nombre" },
                values: new object[] { new Guid("f83bc361-e443-47f7-89ec-556241277236"), new Guid("f83bc361-e443-47f7-89ec-556241277235"), "ltt3", "Epson" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277234"));

            migrationBuilder.DeleteData(
                table: "impresoras",
                keyColumn: "ImpresoraId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277236"));

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "EmpresaId",
                keyValue: new Guid("f83bc361-e443-47f7-89ec-556241277235"));
        }
    }
}
