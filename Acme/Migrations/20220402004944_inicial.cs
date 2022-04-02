using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(500)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.EncuestaId);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaDetalles",
                columns: table => new
                {
                    EncuestaDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    NombreCampo = table.Column<string>(type: "varchar(200)", nullable: true),
                    TituloCampo = table.Column<string>(type: "varchar(200)", nullable: true),
                    Requerido = table.Column<string>(type: "varchar(1)", nullable: true),
                    TipoCampo = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaDetalles", x => x.EncuestaDetalleId);
                    table.ForeignKey(
                        name: "FK_EncuestaDetalles_Encuestas_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuestas",
                        principalColumn: "EncuestaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaRepuestas",
                columns: table => new
                {
                    EncuestaRespuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRepuestas", x => x.EncuestaRespuestaId);
                    table.ForeignKey(
                        name: "FK_EncuestaRepuestas_Encuestas_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuestas",
                        principalColumn: "EncuestaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaRespuestaDetalles",
                columns: table => new
                {
                    EncuestaRespuestaDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampoId = table.Column<int>(type: "int", nullable: false),
                    Respuesta = table.Column<string>(type: "varchar(500)", nullable: true),
                    EncuestaRepuestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRespuestaDetalles", x => x.EncuestaRespuestaDetalleId);
                    table.ForeignKey(
                        name: "FK_EncuestaRespuestaDetalles_EncuestaDetalles_CampoId",
                        column: x => x.CampoId,
                        principalTable: "EncuestaDetalles",
                        principalColumn: "EncuestaDetalleId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EncuestaRespuestaDetalles_EncuestaRepuestas_EncuestaRepuestaId",
                        column: x => x.EncuestaRepuestaId,
                        principalTable: "EncuestaRepuestas",
                        principalColumn: "EncuestaRespuestaId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDetalles_EncuestaId",
                table: "EncuestaDetalles",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRepuestas_EncuestaId",
                table: "EncuestaRepuestas",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespuestaDetalles_CampoId",
                table: "EncuestaRespuestaDetalles",
                column: "CampoId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespuestaDetalles_EncuestaRepuestaId",
                table: "EncuestaRespuestaDetalles",
                column: "EncuestaRepuestaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncuestaRespuestaDetalles");

            migrationBuilder.DropTable(
                name: "EncuestaDetalles");

            migrationBuilder.DropTable(
                name: "EncuestaRepuestas");

            migrationBuilder.DropTable(
                name: "Encuestas");
        }
    }
}
