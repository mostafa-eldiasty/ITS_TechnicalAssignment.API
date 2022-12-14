using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITS_TechnicalAssignment.DataAccess.Migrations
{
    public partial class AddClassColInCustomerTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Customer");
        }
    }
}
