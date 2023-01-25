using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBattle.DataManagement.Migrations
{
    /// <inheritdoc />
    public partial class addjsontoship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cells");

            migrationBuilder.AddColumn<string>(
                name: "decks_json",
                table: "ships",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "decks_json",
                table: "ships");

            migrationBuilder.CreateTable(
                name: "cells",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    idship = table.Column<long>(name: "id_ship", type: "bigint", nullable: false),
                    coordinatex = table.Column<long>(name: "coordinate x", type: "bigint", nullable: false),
                    coordinatey = table.Column<long>(name: "coordinate y", type: "bigint", nullable: false),
                    isdead = table.Column<bool>(name: "is dead", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cells_pkey", x => x.id);
                    table.ForeignKey(
                        name: "cells_id_ships",
                        column: x => x.idship,
                        principalTable: "ships",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cells_id_ship",
                table: "cells",
                column: "id_ship");
        }
    }
}
