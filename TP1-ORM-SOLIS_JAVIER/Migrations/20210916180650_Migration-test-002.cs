using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP1_ORM_SOLIS_JAVIER.Migrations
{
    public partial class Migrationtest002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Trailer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalaId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    PeliculasPeliculaId = table.Column<int>(type: "int", nullable: true),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    SalasSalaId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculasPeliculaId",
                        column: x => x.PeliculasPeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalasSalaId",
                        column: x => x.SalasSalaId,
                        principalTable: "Salas",
                        principalColumn: "SalaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    FuncionesFuncionId = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionesFuncionId",
                        column: x => x.FuncionesFuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinopsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "URL_Poster.png", "Accidentes en un parque de atracciones con dinosaurios", "Jurasic Park", "URL_trailer.mp4" },
                    { 2, "URL_Poster.png", "Un cazarrecompensas intenta encontrar el santo grial", "Indiana Jones y la Ultima Cruzada", "URL_trailer.mp4" },
                    { 3, "URL_Poster.png", "Mas carreras, mas explosiones, mas velocidad. Ahora con naves espaciales", "Rapido y Furioso 25: Carreras marcianas", "URL_trailer.mp4" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalaId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 50 },
                    { 2, 100 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculasPeliculaId",
                table: "Funciones",
                column: "PeliculasPeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalasSalaId",
                table: "Funciones",
                column: "SalasSalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionesFuncionId",
                table: "Tickets",
                column: "FuncionesFuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
