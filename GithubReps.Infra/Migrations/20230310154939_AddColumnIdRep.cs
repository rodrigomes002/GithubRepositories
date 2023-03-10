using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubReps.Infra.Migrations
{
    public partial class AddColumnIdRep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRep",
                table: "PopularRep",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdRep",
                table: "PopularRep");
        }
    }
}
