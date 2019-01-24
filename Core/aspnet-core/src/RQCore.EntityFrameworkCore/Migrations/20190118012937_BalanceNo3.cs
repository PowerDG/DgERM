using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class BalanceNo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "BalanceNo",
                table: "BillInfos",
                nullable: false,
                oldClrType: typeof(uint));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "BalanceNo",
                table: "BillInfos",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
