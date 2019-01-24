using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class InvoiceInfoAndItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceserialNo = table.Column<uint>(nullable: false),
                    InvoiceNo = table.Column<uint>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    InvoiceStateID = table.Column<uint>(nullable: false),
                    InvoiceBillNo = table.Column<uint>(nullable: false),
                    Sorting = table.Column<uint>(nullable: false),
                    IsCandidate = table.Column<bool>(nullable: false),
                    Version = table.Column<uint>(nullable: false),
                    BillCheck = table.Column<uint>(nullable: false),
                    Claime_Type = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InvoiceItemNo = table.Column<string>(nullable: true),
                    Goods = table.Column<string>(nullable: true),
                    Specifications = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Qty = table.Column<string>(nullable: true),
                    Unit_Price = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    TaxRate = table.Column<string>(nullable: true),
                    TaxAmount = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    Price_Plus_Taxes = table.Column<string>(nullable: true),
                    Arabic_Numbers = table.Column<decimal>(nullable: false),
                    Payee = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Drawer = table.Column<string>(nullable: true),
                    The_Seller = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Taxpayer_identification_number = table.Column<string>(nullable: true),
                    Registered_address = table.Column<string>(nullable: true),
                    Primary_Tel = table.Column<string>(nullable: true),
                    Opening_bank = table.Column<string>(nullable: true),
                    Bank_account_number = table.Column<string>(nullable: true),
                    MyCompanyName = table.Column<string>(nullable: true),
                    MyTaxpayer_identification_number = table.Column<string>(nullable: true),
                    MyRegistered_address = table.Column<string>(nullable: true),
                    MyPrimary_Tel = table.Column<string>(nullable: true),
                    MyOpening_bank = table.Column<string>(nullable: true),
                    MyBank_account_number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceNo = table.Column<uint>(nullable: false),
                    InvoiceItemNo = table.Column<int>(nullable: false),
                    Goods = table.Column<string>(nullable: true),
                    Specifications = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    Qty = table.Column<int>(nullable: false),
                    Unit_Price = table.Column<decimal>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    TaxRate = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    InvoiceStateID = table.Column<string>(nullable: true),
                    InvoiceBillNo = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    Sorting = table.Column<int>(nullable: false),
                    Claime_Type = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceInfoes");

            migrationBuilder.DropTable(
                name: "InvoiceItems");
        }
    }
}
