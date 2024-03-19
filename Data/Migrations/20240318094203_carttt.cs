using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudemvccore.Data.Migrations
{
    /// <inheritdoc />
    public partial class carttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId1",
                table: "AddTOCart");

            migrationBuilder.DropForeignKey(
                name: "FK_AddTOCart_Product_ProductId",
                table: "AddTOCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddTOCart",
                table: "AddTOCart");

            migrationBuilder.RenameTable(
                name: "AddTOCart",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_AddTOCart_UserId1",
                table: "Carts",
                newName: "IX_Carts_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AddTOCart_ProductId",
                table: "Carts",
                newName: "IX_Carts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "AddTOCart");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId1",
                table: "AddTOCart",
                newName: "IX_AddTOCart_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ProductId",
                table: "AddTOCart",
                newName: "IX_AddTOCart_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddTOCart",
                table: "AddTOCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddTOCart_AspNetUsers_UserId1",
                table: "AddTOCart",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddTOCart_Product_ProductId",
                table: "AddTOCart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
