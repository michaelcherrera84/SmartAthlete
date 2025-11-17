using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAthlete.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAthleteInjuriesKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteInjuries",
                table: "AthleteInjuries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteInjuries",
                table: "AthleteInjuries",
                columns: new[] { "AthleteId", "InjuryId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AthleteInjuries",
                table: "AthleteInjuries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AthleteInjuries",
                table: "AthleteInjuries",
                columns: new[] { "AthleteId", "InjuryId" });
        }
    }
}
