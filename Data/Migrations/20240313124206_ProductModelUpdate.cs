﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudemvccore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
