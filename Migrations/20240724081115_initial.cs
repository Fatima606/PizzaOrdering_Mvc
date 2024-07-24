using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrdering_Mvc.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Base",
                columns: table => new
                {
                    baseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Base", x => x.baseId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Base_BaseId",
                        column: x => x.BaseId,
                        principalTable: "Base",
                        principalColumn: "baseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaTopping",
                columns: table => new
                {
                    PizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaTopping", x => new { x.PizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaTopping_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Base",
                columns: new[] { "baseId", "BaseName" },
                values: new object[,]
                {
                    { new Guid("e64fedda-395f-4818-9775-f34c5904bddb"), "Thick" },
                    { new Guid("f6a7fa18-9443-4efc-a971-fec92c73980d"), "Thin" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "PizzaSize" },
                values: new object[,]
                {
                    { new Guid("96560410-465e-4e38-bb5e-11e2f1d82601"), "Small" },
                    { new Guid("ba90dc5e-785c-4fe9-8974-c7cd568b0431"), "Large" },
                    { new Guid("e322a564-d000-44a1-a544-8e002e1d739f"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "ToppingName" },
                values: new object[,]
                {
                    { new Guid("1508dbfa-f1aa-447b-8f20-3ce74bb6f0ce"), "Olives" },
                    { new Guid("17c0bdd5-c6da-47c5-b622-741a292302b8"), "Pepperoni" },
                    { new Guid("364f1bd3-476e-45ac-975f-e8b34da254fb"), "Chicken" },
                    { new Guid("75e2b1b2-67dc-4f69-89f4-bb768c1b8071"), "Extra Chaeese" },
                    { new Guid("b92b2655-8860-4865-8de5-60e622a761a1"), "Spinach" },
                    { new Guid("de3cc5be-01ed-4ba2-84bf-db1b4f96edbd"), "Mushroom" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PizzaId",
                table: "Order",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_BaseId",
                table: "Pizza",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaTopping_ToppingId",
                table: "PizzaTopping",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PizzaTopping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Base");

            migrationBuilder.DropTable(
                name: "Size");
        }
    }
}
