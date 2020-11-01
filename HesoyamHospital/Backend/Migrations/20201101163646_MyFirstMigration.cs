using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TimeTable",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserID",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(nullable: true),
                    Locationid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Location_Locationid",
                        column: x => x.Locationid,
                        principalTable: "Location",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Uidn = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    HomePhone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    Email1 = table.Column<string>(nullable: true),
                    Email2 = table.Column<string>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    Sex = table.Column<int>(nullable: false),
                    UserIDid = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Hospitalid = table.Column<long>(nullable: true),
                    TimeTableid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Hospitals_Hospitalid",
                        column: x => x.Hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_TimeTable_TimeTableid",
                        column: x => x.TimeTableid,
                        principalTable: "TimeTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_UserID_UserIDid",
                        column: x => x.UserIDid,
                        principalTable: "UserID",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoomNumber = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    RoomType = table.Column<int>(nullable: false),
                    Hospitalid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.id);
                    table.ForeignKey(
                        name: "FK_Room_Hospitals_Hospitalid",
                        column: x => x.Hospitalid,
                        principalTable: "Hospitals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Locationid",
                table: "Address",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressId",
                table: "Employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Hospitalid",
                table: "Employee",
                column: "Hospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TimeTableid",
                table: "Employee",
                column: "TimeTableid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserIDid",
                table: "Employee",
                column: "UserIDid");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AddressId",
                table: "Hospitals",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Hospitalid",
                table: "Room",
                column: "Hospitalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "TimeTable");

            migrationBuilder.DropTable(
                name: "UserID");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
