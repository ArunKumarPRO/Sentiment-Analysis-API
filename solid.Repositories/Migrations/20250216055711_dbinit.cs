using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace solid.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class dbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentiments",
                columns: table => new
                {
                    TextId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prediction = table.Column<bool>(type: "bit", nullable: false),
                    SentimentScore = table.Column<float>(type: "real", nullable: false),
                    SentimentLabel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentiments", x => x.TextId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentiments");
        }
    }
}
