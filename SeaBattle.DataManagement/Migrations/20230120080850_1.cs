using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBattle.DataManagement.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "game_state",
                table: "seabattle_games");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_game",
                table: "seabattle_games",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "confirmed_playarea",
                table: "playareas",
                type: "timestamp(0) with time zone",
                precision: 0,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmed_playarea",
                table: "playareas");

            migrationBuilder.AlterColumn<long>(
                name: "end_game",
                table: "seabattle_games",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0) with time zone",
                oldPrecision: 0,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "game_state",
                table: "seabattle_games",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
