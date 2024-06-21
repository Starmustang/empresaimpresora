using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace empresaimpresora.Migrations
{
    /// <inheritdoc />
    public partial class pruebainicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_impresoras_Empresa_EmpresaId",
                table: "impresoras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa");

            migrationBuilder.RenameTable(
                name: "Empresa",
                newName: "Empresas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_impresoras_Empresas_EmpresaId",
                table: "impresoras",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_impresoras_Empresas_EmpresaId",
                table: "impresoras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empresas",
                table: "Empresas");

            migrationBuilder.RenameTable(
                name: "Empresas",
                newName: "Empresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empresa",
                table: "Empresa",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_impresoras_Empresa_EmpresaId",
                table: "impresoras",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "EmpresaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
