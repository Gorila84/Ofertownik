using Microsoft.EntityFrameworkCore.Migrations;

namespace Ofertownik.Data.Migrations
{
    public partial class addMachines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "Machines");
        }
    }
}
