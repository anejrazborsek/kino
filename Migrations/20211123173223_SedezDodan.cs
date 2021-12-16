using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class SedezDodan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedež",
                columns: table => new
                {
                    SedezID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sedez_tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DvoranaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedež", x => x.SedezID);
                    table.ForeignKey(
                        name: "FK_Sedež_Dvorana_DvoranaID",
                        column: x => x.DvoranaID,
                        principalTable: "Dvorana",
                        principalColumn: "DvoranaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedež_DvoranaID",
                table: "Sedež",
                column: "DvoranaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedež");
        }
    }
}
