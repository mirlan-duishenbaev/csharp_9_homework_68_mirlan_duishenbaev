using Microsoft.EntityFrameworkCore.Migrations;

namespace HeadHunter.Migrations
{
    public partial class ChangedEntityVacancyAndAddedEntityResponseWithContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_AspNetUsers_UserId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Vacancies_VacancyId",
                table: "Response");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "Responses");

            migrationBuilder.RenameIndex(
                name: "IX_Response_VacancyId",
                table: "Responses",
                newName: "IX_Responses_VacancyId");

            migrationBuilder.RenameIndex(
                name: "IX_Response_UserId",
                table: "Responses",
                newName: "IX_Responses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Vacancies_VacancyId",
                table: "Responses",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Vacancies_VacancyId",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "Response");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_VacancyId",
                table: "Response",
                newName: "IX_Response_VacancyId");

            migrationBuilder.RenameIndex(
                name: "IX_Responses_UserId",
                table: "Response",
                newName: "IX_Response_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_AspNetUsers_UserId",
                table: "Response",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Vacancies_VacancyId",
                table: "Response",
                column: "VacancyId",
                principalTable: "Vacancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
