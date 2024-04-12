using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1932LBS2024.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utente",
                columns: table => new
                {
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    NomeUtente = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascita = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utente", x => x.UtenteId);
                });

            migrationBuilder.CreateTable(
                name: "Carrello",
                columns: table => new
                {
                    CarrelloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Articolo = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo = table.Column<double>(type: "REAL", nullable: false),
                    Immagine = table.Column<string>(type: "TEXT", nullable: true),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrello", x => x.CarrelloId);
                    table.ForeignKey(
                        name: "FK_Carrello_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "UtenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrello_UtenteId",
                table: "Carrello",
                column: "UtenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrello");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
