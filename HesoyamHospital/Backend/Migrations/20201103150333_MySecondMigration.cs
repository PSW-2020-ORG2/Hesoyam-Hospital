using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Location_Locationid",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Address_AddressId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Hospitals_Hospitalid",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_TimeTable_TimeTableid",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_UserID_UserIDid",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Address_AddressId",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hospitals_Hospitalid",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UserIDid",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserIDid",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserID",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TimeTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Hospitalid",
                table: "Room",
                newName: "HospitalId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Room",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Room_Hospitalid",
                table: "Room",
                newName: "IX_Room_HospitalId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Location",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Hospitals",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Hospitals",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Hospitals_AddressId",
                table: "Hospitals",
                newName: "IX_Hospitals_AddressID");

            migrationBuilder.RenameColumn(
                name: "Locationid",
                table: "Address",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_Locationid",
                table: "Address",
                newName: "IX_Address_LocationID");

            migrationBuilder.RenameColumn(
                name: "TimeTableid",
                table: "Users",
                newName: "TimeTableID");

            migrationBuilder.RenameColumn(
                name: "Hospitalid",
                table: "Users",
                newName: "HospitalID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Users",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_TimeTableid",
                table: "Users",
                newName: "IX_Users_TimeTableID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Hospitalid",
                table: "Users",
                newName: "IX_Users_HospitalID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AddressId",
                table: "Users",
                newName: "IX_Users_AddressID");

            migrationBuilder.AlterColumn<long>(
                name: "AddressID",
                table: "Hospitals",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LocationID",
                table: "Address",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddressID",
                table: "Users",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<long>(
                name: "UidId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UidId",
                table: "Users",
                column: "UidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Location_LocationID",
                table: "Address",
                column: "LocationID",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Address_AddressID",
                table: "Hospitals",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hospitals_HospitalId",
                table: "Room",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Address_Location_LocationID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Address_AddressID",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Hospitals_HospitalId",
                table: "Room");

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

            migrationBuilder.DropIndex(
                name: "IX_Users_UidId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UidId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserID",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TimeTable",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Room",
                newName: "Hospitalid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Room_HospitalId",
                table: "Room",
                newName: "IX_Room_Hospitalid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Hospitals",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hospitals",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Hospitals_AddressID",
                table: "Hospitals",
                newName: "IX_Hospitals_AddressId");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Address",
                newName: "Locationid");

            migrationBuilder.RenameIndex(
                name: "IX_Address_LocationID",
                table: "Address",
                newName: "IX_Address_Locationid");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Employee",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TimeTableID",
                table: "Employee",
                newName: "TimeTableid");

            migrationBuilder.RenameColumn(
                name: "HospitalID",
                table: "Employee",
                newName: "Hospitalid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_AddressID",
                table: "Employee",
                newName: "IX_Employee_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TimeTableID",
                table: "Employee",
                newName: "IX_Employee_TimeTableid");

            migrationBuilder.RenameIndex(
                name: "IX_Users_HospitalID",
                table: "Employee",
                newName: "IX_Employee_Hospitalid");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Hospitals",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Locationid",
                table: "Address",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UserIDid",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserIDid",
                table: "Employee",
                column: "UserIDid");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Location_Locationid",
                table: "Address",
                column: "Locationid",
                principalTable: "Location",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Address_AddressId",
                table: "Employee",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Hospitals_Hospitalid",
                table: "Employee",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_TimeTable_TimeTableid",
                table: "Employee",
                column: "TimeTableid",
                principalTable: "TimeTable",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_UserID_UserIDid",
                table: "Employee",
                column: "UserIDid",
                principalTable: "UserID",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Address_AddressId",
                table: "Hospitals",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Hospitals_Hospitalid",
                table: "Room",
                column: "Hospitalid",
                principalTable: "Hospitals",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
