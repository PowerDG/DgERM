using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class updatemysql6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DepartmentInfos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "BranchInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchID = table.Column<int>(nullable: false),
                    BranchName = table.Column<string>(maxLength: 255, nullable: false),
                    BranchLinkMan = table.Column<string>(maxLength: 255, nullable: false),
                    BranchPhone = table.Column<string>(maxLength: 255, nullable: false),
                    BranchAddress = table.Column<string>(nullable: false),
                    BranchEmail = table.Column<string>(maxLength: 255, nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchInfos", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "LogisticsInfos",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            //        BillNo = table.Column<long>(nullable: false),
            //        State = table.Column<int>(nullable: false),
            //        FillDate = table.Column<DateTime>(nullable: false),
            //        Infomation = table.Column<string>(nullable: true),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        CreationTime = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LogisticsInfos", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchInfos");

            //migrationBuilder.DropTable(
            //    name: "LogisticsInfos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DepartmentInfos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
