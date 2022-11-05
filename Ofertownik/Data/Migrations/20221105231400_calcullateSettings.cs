using Microsoft.EntityFrameworkCore.Migrations;

namespace Ofertownik.Data.Migrations
{
    public partial class calcullateSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "WorkingHourPrice",
                table: "Machines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CalcullationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyPrice = table.Column<double>(type: "float", nullable: false),
                    ProductMargin = table.Column<int>(type: "int", nullable: false),
                    MaterialMargin = table.Column<int>(type: "int", nullable: false),
                    WorkerHourPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalcullationSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalcullationSettings");

            migrationBuilder.DropColumn(
                name: "WorkingHourPrice",
                table: "Machines");
        }
    }
}
