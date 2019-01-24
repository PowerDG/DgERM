using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class updatemysql16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerID = table.Column<int>(nullable: false),
                    CompanyAbbreviation = table.Column<string>(maxLength: 255, nullable: true),
                    InvoiceType = table.Column<string>(maxLength: 255, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: true),
                    Taxpayer_identification_number = table.Column<string>(maxLength: 255, nullable: true),
                    Registered_address = table.Column<string>(maxLength: 255, nullable: true),
                    Actual_Operating = table.Column<string>(maxLength: 255, nullable: true),
                    Opening_bank = table.Column<string>(maxLength: 255, nullable: true),
                    Bank_account_number = table.Column<string>(maxLength: 255, nullable: true),
                    Primary_contact = table.Column<string>(maxLength: 100, nullable: true),
                    Primary_Tel = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerSex = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerFax = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerPostID = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerEmail = table.Column<string>(maxLength: 255, nullable: true),
                    Secondary_contact = table.Column<string>(maxLength: 100, nullable: true),
                    Secondary_Tel = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerRegData = table.Column<string>(maxLength: 100, nullable: true),
                    Monthly_statement_of_time = table.Column<string>(maxLength: 255, nullable: true),
                    MerchandiserName = table.Column<string>(nullable: true),
                    MerchandiserId = table.Column<long>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    IsCandidate = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfos");
        }
    }
}
