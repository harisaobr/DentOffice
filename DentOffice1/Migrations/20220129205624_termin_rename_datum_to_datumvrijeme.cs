using Microsoft.EntityFrameworkCore.Migrations;

namespace DentOffice.WebAPI.Migrations
{
    public partial class termin_rename_datum_to_datumvrijeme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Termin",
                newName: "DatumVrijeme");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatumVrijeme",
                table: "Termin",
                newName: "Datum");
        }
    }
}
