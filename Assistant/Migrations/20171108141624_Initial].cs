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
                name: "goods",
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
                    table.PrimaryKey("PK_goods", x => x.productCode);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    customer = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    invoice = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true),
                    orderPrice = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order-Goods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    goodsId = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    orderId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order-Goods", x => x.id);
                    table.ForeignKey(
                        name: "goodsId",
                        column: x => x.goodsId,
                        principalTable: "goods",
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
                name: "goodsId_idx",
                table: "Order-Goods",
                column: "goodsId");

            migrationBuilder.CreateIndex(
                name: "orderId_idx",
                table: "Order-Goods",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order-Goods");

            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
