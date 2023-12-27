using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightDocsSystem.Migrations
{
    public partial class DBInit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_User_UserID",
                table: "Flight");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Flight",
                newName: "UserCreateID");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_UserID",
                table: "Flight",
                newName: "IX_Flight_UserCreateID");

            migrationBuilder.AddColumn<int>(
                name: "UserUpdateID",
                table: "Document",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserUpdateID",
                table: "Document",
                column: "UserUpdateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_User_UserUpdateID",
                table: "Document",
                column: "UserUpdateID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_User_UserCreateID",
                table: "Flight",
                column: "UserCreateID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_User_UserUpdateID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_User_UserCreateID",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Document_UserUpdateID",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "UserUpdateID",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "UserCreateID",
                table: "Flight",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_UserCreateID",
                table: "Flight",
                newName: "IX_Flight_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_User_UserID",
                table: "Flight",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
