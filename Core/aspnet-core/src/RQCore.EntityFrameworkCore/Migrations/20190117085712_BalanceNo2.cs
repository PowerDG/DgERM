using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class BalanceNo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Delivery2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Distribution2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OTHER2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Packing2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pallet2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TRANSPORTATION2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transfer2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Upstairs2",
                table: "BillInfos",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPacking",
                table: "BillInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTax",
                table: "BillInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUpstairs",
                table: "BillInfos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivery2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Distribution2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "OTHER2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Packing2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Pallet2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Remark2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "TRANSPORTATION2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Transfer2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "Upstairs2",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "isPacking",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "isTax",
                table: "BillInfos");

            migrationBuilder.DropColumn(
                name: "isUpstairs",
                table: "BillInfos");
        }
    }
}
