using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOnWheels.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RiderUserName",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RiderUserName",
                table: "Orders",
                column: "RiderUserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_rid_RiderUserName",
                table: "Orders",
                column: "RiderUserName",
                principalTable: "rid",
                principalColumn: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_rid_RiderUserName",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RiderUserName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RiderUserName",
                table: "Orders");
        }
    }
}
