using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubReps.Infra.Migrations
{
    public partial class addColumnLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "PopularRep",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "PopularRep");
        }
    }
}
