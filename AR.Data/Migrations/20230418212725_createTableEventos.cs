using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AR.Data.Migrations
{
    public partial class createTableEventos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountGuests = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressComplement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountWaiters = table.Column<int>(type: "int", nullable: true),
                    NameWaiters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
