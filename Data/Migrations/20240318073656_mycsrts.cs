using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudemvccore.Data.Migrations
{
    /// <inheritdoc />
    public partial class mycsrts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId",
                table: "AddTOCart");

            migrationBuilder.DropIndex(
                name: "IX_AddTOCart_UserId",
                table: "AddTOCart");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AddTOCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "AddTOCart",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddTOCart_UserId1",
                table: "AddTOCart",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId1",
                table: "AddTOCart",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId1",
                table: "AddTOCart");

            migrationBuilder.DropIndex(
                name: "IX_AddTOCart_UserId1",
                table: "AddTOCart");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AddTOCart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AddTOCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AddTOCart_UserId",
                table: "AddTOCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId",
                table: "AddTOCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
