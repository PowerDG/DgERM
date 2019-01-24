using Microsoft.EntityFrameworkCore.Migrations;

namespace RQCore.Migrations
{
    public partial class updatemysql9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ExpressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    ExpressNo = table.Column<string>(nullable: false),
                    ExpressName = table.Column<string>(nullable: true),
                    ExpressICO = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    IsDefaultShow = table.Column<bool>(nullable: false),
                    Sorting = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ExpressTypes", x => x.ExpressNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ExpressTypes");
        }
    }
}
