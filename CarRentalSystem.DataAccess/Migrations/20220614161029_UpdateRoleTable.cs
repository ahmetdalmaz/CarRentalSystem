using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalSystem.DataAccess.Migrations
{
    public partial class UpdateRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserOperationClaim");

            migrationBuilder.DropTable(
                name: "OperationClaim");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Cars",
                type: "varchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kilometre",
                table: "Cars",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    RoleClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "RoleClaimId", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "car.view", 1 },
                    { 2, "car.add", 1 },
                    { 3, "car.update", 1 },
                    { 4, "car.delete", 1 },
                    { 5, "rental.view", 1 },
                    { 6, "roles.view", 1 },
                    { 7, "roles.add", 1 },
                    { 8, "roles.update", 1 },
                    { 9, "roles.delete", 1 },
                    { 10, "carsettings.view", 1 },
                    { 11, "carsettings.add", 1 },
                    { 12, "carsettings.update", 1 },
                    { 13, "carsettings.delete", 1 },
                    { 14, "customer.view", 1 },
                    { 15, "customer.add", 1 },
                    { 16, "customer.update", 1 },
                    { 17, "customer.delete", 1 },
                    { 18, "user.view", 1 },
                    { 19, "user.add", 1 },
                    { 20, "user.update", 1 },
                    { 21, "user.delete", 1 },
                    { 22, "statistic.view", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "Cars",
                type: "char(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Kilometre",
                table: "Cars",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "OperationClaim",
                columns: table => new
                {
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaim", x => x.OperationClaimId);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaim",
                columns: table => new
                {
                    UserOperationClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaim", x => x.UserOperationClaimId);
                    table.ForeignKey(
                        name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaim",
                        principalColumn: "OperationClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaim_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaim",
                columns: new[] { "OperationClaimId", "Name", "State" },
                values: new object[] { 1, "admin", false });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_UserId",
                table: "UserOperationClaim",
                column: "UserId");
        }
    }
}
