﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigrationtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MyNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    VehiculeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Couleur = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    PrixJour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "Locataires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointsBonus = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    LocataireType = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locataires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locataires_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocataireFK = table.Column<int>(type: "int", nullable: false),
                    VehiculeKey = table.Column<int>(type: "int", nullable: false),
                    DureeJours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => new { x.VehiculeKey, x.LocataireFK, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservation_Locataires_LocataireFK",
                        column: x => x.LocataireFK,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Vehicules_VehiculeKey",
                        column: x => x.VehiculeKey,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locataires_AgentId",
                table: "Locataires",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_LocataireFK",
                table: "Reservation",
                column: "LocataireFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Locataires");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
