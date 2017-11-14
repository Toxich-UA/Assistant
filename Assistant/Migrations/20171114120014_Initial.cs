using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assistant.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    firstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    lastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    format = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    productCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    fullName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    price = table.Column<float>(type: "float", nullable: true),
                    retailPrice = table.Column<float>(type: "float", nullable: true),
                    wholesalePrice = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.productCode);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customerId = table.Column<int>(type: "int(11)", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    invoice = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    orderPrice = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "customerId",
                        column: x => x.id,
                        principalTable: "Customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderGoods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    count = table.Column<int>(type: "int(11)", nullable: false),
                    formatId = table.Column<int>(type: "int(11)", nullable: false),
                    goodsId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    orderId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderGoods", x => x.id);
                    table.ForeignKey(
                        name: "formats",
                        column: x => x.formatId,
                        principalTable: "Formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "goodsId",
                        column: x => x.goodsId,
                        principalTable: "Goods",
                        principalColumn: "productCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "orderId",
                        column: x => x.orderId,
                        principalTable: "Orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "formatType_idx",
                table: "OrderGoods",
                column: "formatId");

            migrationBuilder.CreateIndex(
                name: "goodsId_idx",
                table: "OrderGoods",
                column: "goodsId");

            migrationBuilder.CreateIndex(
                name: "orderId_idx",
                table: "OrderGoods",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "customerId_idx",
                table: "Orders",
                column: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderGoods");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
