using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class modifiedListModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Members_FK_MemberID",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_FK_MemberID",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "FK_MemberID",
                table: "Lists");

            migrationBuilder.AddColumn<int>(
                name: "FK_MemberID",
                table: "Interests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_FK_MemberID",
                table: "Interests",
                column: "FK_MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_Members_FK_MemberID",
                table: "Interests",
                column: "FK_MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_Members_FK_MemberID",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_FK_MemberID",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "FK_MemberID",
                table: "Interests");

            migrationBuilder.AddColumn<int>(
                name: "FK_MemberID",
                table: "Lists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lists_FK_MemberID",
                table: "Lists",
                column: "FK_MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Members_FK_MemberID",
                table: "Lists",
                column: "FK_MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
