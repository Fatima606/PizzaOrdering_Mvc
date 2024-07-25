using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrdering_Mvc.Migrations
{
    public partial class field_removed_in_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("35232165-19b5-41c3-a904-0ec72be37c88"));

            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("c153bc56-c45d-4eeb-a4cf-ad34a75cd7d0"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("89b392ec-2007-4187-bd1e-b63c6f8d8cfe"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("9c85e049-b0ac-4fad-97a7-fdfda3ac1781"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("e78de39d-7f5a-4ba4-90c2-63f2eb9fc9e5"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("0a421f62-bd57-4eed-9118-8206a6b67283"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("40e8d015-76f2-4431-ba65-4db323a36001"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("5a665776-d01b-437c-9a70-9f7dc12df558"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("6f547df3-b2a7-41a4-9ef5-9efc02c9fe31"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("af84bf79-9d2b-45ca-8b0e-f0f726e483f8"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("dbeb07ad-455a-4fff-a116-cf6df1c1e1bd"));

            migrationBuilder.DropColumn(
                name: "no_times_ordered",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Base",
                columns: new[] { "baseId", "BaseName" },
                values: new object[,]
                {
                    { new Guid("4c97f9e8-30c2-4ef3-b152-9600438300c2"), "Thin" },
                    { new Guid("cfe0ec73-0c8a-4653-932b-4189622281a4"), "Thick" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "PizzaSize" },
                values: new object[,]
                {
                    { new Guid("64012bcd-d71a-45f3-aab0-72d1ca386d77"), "Small" },
                    { new Guid("e75924ba-0967-4b2c-87c7-991b56c65f69"), "Large" },
                    { new Guid("eb7151bf-1c5d-4c52-b34e-023a52ab9b6f"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "ToppingName" },
                values: new object[,]
                {
                    { new Guid("22b16462-0a68-42dc-bf52-b6c0f1dfd0ae"), "Mushroom" },
                    { new Guid("5fa3366f-c816-4c89-85a7-cfde8b1047cb"), "Chicken" },
                    { new Guid("692df90b-65b0-4a0b-8249-c1eff6c11e76"), "Spinach" },
                    { new Guid("c96e7ccd-f2ed-4551-9adf-b450f9edd276"), "Extra Chaeese" },
                    { new Guid("d46eb57f-c9ea-4b49-ab28-c1116974c985"), "Olives" },
                    { new Guid("f46673ab-4bbd-4151-9d79-6735416897f5"), "Pepperoni" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("4c97f9e8-30c2-4ef3-b152-9600438300c2"));

            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("cfe0ec73-0c8a-4653-932b-4189622281a4"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("64012bcd-d71a-45f3-aab0-72d1ca386d77"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("e75924ba-0967-4b2c-87c7-991b56c65f69"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("eb7151bf-1c5d-4c52-b34e-023a52ab9b6f"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("22b16462-0a68-42dc-bf52-b6c0f1dfd0ae"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("5fa3366f-c816-4c89-85a7-cfde8b1047cb"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("692df90b-65b0-4a0b-8249-c1eff6c11e76"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("c96e7ccd-f2ed-4551-9adf-b450f9edd276"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("d46eb57f-c9ea-4b49-ab28-c1116974c985"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("f46673ab-4bbd-4151-9d79-6735416897f5"));

            migrationBuilder.AddColumn<int>(
                name: "no_times_ordered",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Base",
                columns: new[] { "baseId", "BaseName" },
                values: new object[,]
                {
                    { new Guid("35232165-19b5-41c3-a904-0ec72be37c88"), "Thin" },
                    { new Guid("c153bc56-c45d-4eeb-a4cf-ad34a75cd7d0"), "Thick" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "PizzaSize" },
                values: new object[,]
                {
                    { new Guid("89b392ec-2007-4187-bd1e-b63c6f8d8cfe"), "Large" },
                    { new Guid("9c85e049-b0ac-4fad-97a7-fdfda3ac1781"), "Small" },
                    { new Guid("e78de39d-7f5a-4ba4-90c2-63f2eb9fc9e5"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "ToppingName" },
                values: new object[,]
                {
                    { new Guid("0a421f62-bd57-4eed-9118-8206a6b67283"), "Chicken" },
                    { new Guid("40e8d015-76f2-4431-ba65-4db323a36001"), "Spinach" },
                    { new Guid("5a665776-d01b-437c-9a70-9f7dc12df558"), "Extra Chaeese" },
                    { new Guid("6f547df3-b2a7-41a4-9ef5-9efc02c9fe31"), "Pepperoni" },
                    { new Guid("af84bf79-9d2b-45ca-8b0e-f0f726e483f8"), "Olives" },
                    { new Guid("dbeb07ad-455a-4fff-a116-cf6df1c1e1bd"), "Mushroom" }
                });
        }
    }
}
