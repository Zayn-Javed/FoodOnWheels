﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOnWheels.Migrations
{
    public partial class bill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Bill",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bill",
                table: "Orders");
        }
    }
}
