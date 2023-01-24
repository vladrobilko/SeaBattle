using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBattle.DataManagement.Migrations
{
    /// <inheritdoc />
    public partial class createcellmodelshipmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "playareas_pkey",
                table: "playareas");

            migrationBuilder.AddColumn<long>(
                name: "id",
                table: "playareas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddPrimaryKey(
                name: "playareas_pkey",
                table: "playareas",
                column: "id");

            migrationBuilder.CreateTable(
                name: "ships",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    idplayarea = table.Column<long>(name: "id_playarea", type: "bigint", nullable: false),
                    length = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ships_pkey", x => x.id);
                    table.ForeignKey(
                        name: "ships_id_playarea",
                        column: x => x.idplayarea,
                        principalTable: "playareas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "cells",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    idship = table.Column<long>(name: "id_ship", type: "bigint", nullable: false),
                    coordinatey = table.Column<long>(name: "coordinate y", type: "bigint", nullable: false),
                    coordinatex = table.Column<long>(name: "coordinate x", type: "bigint", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_ships_id_playarea",
                table: "ships",
                column: "id_playarea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cells");

            migrationBuilder.DropTable(
                name: "ships");

            migrationBuilder.DropPrimaryKey(
                name: "playareas_pkey",
                table: "playareas");

            migrationBuilder.DropColumn(
                name: "id",
                table: "playareas");

            migrationBuilder.AddPrimaryKey(
                name: "playareas_pkey",
                table: "playareas",
                column: "id_player");
        }
    }
}
