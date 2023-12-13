using Microsoft.EntityFrameworkCore.Migrations;

namespace CarWashEF.Migrations
{
    public partial class AddServant6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "servants",
                columns: new[] { "id", "name", "price", "servant_type", "time" },
                values: new object[] { 6, "NEW", 0f, "DRY_CLEANERS", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "servants",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
