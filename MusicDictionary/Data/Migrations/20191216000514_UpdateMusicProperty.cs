using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDictionary.Data.Migrations
{
    public partial class UpdateMusicProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Music",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Music");
        }
    }
}
