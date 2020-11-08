using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_User_UserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Hospitals_HospitalID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_TimeTable_TimeTableID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressID",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserID_UidId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_UidId",
                table: "Users",
                newName: "IX_Users_UidId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressID",
                table: "Users",
                newName: "IX_Users_AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_User_TimeTableID",
                table: "Users",
                newName: "IX_Users_TimeTableID");

            migrationBuilder.RenameIndex(
                name: "IX_User_HospitalID",
                table: "Users",
                newName: "IX_Users_HospitalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Hospitals_HospitalID",
                table: "Users",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TimeTable_TimeTableID",
                table: "Users",
                column: "TimeTableID",
                principalTable: "TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_AddressID",
                table: "Users",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserID_UidId",
                table: "Users",
                column: "UidId",
                principalTable: "UserID",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Users_UserId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Hospitals_HospitalID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TimeTable_TimeTableID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserID_UidId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UidId",
                table: "User",
                newName: "IX_User_UidId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressID",
                table: "User",
                newName: "IX_User_AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TimeTableID",
                table: "User",
                newName: "IX_User_TimeTableID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_HospitalID",
                table: "User",
                newName: "IX_User_HospitalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_User_UserId",
                table: "Feedbacks",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Hospitals_HospitalID",
                table: "User",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_TimeTable_TimeTableID",
                table: "User",
                column: "TimeTableID",
                principalTable: "TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressID",
                table: "User",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserID_UidId",
                table: "User",
                column: "UidId",
                principalTable: "UserID",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
