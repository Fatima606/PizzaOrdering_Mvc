using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaOrdering_Mvc.Migrations
{
    public partial class field_added_in_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("e64fedda-395f-4818-9775-f34c5904bddb"));

            migrationBuilder.DeleteData(
                table: "Base",
                keyColumn: "baseId",
                keyValue: new Guid("f6a7fa18-9443-4efc-a971-fec92c73980d"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("96560410-465e-4e38-bb5e-11e2f1d82601"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("ba90dc5e-785c-4fe9-8974-c7cd568b0431"));

            migrationBuilder.DeleteData(
                table: "Size",
                keyColumn: "SizeId",
                keyValue: new Guid("e322a564-d000-44a1-a544-8e002e1d739f"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("1508dbfa-f1aa-447b-8f20-3ce74bb6f0ce"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("17c0bdd5-c6da-47c5-b622-741a292302b8"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("364f1bd3-476e-45ac-975f-e8b34da254fb"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("75e2b1b2-67dc-4f69-89f4-bb768c1b8071"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("b92b2655-8860-4865-8de5-60e622a761a1"));

            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: new Guid("de3cc5be-01ed-4ba2-84bf-db1b4f96edbd"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
