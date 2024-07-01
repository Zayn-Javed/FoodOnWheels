using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOnWheels.Migrations
{
    public partial class reviewquantityInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_customer_CustomerUserName",
                        column: x => x.CustomerUserName,
                        principalTable: "customer",
                        principalColumn: "UserName");
                    table.ForeignKey(
                        name: "FK_Review_Man_ManagerUserName",
                        column: x => x.ManagerUserName,
                        principalTable: "Man",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CustomerUserName",
                table: "Review",
                column: "CustomerUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ManagerUserName",
                table: "Review",
                column: "ManagerUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");
        }
    }
}
