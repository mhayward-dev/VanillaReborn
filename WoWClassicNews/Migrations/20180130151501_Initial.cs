﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WoWClassicNews.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvatarImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TalentIcons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentIcons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarcraftClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcraftClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsStories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    MidSectionHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecondaryTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopSectionHtml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsStories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsStories_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarcraftClassSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationIndex = table.Column<int>(type: "int", nullable: false),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarcraftClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarcraftClassSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarcraftClassSpecifications_WarcraftClasses_WarcraftClassId",
                        column: x => x.WarcraftClassId,
                        principalTable: "WarcraftClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsStoryId = table.Column<int>(type: "int", nullable: true),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsTags_NewsStories_NewsStoryId",
                        column: x => x.NewsStoryId,
                        principalTable: "NewsStories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Talents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnIndex = table.Column<int>(type: "int", nullable: false),
                    RequiredTalentId = table.Column<int>(type: "int", nullable: true),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    TalentIconId = table.Column<int>(type: "int", nullable: true),
                    TalentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarcraftClassSpecificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Talents_Talents_RequiredTalentId",
                        column: x => x.RequiredTalentId,
                        principalTable: "Talents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talents_TalentIcons_TalentIconId",
                        column: x => x.TalentIconId,
                        principalTable: "TalentIcons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Talents_WarcraftClassSpecifications_WarcraftClassSpecificationId",
                        column: x => x.WarcraftClassSpecificationId,
                        principalTable: "WarcraftClassSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TalentRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RankDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RankNo = table.Column<int>(type: "int", nullable: false),
                    TalentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TalentRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TalentRanks_Talents_TalentId",
                        column: x => x.TalentId,
                        principalTable: "Talents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsStories_AuthorId",
                table: "NewsStories",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsTags_NewsStoryId",
                table: "NewsTags",
                column: "NewsStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TalentRanks_TalentId",
                table: "TalentRanks",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_RequiredTalentId",
                table: "Talents",
                column: "RequiredTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_TalentIconId",
                table: "Talents",
                column: "TalentIconId");

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
                name: "NewsTags");

            migrationBuilder.DropTable(
                name: "TalentRanks");

            migrationBuilder.DropTable(
                name: "NewsStories");

            migrationBuilder.DropTable(
                name: "Talents");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "TalentIcons");

            migrationBuilder.DropTable(
                name: "WarcraftClassSpecifications");

            migrationBuilder.DropTable(
                name: "WarcraftClasses");
        }
    }
}
