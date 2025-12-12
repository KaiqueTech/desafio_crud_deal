using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CursosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    CargaHoraria = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AlunoId = table.Column<int>(type: "integer", nullable: false),
                    CursoId = table.Column<int>(type: "integer", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Matricula_tbl_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "tbl_Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Matricula_tbl_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "tbl_Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Aluno_Email",
                table: "tbl_Aluno",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Matricula_AlunoId",
                table: "tbl_Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Matricula_CursoId",
                table: "tbl_Matricula",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Matricula");

            migrationBuilder.DropTable(
                name: "tbl_Aluno");

            migrationBuilder.DropTable(
                name: "tbl_Curso");
        }
    }
}
