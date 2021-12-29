using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeNascimento", "DataFim", "DataIni", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(3512), 0, "Marta", "Kent", "33225555" },
                    { 2, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5112), 0, "Paula", "Isabela", "3354128" },
                    { 3, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5170), 0, "Laura", "Antonia", "55668899" },
                    { 4, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5175), 0, "Luiza", "Maria", "6565659" },
                    { 5, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5179), 0, "Lucas", "Machado", "565685415" },
                    { 6, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5185), 0, "Pedro", "Alvares", "456454545" },
                    { 7, true, new DateTime(2005, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(5189), 0, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 12, 29, 10, 12, 48, 111, DateTimeKind.Local).AddTicks(4648), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2021, 12, 29, 10, 12, 48, 112, DateTimeKind.Local).AddTicks(2515), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2021, 12, 29, 10, 12, 48, 112, DateTimeKind.Local).AddTicks(2554), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2021, 12, 29, 10, 12, 48, 112, DateTimeKind.Local).AddTicks(2556), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2021, 12, 29, 10, 12, 48, 112, DateTimeKind.Local).AddTicks(2557), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6740), null },
                    { 4, 5, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6752), null },
                    { 2, 5, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6744), null },
                    { 1, 5, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6739), null },
                    { 7, 4, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6764), null },
                    { 6, 4, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6760), null },
                    { 5, 4, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6753), null },
                    { 4, 4, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6751), null },
                    { 1, 4, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6722), null },
                    { 7, 3, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6763), null },
                    { 5, 5, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6754), null },
                    { 6, 3, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6757), null },
                    { 7, 2, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6762), null },
                    { 6, 2, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6756), null },
                    { 3, 2, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6746), null },
                    { 2, 2, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6741), null },
                    { 1, 2, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6246), null },
                    { 7, 1, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6761), null },
                    { 6, 1, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6755), null },
                    { 4, 1, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6750), null },
                    { 3, 1, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6745), null },
                    { 3, 3, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6748), null },
                    { 7, 5, null, new DateTime(2021, 12, 29, 10, 12, 48, 114, DateTimeKind.Local).AddTicks(6765), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCursos_CursoId",
                table: "AlunoCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoCursos");

            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
