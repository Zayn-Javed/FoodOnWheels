using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOnWheels.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_foodItems_ItemName",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "Orders",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ItemName",
                table: "Orders",
                newName: "IX_Orders_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_foodItems_ItemId",
                table: "Orders",
                column: "ItemId",
                principalTable: "foodItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_foodItems_ItemId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Orders",
                newName: "ItemName");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                newName: "IX_Orders_ItemName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_foodItems_ItemName",
                table: "Orders",
                column: "ItemName",
                principalTable: "foodItems",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
