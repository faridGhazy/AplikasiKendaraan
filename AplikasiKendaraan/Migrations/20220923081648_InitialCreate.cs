using Microsoft.EntityFrameworkCore.Migrations;

namespace AplikasiKendaraan.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KendaraanModel",
                columns: table => new
                {
                    no_register = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alamat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    merk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tahun = table.Column<int>(type: "int", nullable: false),
                    silinder = table.Column<int>(type: "int", nullable: false),
                    warna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bahanBakar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KendaraanModel", x => x.no_register);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KendaraanModel");
        }
    }
}
