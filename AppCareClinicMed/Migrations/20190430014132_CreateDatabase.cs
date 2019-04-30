using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCareClinicMed.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONVENIO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONVENIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESPECIALIDADE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FORMA_PAGAMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMA_PAGAMENTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAIS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pais = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_CONSULTA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_CONSULTA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usuario = table.Column<string>(maxLength: 20, nullable: true),
                    senha = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Crm = table.Column<string>(maxLength: 20, nullable: true),
                    ESPECIALIDADEId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEDICO_ESPECIALIDADE_ESPECIALIDADEId",
                        column: x => x.ESPECIALIDADEId,
                        principalTable: "ESPECIALIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLINICA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Razao_social = table.Column<string>(maxLength: 50, nullable: true),
                    Nome_fantasia = table.Column<string>(maxLength: 50, nullable: true),
                    Cnpj = table.Column<string>(maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(maxLength: 50, nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    ESTADOSId = table.Column<int>(nullable: false),
                    PAISId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLINICA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CLINICA_ESTADOS_ESTADOSId",
                        column: x => x.ESTADOSId,
                        principalTable: "ESTADOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CLINICA_PAIS_PAISId",
                        column: x => x.PAISId,
                        principalTable: "PAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: true),
                    Data_nascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(maxLength: 20, nullable: true),
                    Estado_civil = table.Column<string>(maxLength: 20, nullable: true),
                    Endereco = table.Column<string>(maxLength: 50, nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    ESTADOSId = table.Column<int>(nullable: false),
                    PAISId = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(maxLength: 15, nullable: true),
                    Rg = table.Column<string>(maxLength: 20, nullable: true),
                    CONVENIOId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PACIENTE_CONVENIO_CONVENIOId",
                        column: x => x.CONVENIOId,
                        principalTable: "CONVENIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PACIENTE_ESTADOS_ESTADOSId",
                        column: x => x.ESTADOSId,
                        principalTable: "ESTADOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PACIENTE_PAIS_PAISId",
                        column: x => x.PAISId,
                        principalTable: "PAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENDAMENTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    retorno = table.Column<string>(maxLength: 5, nullable: true),
                    Data_agendamento = table.Column<DateTime>(nullable: false),
                    PACIENTEId = table.Column<int>(nullable: false),
                    MEDICOId = table.Column<int>(nullable: false),
                    TIPO_CONSULTAId = table.Column<int>(nullable: false),
                    CONVENIOId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAMENTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_CONVENIO_CONVENIOId",
                        column: x => x.CONVENIOId,
                        principalTable: "CONVENIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_MEDICO_MEDICOId",
                        column: x => x.MEDICOId,
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_PACIENTE_PACIENTEId",
                        column: x => x.PACIENTEId,
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AGENDAMENTO_TIPO_CONSULTA_TIPO_CONSULTAId",
                        column: x => x.TIPO_CONSULTAId,
                        principalTable: "TIPO_CONSULTA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HISTORICO_PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Historico = table.Column<string>(maxLength: 2000, nullable: true),
                    Data_historico = table.Column<DateTime>(nullable: false),
                    PACIENTEId = table.Column<int>(nullable: false),
                    MEDICOId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HISTORICO_PACIENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HISTORICO_PACIENTE_MEDICO_MEDICOId",
                        column: x => x.MEDICOId,
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HISTORICO_PACIENTE_PACIENTE_PACIENTEId",
                        column: x => x.PACIENTEId,
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_CONVENIOId",
                table: "AGENDAMENTO",
                column: "CONVENIOId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_MEDICOId",
                table: "AGENDAMENTO",
                column: "MEDICOId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_PACIENTEId",
                table: "AGENDAMENTO",
                column: "PACIENTEId");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_TIPO_CONSULTAId",
                table: "AGENDAMENTO",
                column: "TIPO_CONSULTAId");

            migrationBuilder.CreateIndex(
                name: "IX_CLINICA_ESTADOSId",
                table: "CLINICA",
                column: "ESTADOSId");

            migrationBuilder.CreateIndex(
                name: "IX_CLINICA_PAISId",
                table: "CLINICA",
                column: "PAISId");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_PACIENTE_MEDICOId",
                table: "HISTORICO_PACIENTE",
                column: "MEDICOId");

            migrationBuilder.CreateIndex(
                name: "IX_HISTORICO_PACIENTE_PACIENTEId",
                table: "HISTORICO_PACIENTE",
                column: "PACIENTEId");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICO_ESPECIALIDADEId",
                table: "MEDICO",
                column: "ESPECIALIDADEId");

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTE_CONVENIOId",
                table: "PACIENTE",
                column: "CONVENIOId");

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTE_ESTADOSId",
                table: "PACIENTE",
                column: "ESTADOSId");

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTE_PAISId",
                table: "PACIENTE",
                column: "PAISId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDAMENTO");

            migrationBuilder.DropTable(
                name: "CLINICA");

            migrationBuilder.DropTable(
                name: "FORMA_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "HISTORICO_PACIENTE");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "TIPO_CONSULTA");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "PACIENTE");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADE");

            migrationBuilder.DropTable(
                name: "CONVENIO");

            migrationBuilder.DropTable(
                name: "ESTADOS");

            migrationBuilder.DropTable(
                name: "PAIS");
        }
    }
}
