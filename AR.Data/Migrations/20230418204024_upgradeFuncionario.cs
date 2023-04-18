using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR.Data.Migrations
{
    public partial class upgradeFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityEventPlanned",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "QuantityEventWorked",
                table: "Funcionarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityEventPlanned",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityEventWorked",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
