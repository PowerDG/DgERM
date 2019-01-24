using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class updatemysql15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RQAfficheInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Claime_Type = table.Column<string>(nullable: true),
                    Super_Type = table.Column<string>(nullable: true),
                    Claim_Name = table.Column<string>(nullable: true),
                    AfficheTitle = table.Column<string>(nullable: true),
                    AfficheContent = table.Column<string>(nullable: true),
                    AfficheData = table.Column<string>(nullable: true),
                    BranchID = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Sorting = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_RQAfficheInfoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RQAfficheInfoes");
        }
    }
}
