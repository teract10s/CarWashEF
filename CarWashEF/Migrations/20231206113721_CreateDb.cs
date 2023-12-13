using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashEF.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "servants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<float>(nullable: false),
                    servant_type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nickname = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    points = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "own_orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    time = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    ServantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_own_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_own_orders_servants_ServantId",
                        column: x => x.ServantId,
                        principalTable: "servants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    time = table.Column<int>(nullable: false),
                    price = table.Column<float>(nullable: false),
                    date_time = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_orders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "own_orders_servants",
                columns: table => new
                {
                    own_order_id = table.Column<int>(nullable: false),
                    servant_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_own_orders_servants", x => new { x.own_order_id, x.servant_id });
                    table.ForeignKey(
                        name: "FK_own_orders_servants_own_orders_own_order_id",
                        column: x => x.own_order_id,
                        principalTable: "own_orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_own_orders_servants_servants_servant_id",
                        column: x => x.servant_id,
                        principalTable: "servants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders_servants",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    servant_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_servants", x => new { x.order_id, x.servant_id });
                    table.ForeignKey(
                        name: "FK_orders_servants_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_servants_servants_servant_id",
                        column: x => x.servant_id,
                        principalTable: "servants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "servants",
                columns: new[] { "id", "name", "price", "servant_type", "time" },
                values: new object[,]
                {
                    { 1, "Windows washing", 200f, "WASH", 15 },
                    { 2, "Windows polishing", 100f, "POLISHING", 10 },
                    { 3, "Full washing", 750f, "WASH", 60 },
                    { 4, "Full polishing", 500f, "POLISHING", 70 },
                    { 5, "Dry cleaning", 2000f, "DRY_CLEANERS", 120 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_servants_servant_id",
                table: "orders_servants",
                column: "servant_id");

            migrationBuilder.CreateIndex(
                name: "IX_own_orders_ServantId",
                table: "own_orders",
                column: "ServantId");

            migrationBuilder.CreateIndex(
                name: "IX_own_orders_servants_servant_id",
                table: "own_orders_servants",
                column: "servant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders_servants");

            migrationBuilder.DropTable(
                name: "own_orders_servants");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "own_orders");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "servants");
        }
    }
}
