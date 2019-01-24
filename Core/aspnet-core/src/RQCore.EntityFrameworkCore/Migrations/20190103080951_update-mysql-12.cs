using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class updatemysql12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DgDictionarys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Claim_Value = table.Column<string>(nullable: true),
                    Issuer = table.Column<string>(nullable: true),
                    Claim_Type = table.Column<string>(nullable: true),
                    Super_Type = table.Column<string>(nullable: true),
                    Sub_Type = table.Column<string>(nullable: true),
                    Sorting = table.Column<int>(nullable: false),
                    isDisplay = table.Column<bool>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DgDictionarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    Inspection_No = table.Column<long>(nullable: false),
                    SourceType = table.Column<string>(nullable: true),
                    SourceNo = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DestinationNO = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    ProposerName = table.Column<string>(nullable: true),
                    ProposerID = table.Column<long>(nullable: false),
                    Sorting = table.Column<string>(maxLength: 100, nullable: true),
                    Title = table.Column<string>(nullable: true),
                    IsCandidate = table.Column<bool>(nullable: false),
                    InspectionState = table.Column<int>(nullable: false),
                    InspectionName = table.Column<string>(maxLength: 100, nullable: true),
                    Action = table.Column<string>(nullable: true),
                    InspectionMemo = table.Column<string>(maxLength: 255, nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Quality_level = table.Column<int>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Inspection_No);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DgDictionarys");

            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
