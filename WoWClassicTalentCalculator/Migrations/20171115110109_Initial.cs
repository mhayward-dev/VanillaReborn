﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WoWClassicTalentCalculator.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarcraftClasses",
                columns: table => new
                {
                    WarcraftClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcraftClasses", x => x.WarcraftClassId);
                });

            migrationBuilder.CreateTable(
                name: "WarcraftClassSpecifications",
                columns: table => new
                {
                    WarcraftClassSpecificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationIndex = table.Column<int>(type: "int", nullable: false),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarcraftClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcraftClassSpecifications", x => x.WarcraftClassSpecificationId);
                    table.ForeignKey(
                        name: "FK_WarcraftClassSpecifications_WarcraftClasses_WarcraftClassId",
                        column: x => x.WarcraftClassId,
                        principalTable: "WarcraftClasses",
                        principalColumn: "WarcraftClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Talents",
                columns: table => new
                {
                    TalentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnIndex = table.Column<int>(type: "int", nullable: false),
                    NoOfRanks = table.Column<int>(type: "int", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    TalentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarcraftClassSpecificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.TalentId);
                    table.ForeignKey(
                        name: "FK_Talents_WarcraftClassSpecifications_WarcraftClassSpecificationId",
                        column: x => x.WarcraftClassSpecificationId,
                        principalTable: "WarcraftClassSpecifications",
                        principalColumn: "WarcraftClassSpecificationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talents_WarcraftClassSpecificationId",
                table: "Talents",
                column: "WarcraftClassSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WarcraftClassSpecifications_WarcraftClassId",
                table: "WarcraftClassSpecifications",
                column: "WarcraftClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talents");

            migrationBuilder.DropTable(
                name: "WarcraftClassSpecifications");

            migrationBuilder.DropTable(
                name: "WarcraftClasses");
        }
    }
}
