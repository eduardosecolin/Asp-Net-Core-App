using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCareClinicMed.Migrations
{
    public partial class payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FORMA_PAGAMENTOId",
                table: "AGENDAMENTO",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAMENTO_FORMA_PAGAMENTOId",
                table: "AGENDAMENTO",
                column: "FORMA_PAGAMENTOId");

            migrationBuilder.AddForeignKey(
                name: "FK_AGENDAMENTO_FORMA_PAGAMENTO_FORMA_PAGAMENTOId",
                table: "AGENDAMENTO",
                column: "FORMA_PAGAMENTOId",
                principalTable: "FORMA_PAGAMENTO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AGENDAMENTO_FORMA_PAGAMENTO_FORMA_PAGAMENTOId",
                table: "AGENDAMENTO");

            migrationBuilder.DropIndex(
                name: "IX_AGENDAMENTO_FORMA_PAGAMENTOId",
                table: "AGENDAMENTO");

            migrationBuilder.DropColumn(
                name: "FORMA_PAGAMENTOId",
                table: "AGENDAMENTO");
        }
    }
}
