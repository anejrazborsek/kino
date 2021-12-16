using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dvorana",
                columns: table => new
                {
                    DvoranaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dvorana_tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dvorana", x => x.DvoranaID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Film_ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Film_trajanje = table.Column<int>(type: "int", nullable: false),
                    Film_reziser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Film_opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Film_img = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmID);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Predstava_cas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    DvoranaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                    table.ForeignKey(
                        name: "FK_Predstava_Dvorana_DvoranaID",
                        column: x => x.DvoranaID,
                        principalTable: "Dvorana",
                        principalColumn: "DvoranaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predstava_Film_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Karta",
                columns: table => new
                {
                    KartaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Karta_cena = table.Column<double>(type: "float", nullable: false),
                    PredstavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karta", x => x.KartaID);
                    table.ForeignKey(
                        name: "FK_Karta_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Karta_PredstavaID",
                table: "Karta",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_DvoranaID",
                table: "Predstava",
                column: "DvoranaID");

            migrationBuilder.CreateIndex(
                name: "IX_Predstava_FilmID",
                table: "Predstava",
                column: "FilmID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karta");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Dvorana");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
