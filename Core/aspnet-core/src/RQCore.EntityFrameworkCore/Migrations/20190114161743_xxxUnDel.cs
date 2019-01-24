using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class xxxUnDel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<string>(nullable: true),
                    Arabic_Numbers = table.Column<decimal>(nullable: false),
                    Bank_account_number = table.Column<string>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true),
                    Claime_Type = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Drawer = table.Column<string>(nullable: true),
                    Goods = table.Column<string>(nullable: true),
                    InvoiceBillNo = table.Column<uint>(nullable: false),
                    InvoiceNo = table.Column<uint>(nullable: false),
                    InvoiceStateID = table.Column<uint>(nullable: false),
                    InvoiceserialNo = table.Column<uint>(nullable: false),
                    IsCandidate = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    MyBank_account_number = table.Column<string>(nullable: true),
                    MyCompanyName = table.Column<string>(nullable: true),
                    MyOpening_bank = table.Column<string>(nullable: true),
                    MyPrimary_Tel = table.Column<string>(nullable: true),
                    MyRegistered_address = table.Column<string>(nullable: true),
                    MyTaxpayer_identification_number = table.Column<string>(nullable: true),
                    Opening_bank = table.Column<string>(nullable: true),
                    Payee = table.Column<string>(nullable: true),
                    Price_Plus_Taxes = table.Column<string>(nullable: true),
                    Primary_Tel = table.Column<string>(nullable: true),
                    Qty = table.Column<string>(nullable: true),
                    Registered_address = table.Column<string>(nullable: true),
                    Review = table.Column<string>(nullable: true),
                    Sorting = table.Column<uint>(nullable: false),
                    Specifications = table.Column<string>(nullable: true),
                    TaxAmount = table.Column<string>(nullable: true),
                    TaxRate = table.Column<string>(nullable: true),
                    Taxpayer_identification_number = table.Column<string>(nullable: true),
                    The_Seller = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    Unit_Price = table.Column<string>(nullable: true),
                    Version = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });
        }
    }
}
