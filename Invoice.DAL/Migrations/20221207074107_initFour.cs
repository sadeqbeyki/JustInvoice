using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.DAL.Migrations
{
    public partial class initFour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Factors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ItemId",
                table: "Factors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
