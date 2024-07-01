using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOnWheels.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eamil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Man",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Man", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "rid",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rid", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "subMenus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subMenus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_subMenus_Man_ManagerUserName",
                        column: x => x.ManagerUserName,
                        principalTable: "Man",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateTable(
                name: "foodItems",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    SubMenuMenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_foodItems", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_foodItems_subMenus_SubMenuMenuId",
                        column: x => x.SubMenuMenuId,
                        principalTable: "subMenus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<int>(type: "int", nullable: false),
                    CustomerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ManagerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_customer_CustomerUserName",
                        column: x => x.CustomerUserName,
                        principalTable: "customer",
                        principalColumn: "UserName");
                    table.ForeignKey(
                        name: "FK_Orders_foodItems_ItemName",
                        column: x => x.ItemName,
                        principalTable: "foodItems",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Man_ManagerUserName",
                        column: x => x.ManagerUserName,
                        principalTable: "Man",
                        principalColumn: "UserName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_foodItems_SubMenuMenuId",
                table: "foodItems",
                column: "SubMenuMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserName",
                table: "Orders",
                column: "CustomerUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemName",
                table: "Orders",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ManagerUserName",
                table: "Orders",
                column: "ManagerUserName");

            migrationBuilder.CreateIndex(
                name: "IX_subMenus_ManagerUserName",
                table: "subMenus",
                column: "ManagerUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "rid");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "foodItems");

            migrationBuilder.DropTable(
                name: "subMenus");

            migrationBuilder.DropTable(
                name: "Man");
        }
    }
}
