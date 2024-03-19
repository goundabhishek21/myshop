﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crudemvccore.Data.Migrations
{
    /// <inheritdoc />
    public partial class oddrrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Orders");
        }
    }
}
