using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Address_AddressID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Hospitals_HospitalID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_TimeTable_TimeTableID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_UserID_UidId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UidId",
                table: "User",
                newName: "IX_User_UidId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_TimeTableID",
                table: "User",
                newName: "IX_User_TimeTableID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_HospitalID",
                table: "User",
                newName: "IX_User_HospitalID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AddressID",
                table: "User",
                newName: "IX_User_AddressID");

            migrationBuilder.AlterColumn<long>(
                name: "TimeTableID",
                table: "User",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "HospitalID",
                table: "User",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    Published = table.Column<bool>(nullable: false),
                    Anonymous = table.Column<bool>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Stars = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<long>(nullable: false),
                    RatingId = table.Column<long>(nullable: false),
                    FeedbackId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Feedbacks_FeedbackId",
                        column: x => x.FeedbackId,
                        principalTable: "Feedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswer_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_FeedbackId",
                table: "QuestionAnswer",
                column: "FeedbackId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_RatingId",
                table: "QuestionAnswer",
                column: "RatingId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_User_UidId",
                table: "Employee",
                newName: "IX_Employee_UidId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressID",
                table: "Employee",
                newName: "IX_Employee_AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_User_TimeTableID",
                table: "Employee",
                newName: "IX_Employee_TimeTableID");

            migrationBuilder.RenameIndex(
                name: "IX_User_HospitalID",
                table: "Employee",
                newName: "IX_Employee_HospitalID");

            migrationBuilder.AlterColumn<long>(
                name: "TimeTableID",
                table: "Employee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "HospitalID",
                table: "Employee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Address_AddressID",
                table: "Employee",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Hospitals_HospitalID",
                table: "Employee",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_TimeTable_TimeTableID",
                table: "Employee",
                column: "TimeTableID",
                principalTable: "TimeTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_UserID_UidId",
                table: "Employee",
                column: "UidId",
                principalTable: "UserID",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
