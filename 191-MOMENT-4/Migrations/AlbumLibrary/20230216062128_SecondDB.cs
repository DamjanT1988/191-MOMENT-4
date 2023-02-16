using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _191_MOMENT_4.Migrations.AlbumLibrary
{
    /// <inheritdoc />
    public partial class SecondDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumLibrary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Artists = table.Column<string>(type: "TEXT", nullable: true),
                    SongAmount = table.Column<int>(type: "INTEGER", nullable: true),
                    TotLengthSec = table.Column<int>(type: "INTEGER", nullable: true),
                    Cathegory = table.Column<string>(type: "TEXT", nullable: true),
                    YearPub = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumLibrary", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumLibrary");
        }
    }
}
