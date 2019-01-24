using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class BalancesAddMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillCheck",
                table: "InvoiceInfoes");

            migrationBuilder.DropColumn(
                name: "InvoiceItemNo",
                table: "InvoiceInfoes");

            migrationBuilder.AddColumn<uint>(
                name: "BalanceNo",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<int>(
                name: "BillNo",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<uint>(
                name: "BalanceNo",
                table: "BillInfos",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BalanceNo = table.Column<uint>(nullable: false),
                    Claime_Type = table.Column<string>(nullable: true),
                    Super_Type = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true),
                    TotalFee = table.Column<decimal>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Sorting = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropColumn(
                name: "BalanceNo",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "BillNo",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "BalanceNo",
                table: "BillInfos");

            migrationBuilder.AddColumn<uint>(
                name: "BillCheck",
                table: "InvoiceInfoes",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceItemNo",
                table: "InvoiceInfoes",
                nullable: true);
        }
    }
}
