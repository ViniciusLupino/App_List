using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AppTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoriaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaCor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "tbStatus",
                columns: table => new
                {
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "tbTarefa",
                columns: table => new
                {
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarefaNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTarefa", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_tbTarefa_tbCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "tbCategoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbTarefa_tbStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "tbStatus",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbTarefa_CategoriaId",
                table: "tbTarefa",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTarefa_StatusId",
                table: "tbTarefa",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbTarefa");

            migrationBuilder.DropTable(
                name: "tbCategoria");

            migrationBuilder.DropTable(
                name: "tbStatus");
        }
    }
}
