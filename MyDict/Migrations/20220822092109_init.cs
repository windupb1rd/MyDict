using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyDict.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnglishWord = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Transcription = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Definition1 = table.Column<string>(type: "text", nullable: true),
                    Definition2 = table.Column<string>(type: "text", nullable: true),
                    Definition3 = table.Column<string>(type: "text", nullable: true),
                    Definition4 = table.Column<string>(type: "text", nullable: true),
                    Definition5 = table.Column<string>(type: "text", nullable: true),
                    Example1 = table.Column<string>(type: "text", nullable: true),
                    Example2 = table.Column<string>(type: "text", nullable: true),
                    Example3 = table.Column<string>(type: "text", nullable: true),
                    Example4 = table.Column<string>(type: "text", nullable: true),
                    Example5 = table.Column<string>(type: "text", nullable: true),
                    Translations = table.Column<string>(type: "text", nullable: true),
                    NextReview = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsOnLearning = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_words", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "words");
        }
    }
}
