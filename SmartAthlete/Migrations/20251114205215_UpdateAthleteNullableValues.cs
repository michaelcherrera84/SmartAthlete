using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAthlete.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAthleteNullableValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Coaches_CoachId",
                table: "Athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Sports_SportId",
                table: "Athletes");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Athletes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoachId",
                table: "Athletes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Coaches_CoachId",
                table: "Athletes",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Sports_SportId",
                table: "Athletes",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Coaches_CoachId",
                table: "Athletes");

            migrationBuilder.DropForeignKey(
                name: "FK_Athletes_Sports_SportId",
                table: "Athletes");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Athletes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CoachId",
                table: "Athletes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Coaches_CoachId",
                table: "Athletes",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Athletes_Sports_SportId",
                table: "Athletes",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
