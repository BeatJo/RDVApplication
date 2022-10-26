using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RendezVous.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    SpecialiteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_de_specialite = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.SpecialiteID);
                });

            migrationBuilder.CreateTable(
                name: "Medecin",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricule = table.Column<int>(type: "int", nullable: false),
                    specialite_id = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecin", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Medecin_Specialite_specialite_id",
                        column: x => x.specialite_id,
                        principalTable: "Specialite",
                        principalColumn: "SpecialiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeConsultation",
                columns: table => new
                {
                    TypeConsultationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    specialite_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeConsultation", x => x.TypeConsultationID);
                    table.ForeignKey(
                        name: "FK_TypeConsultation_Specialite_specialite_id",
                        column: x => x.specialite_id,
                        principalTable: "Specialite",
                        principalColumn: "SpecialiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilite",
                columns: table => new
                {
                    DisponibiliteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JourDeLaSemaine = table.Column<int>(type: "int", nullable: false),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    medecin_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilite", x => x.DisponibiliteID);
                    table.ForeignKey(
                        name: "FK_Disponibilite_Medecin_medecin_id",
                        column: x => x.medecin_id,
                        principalTable: "Medecin",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ConsultationTD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medecin_id = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    type_consultation_id = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ConsultationTD);
                    table.ForeignKey(
                        name: "FK_Consultation_Client_client_id",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Consultation_Medecin_medecin_id",
                        column: x => x.medecin_id,
                        principalTable: "Medecin",
                        principalColumn: "UserID");
                    table.ForeignKey(
                        name: "FK_Consultation_TypeConsultation_type_consultation_id",
                        column: x => x.type_consultation_id,
                        principalTable: "TypeConsultation",
                        principalColumn: "TypeConsultationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_client_id",
                table: "Consultation",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_medecin_id",
                table: "Consultation",
                column: "medecin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_type_consultation_id",
                table: "Consultation",
                column: "type_consultation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilite_medecin_id",
                table: "Disponibilite",
                column: "medecin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medecin_Matricule",
                table: "Medecin",
                column: "Matricule",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medecin_specialite_id",
                table: "Medecin",
                column: "specialite_id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeConsultation_specialite_id",
                table: "TypeConsultation",
                column: "specialite_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "Disponibilite");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TypeConsultation");

            migrationBuilder.DropTable(
                name: "Medecin");

            migrationBuilder.DropTable(
                name: "Specialite");
        }
    }
}
