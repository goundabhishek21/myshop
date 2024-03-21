using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudemvccore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ordersupda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderproducts_Orders_OrderId",
                table: "orderproducts");

            migrationBuilder.DropForeignKey(
                name: "FK_orderproducts_Product_ProductId",
                table: "orderproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderproducts",
                table: "orderproducts");

            migrationBuilder.RenameTable(
                name: "orderproducts",
                newName: "Orderproducts");

            migrationBuilder.RenameIndex(
                name: "IX_orderproducts_ProductId",
                table: "Orderproducts",
                newName: "IX_Orderproducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_orderproducts_OrderId",
                table: "Orderproducts",
                newName: "IX_Orderproducts_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orderproducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderproducts",
                table: "Orderproducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderproducts_Orders_OrderId",
                table: "Orderproducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderproducts_Product_ProductId",
                table: "Orderproducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderproducts_Orders_OrderId",
                table: "Orderproducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderproducts_Product_ProductId",
                table: "Orderproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderproducts",
                table: "Orderproducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orderproducts");

            migrationBuilder.RenameTable(
                name: "Orderproducts",
                newName: "orderproducts");

            migrationBuilder.RenameIndex(
                name: "IX_Orderproducts_ProductId",
                table: "orderproducts",
                newName: "IX_orderproducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderproducts_OrderId",
                table: "orderproducts",
                newName: "IX_orderproducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderproducts",
                table: "orderproducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderproducts_Orders_OrderId",
                table: "orderproducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderproducts_Product_ProductId",
                table: "orderproducts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
